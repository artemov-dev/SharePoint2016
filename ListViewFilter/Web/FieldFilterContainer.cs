using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListViewFilter.ApplicationObjects;
using ListViewFilter.Extensions;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace ListViewFilter.Web
{
    internal class FieldFilterContainer : Control
    {
        public string FieldInternalName { get; set; }
        public FilterType FieldType { get; set; }

        public IEnumerable<string> GetCAMLPredicates(bool diacriticVariations)
        {
            string _val;
            var extraList = new List<string>();
            var datas = new List<CAMLPredicateData>();
            DateTime _valDateTime;
            Control valControl;
            switch (FieldType)
            {
                case FilterType.Text:
                    #region Text
                    valControl = Controls.OfType<TextBox>().FirstOrDefault();
                    if (valControl != null)
                    {
                        _val = ((TextBox)valControl).Text;
                        if (!string.IsNullOrEmpty(_val))
                        {
                            if (diacriticVariations)
                            {
                                var strItems = ((TextBox) valControl)
                                    .Text
                                    .DiacriticVariations()
                                    .Select(x => new CAMLPredicateData
                                    {
                                        FieldType = CAMLFieldType.Text,
                                        FeildInternalName = FieldInternalName,
                                        IsLookupId = false,
                                        Operator = CAMLOperator.Contains,
                                        NodeValue = x
                                    })
                                    .Select(x => x.ToString())
                                    .ToList();
                                var res = CAMLGenerator.JoinFilters(strItems, CAML.Or);
                                extraList.Add(res);
                            }
                            else
                            {
                                datas.Add(new CAMLPredicateData
                                {
                                    FieldType = CAMLFieldType.Text,
                                    FeildInternalName = FieldInternalName,
                                    IsLookupId = false,
                                    Operator = CAMLOperator.Contains,
                                    NodeValue = ((TextBox)valControl).Text
                                });
                            }
                        }
                    }
                    break;
                #endregion
                case FilterType.TextWithOptions:
                    #region TextWithOptions
                    valControl = Controls.OfType<TextBox>().FirstOrDefault();
                    var type = Page.Request.Form[FieldInternalName + "_Type"];
                    var typeEnum = CAMLOperator.Contains;
                    switch ((type ?? string.Empty).ToUpper())
                    {
                        case "EQ":
                            typeEnum = CAMLOperator.Eq;
                            break;
                        case "NEQ":
                            typeEnum = CAMLOperator.Neq;
                            break;
                        case "BEGINSWITH":
                            typeEnum = CAMLOperator.BeginsWith;
                            break;
                        case "CONTAINS":
                            typeEnum = CAMLOperator.Contains;
                            break;
                        case "GT":
                            typeEnum = CAMLOperator.Gt;
                            break;
                        case "GTE":
                            typeEnum = CAMLOperator.Geq;
                            break;
                        case "LT":
                            typeEnum = CAMLOperator.Lt;
                            break;
                        case "LTE":
                            typeEnum = CAMLOperator.Leq;
                            break;
                        default:
                            break;
                    }
                    if (valControl != null)
                    {
                        _val = ((TextBox)valControl).Text;

                        if (!string.IsNullOrEmpty(_val))
                        {
                            if (diacriticVariations)
                            {
                                var strItems = ((TextBox) valControl)
                                    .Text
                                    .DiacriticVariations()
                                    .Select(x => new CAMLPredicateData
                                    {
                                        FieldType = CAMLFieldType.Text,
                                        FeildInternalName = FieldInternalName,
                                        IsLookupId = false,
                                        Operator = CAMLOperator.Contains,
                                        NodeValue = x
                                    })
                                    .Select(x => x.ToString())
                                    .ToList();
                                var res = CAMLGenerator.JoinFilters(strItems, CAML.Or);
                                extraList.Add(res);
                            }
                            else
                            {
                                datas.Add(new CAMLPredicateData
                                {
                                    FieldType = CAMLFieldType.Text,
                                    FeildInternalName = FieldInternalName,
                                    IsLookupId = false,
                                    Operator = typeEnum,
                                    NodeValue = _val
                                });
                            }
                        }
                    }
                    break;
                #endregion
                case FilterType.DropDownSingleValue:
                    #region DropDownSingleValue
                    valControl = Controls.OfType<DropDownList>().FirstOrDefault();
                    if (valControl != null)
                    {
                        _val = Page.Request.Form[valControl.UniqueID];
                        if (string.IsNullOrEmpty(_val)) break;
                        if (_val != "-2")
                        {
                            if (_val == "-1")
                            {
                                datas.Add(new CAMLPredicateData
                                {
                                    FieldType = CAMLFieldType.Text,
                                    FeildInternalName = FieldInternalName,
                                    IsLookupId = false,
                                    Operator = CAMLOperator.IsNull,
                                    NodeValue = _val
                                });
                            }
                            else
                            {
                                datas.Add(new CAMLPredicateData
                                {
                                    FieldType = CAMLFieldType.Text,
                                    FeildInternalName = FieldInternalName,
                                    IsLookupId = false,
                                    Operator = CAMLOperator.Eq,
                                    NodeValue = _val
                                });
                            }
                        }
                    }
                    break;
                #endregion
                case FilterType.DropDownMultiValue:
                    #region DropDownMultiValue
                    var ddVals = Page.Request.Form[FieldInternalName + "_Type"];
                    if (!string.IsNullOrEmpty(ddVals))
                    {
                        var ddValItems = ddVals.Split('|')
                            .Select(val => new CAMLPredicateData
                            {
                                FieldType = CAMLFieldType.Text,
                                FeildInternalName = FieldInternalName,
                                IsLookupId = false,
                                Operator = CAMLOperator.Eq,
                                NodeValue = val
                            })
                            .Select(x => x.ToString())
                            .ToList();
                        var res = CAMLGenerator.JoinFilters(ddValItems, CAML.Or);
                        extraList.Add(res);
                    }
                    break;
                #endregion
                case FilterType.AutoComplete:
                    #region AutoComplete
                    valControl = Controls.OfType<TextBox>().FirstOrDefault();
                    if (valControl != null)
                    {
                        _val = Page.Request.Form[valControl.UniqueID];
                        //_val = ((TextBox)valControl).Text;
                        if (!string.IsNullOrEmpty(_val))
                        {
                            if (diacriticVariations)
                            {
                                var strItems = ((TextBox) valControl)
                                    .Text
                                    .DiacriticVariations()
                                    .Select(x => new CAMLPredicateData
                                    {
                                        FieldType = CAMLFieldType.Text,
                                        FeildInternalName = FieldInternalName,
                                        IsLookupId = false,
                                        Operator = CAMLOperator.Contains,
                                        NodeValue = x
                                    })
                                    .Select(x => x.ToString())
                                    .ToList();
                                var res = CAMLGenerator.JoinFilters(strItems, CAML.Or);
                                extraList.Add(res);
                            }
                            else
                            {
                                datas.Add(new CAMLPredicateData
                                {
                                    FieldType = CAMLFieldType.Text,
                                    FeildInternalName = FieldInternalName,
                                    IsLookupId = false,
                                    Operator = CAMLOperator.Contains,
                                    NodeValue = _val
                                });
                            }
                        }
                    }
                    break;
                #endregion
                case FilterType.Date:
                    #region Date
                    valControl = Controls.OfType<DateTimeControl>().FirstOrDefault();
                    if (valControl != null)
                    {
                        if (!((DateTimeControl)valControl).IsDateEmpty)
                        {
                            _valDateTime = ((DateTimeControl)valControl).SelectedDate;
                            _val = SPUtility.CreateISO8601DateTimeFromSystemDateTime(_valDateTime);
                            if (!string.IsNullOrEmpty(_val))
                            {
                                datas.Add(new CAMLPredicateData
                                {
                                    FieldType = CAMLFieldType.DateTime,
                                    FeildInternalName = FieldInternalName,
                                    IsLookupId = false,
                                    Operator = CAMLOperator.Eq,
                                    NodeValue = _val
                                });
                            }
                        }
                    }
                    break;
                #endregion
                case FilterType.DateRange:
                    #region DateRange
                    var dates = Controls
                        .Cast<Control>()
                        .Where(c => c.Controls.Count > 0)
                        .SelectMany(c => c.Controls.Cast<Control>())
                        .OfType<DateTimeControl>()
                        .Where(d => !d.IsDateEmpty)
                        .Select(d => d.SelectedDate)
                        .OrderBy(d => d)
                        .ToList();
                    if (dates.Count > 0)
                    {
                        var isFirst = true;
                        foreach (var date in dates)
                        {
                            _val = SPUtility.CreateISO8601DateTimeFromSystemDateTime(date);
                            datas.Add(new CAMLPredicateData
                            {
                                FieldType = CAMLFieldType.DateTime,
                                FeildInternalName = FieldInternalName,
                                IsLookupId = false,
                                Operator = isFirst ? CAMLOperator.Geq : CAMLOperator.Leq,
                                NodeValue = _val
                            });
                            if (isFirst) isFirst = false;
                        }
                    }
                    break;
                #endregion
                case FilterType.PeoplePicker:
                    #region PeoplePicker
                    valControl = Controls.OfType<PeopleEditor>().FirstOrDefault();
                    if (valControl != null)
                    {
                        if (((PeopleEditor)valControl).ResolvedEntities.Count > 0)
                        {
                            _val = ((PeopleEditor)valControl).UserValue().LookupId.ToString();
                            datas.Add(new CAMLPredicateData
                            {
                                FieldType = CAMLFieldType.User,
                                FeildInternalName = FieldInternalName,
                                IsLookupId = true,
                                Operator = CAMLOperator.Eq,
                                NodeValue = _val
                            });
                        }
                    }
                    break;
                #endregion
                case FilterType.PeoplePickerMulti:
                    #region PeoplePickerMulti
                    valControl = Controls.OfType<PeopleEditor>().FirstOrDefault();
                    if (valControl != null)
                    {
                        if (((PeopleEditor)valControl).ResolvedEntities.Count > 0)
                        {
                            var users = ((PeopleEditor)valControl).UserValueCollection()
                                .Select(val => new CAMLPredicateData
                                {
                                    FieldType = CAMLFieldType.User,
                                    FeildInternalName = FieldInternalName,
                                    IsLookupId = true,
                                    Operator = CAMLOperator.Eq,
                                    NodeValue = val.LookupId.ToString()
                                })
                                .Select(x => x.ToString())
                                .ToList();
                            var res = CAMLGenerator.JoinFilters(users, CAML.Or);
                            extraList.Add(res);
                        }
                    }
                    break;
                #endregion
                case FilterType.Boolean:
                    #region Boolean
                    valControl = Controls.OfType<DropDownList>().FirstOrDefault();
                    if (valControl != null)
                    {
                        _val = Page.Request.Form[valControl.UniqueID];
                        //_val = ((DropDownList)valControl).SelectedValue;
                        if (_val != "-2")
                        {
                            if (_val == "-1")
                            {
                                datas.Add(new CAMLPredicateData
                                {
                                    FieldType = CAMLFieldType.Boolean,
                                    FeildInternalName = FieldInternalName,
                                    IsLookupId = false,
                                    Operator = CAMLOperator.IsNull,
                                    NodeValue = _val
                                });
                            }
                            else
                            {
                                datas.Add(new CAMLPredicateData
                                {
                                    FieldType = CAMLFieldType.Boolean,
                                    FeildInternalName = FieldInternalName,
                                    IsLookupId = false,
                                    Operator = CAMLOperator.Eq,
                                    NodeValue = _val
                                });
                            }
                        }
                    }
                    break;
                #endregion
                case FilterType.TaxonomyTerm:
                    #region TaxonomyTerm
                    valControl = Controls.OfType<TaxonomyWebTaggingControl>().FirstOrDefault();
                    if (valControl != null)
                    {
                        var txt = ((TaxonomyWebTaggingControl)valControl).Text;
                        if (!string.IsNullOrEmpty(txt))
                        {
                            datas.Add(new CAMLPredicateData
                            {
                                FeildInternalName = FieldInternalName,
                                FieldType = CAMLFieldType.TaxonomyField,
                                IsLookupId = false,
                                Operator = CAMLOperator.Eq,
                                NodeValue = txt.Split('|')[0]
                            });
                        }
                    }
                    break;
                #endregion
                case FilterType.TaxonomyMultiTerm:
                    #region TaxonomyMultiTerm
                    valControl = Controls.OfType<TaxonomyWebTaggingControl>().FirstOrDefault();
                    if (valControl != null)
                    {
                        var txt = ((TaxonomyWebTaggingControl)valControl).Text;
                        if (!string.IsNullOrEmpty(txt))
                        {
                            var terms = txt.Split(';')
                                .Select(x => new { Term = x.Split('|')[0], GUID = new Guid(x.Split('|')[1]) })
                                .Select(x => new CAMLPredicateData
                                {
                                    FeildInternalName = FieldInternalName,
                                    FieldType = CAMLFieldType.TaxonomyFieldMultiValue,
                                    IsLookupId = false,
                                    Operator = CAMLOperator.Eq,
                                    NodeValue = x.Term
                                })
                                .Select(x => x.ToString())
                                .ToList();
                            var res = CAMLGenerator.JoinFilters(terms, CAML.Or);
                            extraList.Add(res);
                        }
                    }
                    break;
                #endregion
                case FilterType.Slider:
                    #region Slider
                    var sliderValue = Page.Request.Form["Field" + FieldInternalName];
                    if (!string.IsNullOrEmpty(sliderValue))
                    {
                        datas.Add(new CAMLPredicateData
                        {
                            FieldType = CAMLFieldType.Text,
                            FeildInternalName = FieldInternalName,
                            IsLookupId = false,
                            Operator = CAMLOperator.Eq,
                            NodeValue = sliderValue
                        });
                    }
                    break;
                #endregion
                case FilterType.SliderRange:
                    #region SliderRange
                    var sliderValues = Page.Request.Form["Field" + FieldInternalName];
                    if (!string.IsNullOrEmpty(sliderValues))
                    {
                        var min = sliderValues.Split(',')[0];
                        var max = sliderValues.Split(',')[1];
                        datas.Add(new CAMLPredicateData
                        {
                            FieldType = CAMLFieldType.Text,
                            FeildInternalName = FieldInternalName,
                            IsLookupId = false,
                            Operator = CAMLOperator.Geq,
                            NodeValue = min
                        });
                        datas.Add(new CAMLPredicateData
                        {
                            FieldType = CAMLFieldType.Text,
                            FeildInternalName = FieldInternalName,
                            IsLookupId = false,
                            Operator = CAMLOperator.Leq,
                            NodeValue = max
                        });
                    }
                    break;
                #endregion
                default:
                    return null;
            }

            return CAMLGenerator.BuilderFieldQuery(datas, extraList).ToList();
        }
    }
}
