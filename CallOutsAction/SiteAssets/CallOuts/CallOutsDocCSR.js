// The file has been created, saved into "/Style Library/"
// and attached to the XLV via JSLink property.

SP.SOD.executeFunc("clienttemplates.js", "SPClientTemplates", function () {

    function getBaseHtml(ctx) {
        return SPClientTemplates["_defaultTemplates"].Fields.default.all.all[ctx.CurrentFieldSchema.FieldType][ctx.BaseViewID](ctx);
    }

    function init() {

        SPClientTemplates.TemplateManager.RegisterTemplateOverrides({

            // OnPreRender: function(ctx) { },

            Templates: {

                //     View: function(ctx) { return ""; },
                //     Header: function(ctx) { return ""; },
                //     Body: function(ctx) { return ""; },
                //     Group: function(ctx) { return ""; },
                Item: function (ctx) {

                    var wrapper = document.createElement('tbody');
                    var Itemtpl = RenderItemTemplate(ctx)
                    wrapper.innerHTML = Itemtpl;
                    var name = wrapper.getElementsByClassName('ms-vb-title')[0]
                    name.id = "notify"
                    return wrapper.innerHTML;
                },
                //     Fields: {
                //         "<field internal name>": {
                //             View: function(ctx) { return ""; },
                //             EditForm: function(ctx) { return ""; },
                //             DisplayForm: function(ctx) { return ""; },
                //             NewForm: function(ctx) { return ""; }
                //         }
                //     },
                //     Footer: function(ctx) { return ""; }

            },

            OnPostRender: function (ctx) {

                SP.SOD.executeFunc('mQuery.js', 'm$', function () {

                    var launchPoint = m$("#notify")



                    SP.SOD.executeFunc('callout.js', 'CreateMyCallOut', function () {
                        var myCalloutOptions = new CalloutOptions();
                        myCalloutOptions.ID = "my_callout";
                        myCalloutOptions.beakOrientation = "topBottom";
                        myCalloutOptions.title = "my callout";
                        myCalloutOptions.launchPoint = launchPoint[0];


                        myCalloutOptions.content = "<div id='my_callout_content'>my callout content</div>";
                        myCalloutOptions.openOptions = {
                            //closeCalloutOnBlur: false,
                            event: "hover", // click or hover
                            showCloseButton: true
                        }
                        myCalloutOptions.onOpeningCallback = function (clOut) {
                            console.log("onOpeningCallback")
                        };
                        myCalloutOptions.onOpenedCallback = function (clOut) {
                            console.log("onOpenedCallback")
                        };
                        myCalloutOptions.onClosingCallback = function (clOut) {
                            console.log("onClosingCallback")
                        };
                        myCalloutOptions.onClosedCallback = function (clOut) {
                            console.log("onOpeningCallback")
                        };

                        var myCallout = CalloutManager.createNew(myCalloutOptions)

                    });




                })



            },

            ListTemplateType: 101

        });
    }

    RegisterModuleInit(SPClientTemplates.Utility.ReplaceUrlTokens("~siteCollection/Style Library/documents.js"), init);
    init();

});
