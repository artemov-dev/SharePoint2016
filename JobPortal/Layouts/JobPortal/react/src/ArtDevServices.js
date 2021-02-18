
export const SPServices = (function () {

    var priv = { lastStatusId: undefined };
    // Получаем адрес сайта
    function getWebUrl() {
        return (_spPageContextInfo.webServerRelativeUrl == '/') ? '' : _spPageContextInfo.webServerRelativeUrl;
    }

    // Получаем адрес коллекции сайта
    function getSiteUrl() {
        return _spPageContextInfo.siteServerRelativeUrl;
    }

    // Перевод объекта в строку параметров типа 'param1=value1&param2=value2'
    function getStringParamsFromObject(paramsObject) {
        return Object.keys(paramsObject).map(function (k) {
            return encodeURI(k) + '=' + encodeURI(paramsObject[k]);
        }).join('&');
    }

    // Формирует URL для запроса получения элементов списка через REST
    function getWebApiUrlList(listUrl) {
        var webUrl = getWebUrl();
        return webUrl + '/_api/web/getList(\'' + webUrl + listUrl + '\')/items?';
    }

    // Проверяем что аттач это картинка
    function isImage(fileName) {
        return /(\.jpg|\.jpeg|\.png|\.bmp|\.svg)$/i.test(fileName);
    }

    // Получение значения параметра URL'а по его имени
    function getUrlParameterByName(name) {
        var url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"), results = regex.exec(url);
        if (!results) {
            return null
        }

        if (!results[2]) {
            return '';
        }

        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }

    // Формирует URL для запроса получения элемента списка по ID для REST
    function getListItemById(listUrl, itemId) {
        var webUrl = getWebUrl();
        return webUrl + '/_api/web/getList(\'' + webUrl + listUrl + '\')/items(' + itemId + ')';
    }

    // Создание элемента в списке
    function createListItem(listUrl, data) {
        var deferred = jQuery.Deferred();

        var webUrl = getWebUrl();
        fetch(webUrl + "/_api/web/getList('" + webUrl + listUrl + "')/items", {
            method: 'POST',
            headers: {
                'Accept': "application/json;odata=verbose",
                'Content-Type': "application/json;odata=verbose",
                'X-RequestDigest': jQuery("#__REQUESTDIGEST").val()
            },
            body: JSON.stringify(data)
        })
            .then(function (response) {
                return response.json();
            })
            .then(function (data) {
                deferred.resolve(data.d);
            })
            .catch(function (error) {
                deferred.reject(error);
                console.log('Не удалась создать элемент', error);
            });

        return deferred.promise();
    }

    // Удаление элемента из списка
    function deleteListItem(listUrl, itemId) {
        var deferred = jQuery.Deferred();

        var webUrl = getWebUrl();
        fetch(webUrl + "/_api/web/getList('" + webUrl + listUrl + "')/items(" + itemId + ")", {
            method: 'DELETE',
            headers: {
                'Accept': "application/json;odata=verbose",
                'Content-Type': "application/json;odata=verbose",
                'X-RequestDigest': jQuery("#__REQUESTDIGEST").val(),
                'IF-MATCH': "*"
            }
        })
            .then(function (data) {
                deferred.resolve(data);
            })
            .catch(function (error) {
                deferred.reject(error);
                console.log('Не удалась удалить элемент', error);
            });

        return deferred.promise();
    }

    function updateListItem(listUrl, itemId, data) {
        return new Promise(function (resolve, reject) {
            var webUrl = getWebUrl();

            fetch(webUrl + "/_api/web/getList('" + webUrl + listUrl + "')/items(" + itemId + ")", {
                method: "POST",
                headers: {
                    'Accept': "application/json;odata=verbose",
                    'Content-Type': "application/json;odata=verbose",
                    'X-RequestDigest': jQuery("#__REQUESTDIGEST").val(),
                    'IF-MATCH': "*",
                    'X-Http-Method': "MERGE"
                },
                body: JSON.stringify(data)
            })
                .then(function (response) {
                    resolve(response);
                })
                .catch(function (error) {
                    reject(error);
                    console.log('Не удалась обновить элемент');
                });
        });
    }


    function getJsomListItems(webUrl, listTitle, camlQuery, params, pagingInfo) {
        // Возращаем promise чтобы снабдить функцию функционалом обещаний
        return new Promise(function (resolve, reject) {        
                var context = SP.ClientContext.get_current();;//new SP.ClientContext(webUrl); TODO: не открывать контекст, если подходит текущий
                var list = context.get_web().get_lists().getByTitle(listTitle);
                var query = new SP.CamlQuery();
                query.set_viewXml(camlQuery);

                if (pagingInfo) {
                    var position = new SP.ListItemCollectionPosition();
                    position.set_pagingInfo(pagingInfo);
                    query.set_listItemCollectionPosition(position);
                }

                var listItems = list.getItems(query);
                if (params) {
                    context.load(listItems, params);
                } else {
                    context.load(listItems);
                }

                context.executeQueryAsync(function () {
                    // var items = [];
                    var enumerator = listItems.getEnumerator();

                    var promises = [];
                    while (enumerator.moveNext()) {
                        var item = enumerator.get_current().get_fieldValues();
                        jQuery.extend(item, { AttachmentFiles: [] });

                        var promise = checkAttachments(context, enumerator, item);
                        promises.push(promise);
                    }

                    Promise.all(promises)
                        .then(function (data) {
                            resolve(data);
                        });

                }, function (sender, error) {
                    reject(error.get_message(), error.get_stackTrace());
                });
            });       
    }

    function checkAttachments(context, enumerator, item) {
        return new Promise(function (resolve) {
            if (item.Attachments) {
                var attachmentFiles = enumerator.get_current().get_attachmentFiles();
                getAttachments(context, attachmentFiles, item)
                    .then(function (data) {
                        resolve(data);
                    });
            } else {
                resolve(item);
            }
        });
    }

    function getAttachments(context, attachmentFiles, item) {
        return new Promise(function (resolve, reject) {
            context.load(attachmentFiles);
            context.executeQueryAsync(function () {
                var attachmentsItemsEnumerator = attachmentFiles.getEnumerator();
                while (attachmentsItemsEnumerator.moveNext()) {
                    var attachItem = attachmentsItemsEnumerator.get_current();

                    item.AttachmentFiles.push({
                        FileName: attachItem.get_fileName(),
                        ServerRelativeUrl: attachItem.get_serverRelativeUrl()
                    });
                }

                resolve(item);
            }, function (sender, error) {
                reject(error.get_message(), error.get_stackTrace());
            });
        });
    }

    // Определить, состоит ли текущий пользователь в указанных группах
    function isUserInGroups(userGroups) {
        // Возращаем promise чтобы снабдить функцию функционалом обещаний
        return new Promise(function (resolve) {

            if (userGroups === undefined) {
                userGroups = [];
            }

            // Добавляем по умолчанию группу системных администраторов
            // userGroups.push(SLSystemConstants.SYSTEM_ADMINISTRATOR_GROUP);

            var url = getWebUrl() + '/_api/web/currentuser/groups';

            fetch(url, {
                headers: {
                    'Accept': "application/json;odata=verbose",
                    'Content-Type': "application/json;odata=verbose",
                }
            })
                .then(function (response) {
                    return response.json();
                })
                .then(function (response) {
                    response.d.results.map(function (item) {
                        if (userGroups.indexOf(item.Title) != -1) {
                            resolve(true);
                        }
                    });
                    resolve(false);
                })
                .catch(function (error) {
                    console.log('Ошибка при проверке групп пользователя', error);
                });
        });
    }


    function addNotification(text, fixed) {
        if (SP.UI.Notify) {
            if (priv.lastStatusId)
                SP.UI.Status.removeStatus(priv.lastStatusId);
            priv.lastStatusId = SP.UI.Notify.addNotification(text, fixed == true);
        }
        //SP.UI.Status.addStatus("Status good!") SP.UI.Status.setStatusPriColor(statusId, 'red');     SP.UI.Status.removeStatus(statusId);
    }

    // Если это документ, то откроем в отдельной закладке и в owa
    function getLink(link) {
        if (link) {
            var linkUrl = link.Url ? link.Url : link;
            if (linkUrl.search(/\.pdf$|\.doc$|\.xls$|\.ppt$|\.docx$|\.xlsx$|\.pptx$/ig) !== -1) {
                return linkUrl.split('?')[0] + '?Web=1';
            } else {
                return linkUrl;
            }
        }

        return '#';
    }

    // Если это документ, то откроем в отдельной закладке
    function getTarget(link) {
        if (getLink(link).search(/Web=1$/ig) !== -1) {
            return '_blank';
        }
        else
            return '_self';
    }

    function getHashTagLink(hashTagId) {
        return getWebUrl() + '/SitePages/search.aspx?#q=&advanced=1&hashtags=' + hashTagId;
    }

    /**
     * http://stackoverflow.com/questions/2353211/hsl-to-rgb-color-conversion
     *
     * Converts an HSL color value to RGB. Conversion formula
     * adapted from http://en.wikipedia.org/wiki/HSL_color_space.
     * Assumes h, s, and l are contained in the set [0, 1] and
     * returns r, g, and b in the set [0, 255].
     *
     * @param   Number  h       The hue
     * @param   Number  s       The saturation
     * @param   Number  l       The lightness
     * @return  Array           The RGB representation
     */
    function hslToRgb(h, s, l) {
        var r, g, b;

        if (s == 0) {
            r = g = b = l; // achromatic
        } else {
            function hue2rgb(p, q, t) {
                if (t < 0) t += 1;
                if (t > 1) t -= 1;
                if (t < 1 / 6) return p + (q - p) * 6 * t;
                if (t < 1 / 2) return q;
                if (t < 2 / 3) return p + (q - p) * (2 / 3 - t) * 6;
                return p;
            }

            var q = l < 0.5 ? l * (1 + s) : l + s - l * s;
            var p = 2 * l - q;
            r = hue2rgb(p, q, h + 1 / 3);
            g = hue2rgb(p, q, h);
            b = hue2rgb(p, q, h - 1 / 3);
        }

        return [Math.floor(r * 255), Math.floor(g * 255), Math.floor(b * 255)];
    }

    // Делаю свою функцию setCookie (копия из docflow), т.к. в функции в docflow ошибка, из-за которой нельзя указать szPath
    function setCookie(szName, szValue, uDaysExpires, szPath) {
        var dtExpires = new Date();
        var szExpireDate = '';

        if (szPath == '') szPath = "/";

        dtExpires.setTime(dtExpires.getTime() + uDaysExpires * 24 * 60 * 60 * 1000);
        szExpireDate = dtExpires.toGMTString();
        szValue = encodeURI(szValue);
        document.cookie = szName + '=' + szValue + '; path=' + szPath + '; expires=' + szExpireDate;
    }

    // возвращает cookie с именем name, если есть, если нет, то undefined
    function getCookie(name) {
        var matches = document.cookie.match(new RegExp(
            "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
        ));
        return matches ? decodeURIComponent(matches[1]) : undefined;
    }

    // Создание элемента в списке
    function getSetting(name, callback) {
        var deferred = jQuery.Deferred();

        SP.SOD.executeFunc('sp.js', 'SP.ClientContext', () => {
            SPServices.getJsomListItems("", "Настройки", "<View Scope='Recursive'><Query></Query></View>")
                .then(items => {

                    var item = items.filter(item => item.Title === name);
                    if (item.length == 1)
                        callback(item[0].SettingsValue);

                })
                .catch(error =>
                    console.log('Не удалось получить данные из списка Настройки для ' + name + " " + error)
                );
        });
    }

    function isInEditMode() {

        var inDesignMode = document.forms[MSOWebPartPageFormName].MSOLayout_InDesignMode;
        inDesignMode = inDesignMode == undefined ? null : document.forms[MSOWebPartPageFormName].MSOLayout_InDesignMode.value;
        if (inDesignMode == "1") { return true; }
        var wikiInEditMode = document.forms[MSOWebPartPageFormName]._wikiPageMode;
        wikiInEditMode = wikiInEditMode == undefined ? null : document.forms[MSOWebPartPageFormName]._wikiPageMode.value;
        if (wikiInEditMode == "Edit") { return true; }
        else { return false; }
    }

    function OpenModalDialog(strPageURL, width, height) {
        var dialogOptions = SP.UI.$create_DialogOptions();
        dialogOptions.url = strPageURL; // URL of the Page               
        // Width of the Dialog  
        dialogOptions.width = width;
        // Height of the Dialog  
        dialogOptions.height = height;
        // Function to capture dialog closed event  
        //dialogReturnValueCallback - A function pointer that specifies the return callback function. The function takes two parameters, a dialogResult of type SP.UI.DialogResult Enumeration and a returnValue of type object that contains any data returned by the dialog.  
        //dialogOptions.dialogReturnValueCallback = Function.createDelegate(null, CloseCallback);  
        // Open the Dialog  
        SP.UI.ModalDialog.showModalDialog(dialogOptions);
        return false;


    }



    return {
        getWebUrl: getWebUrl,
        getSiteUrl: getSiteUrl,
        getStringParamsFromObject: getStringParamsFromObject,
        getWebApiUrlList: getWebApiUrlList,
        isImage: isImage,
        getUrlParameterByName: getUrlParameterByName,
        getListItemById: getListItemById,
        createListItem: createListItem,
        deleteListItem: deleteListItem,
        updateListItem: updateListItem,
        getJsomListItems: getJsomListItems,
        isUserInGroups: isUserInGroups,
        addNotification: addNotification,
        getLink: getLink,
        getTarget: getTarget,
        getHashTagLink: getHashTagLink,
        hslToRgb: hslToRgb,
        setCookie: setCookie,
        getCookie: getCookie,
        getSetting: getSetting,
        isInEditMode: isInEditMode,
        OpenModalDialog: OpenModalDialog
    }
}());


