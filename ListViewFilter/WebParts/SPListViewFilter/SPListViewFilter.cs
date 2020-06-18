using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using ListViewFilter.ApplicationObjects;
using ListViewFilter.DataObjects;
using ListViewFilter.Extensions;
using ListViewFilter.Web;
using ListViewFilter.WebParts.SPListViewFilter.ToolParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using WebPart = Microsoft.SharePoint.WebPartPages.WebPart;
using WPM = System.Web.UI.WebControls.WebParts.WebPartManager;

namespace ListViewFilter.WebParts.SPListViewFilter
{
    /// <summary>
    /// SPListViewFilter WebPart
    /// </summary>
    [ToolboxItemAttribute(false)]
    public class SPListViewFilter : WebPart, IWebPartParameters
    {
        ///<summary>
        ///</summary>
        public PropertyDescriptorCollection Parameters { get; set; }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        [ConnectionProvider("Filter Provider", AllowsMultipleConnections = false)]
        public IWebPartParameters ConnectionInterface()
        {
            return this;
        }

        private Control _container;

        private bool IsPreview
        {
            get
            {
                if (Parent == null) return false;
                return Parent.GetType().FullName == "Microsoft.SharePoint.WebPartPages.WebPartPreview";
            }
        }

        ///<summary>
        ///</summary>
        public bool PreventDataViewUntilFiltering { get; set; }
        public bool UseSqlQueries { get; set; }
        public bool RegisterjQueryOnPage { get; set; }
        public bool PrepareDiacriticalVariations { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool RegisterjQueryUIOnPage { get; set; }

        public string RibbonHiddenElementIds { get; set; }

        public string[] RibbonHiddenElements
        {
            get { return (RibbonHiddenElementIds ?? string.Empty).Split('|'); }
            set
            {
                if (value != null)
                {
                    RibbonHiddenElementIds = string.Join("|", value);
                }
                else
                {
                    RibbonHiddenElementIds = string.Empty;
                }
            }
        }

        public bool IsRibbonElementHidden(string id)
        {
            return RibbonHiddenElements != null
                   && RibbonHiddenElements
                       .Contains(id);
        }

        ///<summary>
        ///</summary>
        public FilterPanelType PanelType { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            FilterButton.Click += FilterButtonClick;
        }

        void FilterButtonClick(object sender, EventArgs e)
        {
            FilterData();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (IsPreview)
            {
                LoadDemoMode();
            }
            else
            {
                RegisterjQuery();
                LoadWorkingMode();
                HideRibbonElements();
                if (PreventDataViewUntilFiltering)
                {
                    FilterData();
                }
            }
        }

        private void RegisterjQuery()
        {
            if (RegisterjQueryOnPage)
            {
                Controls.Add(new LiteralControl(@"<script src=""/_layouts/15/SPFilter/Scripts/jquery.js""></script>"));
            }
            if (RegisterjQueryUIOnPage)
            {
                Controls.Add(new LiteralControl(@"<script src=""/_layouts/15/SPFilter/Scripts/jquery-ui.min.js""></script>"));
                Controls.Add(new LiteralControl(@"<link rel=""stylesheet"" href=""/_layouts/15/SPFilter/Styles/jquery-ui.min.css""/>"));
            }
        }

        private void HideRibbonElements()
        {
            var rm = SPRibbon.GetCurrent(Page);
            if (rm != null && RibbonHiddenElements != null)
            {
                foreach (var element in RibbonHiddenElements)
                {
                    rm.TrimById(element);
                }
            }
        }

        protected UpdatePanel Up = new UpdatePanel { RenderMode = UpdatePanelRenderMode.Inline };

        private void LoadWorkingMode()
        {
            CssClass = "spfilter-container";
            try
            {
                if (ListViewWebPart == null)
                {
                    if (WebPartManager.DisplayMode.AllowPageDesign)
                    {
                        const string iconUrl = "/_layouts/15/images/SPFilter/IconInfo.gif";
                        var text = string.Format(this.LocalizedString("Text_ShowEditPanel"), ID);
                        RenderMessage(text, iconUrl, string.Empty);
                    }
                }
                else
                {
                    if (ListFilterSettings.GetCurrent(this).Fields.Any())
                    {
                        CssRegistration.Register("forms.css");
                        _container = this;
                        RenderFields();
                        _container.Controls.Add(new LiteralControl(@"<div style=""clear:both;""></div>"));
                        FilterButton.Text = this.LocalizedString("Button_Apply");
                        _container.Controls.Add(FilterButton);

                        Controls.Add(Up);
                        RenderStyleSheet(_container);

                    }
                    else
                    {
                        const string iconUrl = "/_layouts/15/images/SPFilter/IconInfo.gif";
                        var text = string.Format(this.LocalizedString("Text_ShowEditPanel"), ID);
                        RenderMessage(text, iconUrl, string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                Controls.Clear();
                const string iconUrl = "/_layouts/15/images/SPFilter/IconError.png";
                var text = ex.Message;
                RenderMessage(text, iconUrl, string.Empty);
            }
        }

        private void LoadDemoMode()
        {
            Controls.Add(new Image
            {
                ImageUrl = "/_layouts/15/images/SPFilter/SimpleSPListView.png",
                BorderWidth = new Unit("0px")
            });
        }

        private void RenderStyleSheet(Control container)
        {
            container.Controls.Add(new LiteralControl(_styles));
        }

        public override ToolPart[] GetToolParts()
        {
            var baseToolParts = base.GetToolParts();
            var res = new List<ToolPart>
                          {
                              new FieldSettingsToolPart(),
                              new ViewToolPart(),
                              new AdvancedSettings(),
                              new RibbonHideToolPart(),
                              new AboutToolPart()
                          };
            res.AddRange(baseToolParts);
            return res.ToArray();
        }

        protected Button FilterButton = new Button
        {
            CssClass = @"ms-ButtonHeightWidth"
        };

        ///<summary>
        ///</summary>
        public string FilterDefinitionString { get; set; }

        private List<string> CAMLPredicates
        {
            get
            {
                if (_container == null) return new List<string>();
                if (!_container.Controls.OfType<FieldFilterContainer>().Any()) return new List<string>();
                var containers = _container.Controls
                    .OfType<FieldFilterContainer>()
                    .Select(c => c.GetCAMLPredicates(PrepareDiacriticalVariations))
                    .Where(c => c != null);
                var predicates = new List<string>();
                foreach (var ps in containers)
                {
                    predicates.AddRange(ps);
                }
                if (predicates.Count == 0 && PreventDataViewUntilFiltering)
                {
                    predicates.Add(@"<Eq><FieldRef Name='ID' LookupId='TRUE'/><Value Type='Number'>0</Value></Eq>");
                }
                return predicates;
            }
        }
        private void ModifyCAMLFilter(IDataSource dataSource)
        {
            var source = dataSource as SPDataSource;
            if (source != null)
            {
                ModifyCAMLFilter(source);
            }
        }

        private void ModifyCAMLFilter(SPDataSource dataSource)
        {
            var xml = new XmlDocument();
            xml.LoadXml(dataSource.SelectCommand);
            if (xml.DocumentElement == null) return;

            var query = xml.DocumentElement.SelectSingleNode(CAML.Query);
            if (query != null)
            {
                var where = query.SelectSingleNode(CAML.Where);
                if (where == null)
                {
                    where = xml.CreateNode(XmlNodeType.Element, CAML.Where, string.Empty);
                    query.AppendChild(where);
                    var w = CAMLGenerator.JoinFilters(CAMLPredicates, CAML.And);
                    where.InnerXml = w;
                }
                else
                {
                    var whereParts = new List<string> { where.InnerXml };
                    whereParts.AddRange(CAMLPredicates);
                    where.InnerXml = CAMLGenerator.JoinFilters(whereParts, CAML.And);
                }
            }
            dataSource.SelectCommand = xml.OuterXml;

            Debug.WriteLine(xml.OuterXml);
        }

        private void ModifyCAMLFilter(SPView view)
        {
            var xml = new XmlDocument();
            xml.LoadXml(view.GetViewXml());
            if (xml.DocumentElement == null) return;

            var query = xml.DocumentElement.SelectSingleNode(CAML.Query);
            if (query != null)
            {
                var where = query.SelectSingleNode(CAML.Where);
                if (where == null)
                {
                    where = xml.CreateNode(XmlNodeType.Element, CAML.Where, string.Empty);
                    query.AppendChild(where);
                    var w = CAMLGenerator.JoinFilters(CAMLPredicates, CAML.And);
                    where.InnerXml = w;
                }
                else
                {
                    var whereParts = new List<string> { where.InnerXml };
                    whereParts.AddRange(CAMLPredicates);
                    where.InnerXml = CAMLGenerator.JoinFilters(whereParts, CAML.And);
                }
            }
            view.SetViewXml(xml.OuterXml);

            Debug.WriteLine(xml.OuterXml);
        }

        private void RenderFields()
        {
            var settings = ListFilterSettings.GetCurrent(this);
            //SPUrlUtility.CombineUrl(SPContext.Current.Web.Url, list.RootFolder.Url)

            switch (PanelType)
            {
                case FilterPanelType.WrapPanel:
                    RenderWrapPanel(settings.Fields);
                    break;
                case FilterPanelType.Grid:
                    RenderGrid(settings.Fields);
                    break;
                case FilterPanelType.StackPanel:
                    RenderStackPanel(settings.Fields);
                    break;
            }
        }

        private void RenderWrapPanel(IEnumerable<ListFilterField> fields)
        {
            foreach (var field in fields)
            {
                RenderField(field);
            }
        }

        private void RenderGrid(IEnumerable<ListFilterField> fields)
        {
            CssRegistration.Register("forms.css");
            _container.Controls.Add(new LiteralControl(@"<table class=""ms-formtable"" style=""margin-top: 8px;"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%""><tbody><tr>"));
            const int fieldsPerRow = 3;
            var counter = 0;
            foreach (var field in fields)
            {
                RenderField(field);
                counter = counter + 1;
                if (counter == fieldsPerRow)
                {
                    counter = 0;
                    _container.Controls.Add(new LiteralControl(@"</tr><tr>"));
                }
            }
            _container.Controls.Add(new LiteralControl(@"</tr></tbody></table>"));
        }

        private void RenderStackPanel(IEnumerable<ListFilterField> fields)
        {
            CssRegistration.Register("forms.css");
            _container.Controls.Add(new LiteralControl(@"<table class=""ms-formtable"" style=""margin-top: 8px;"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%""><tbody>"));
            foreach (var field in fields)
            {
                RenderField(field);
            }
            _container.Controls.Add(new LiteralControl(@"</tbody></table>"));
        }

        private void RenderField(ListFilterField field)
        {
            if (ListViewWebPart == null) return;
            var ctx = SPContext.Current;
            var web = ctx.Web;
            var list = web.Lists[ListViewWebPart.ListId];
            var spField = list.Fields.GetFieldByInternalName(field.InternalName);
            var ctrl = ControlManager.GetControl(field, spField, UseSqlQueries, PanelType);

            switch (PanelType)
            {
                case FilterPanelType.WrapPanel:
                    var id = "ctrl_" + Guid.NewGuid().ToString("N");
                    var css = ((field.Type & FilterType.Wide) == field.Type)
                                  ? "spfilter-field-wide"
                                  : "spfilter-field";
                    _container.Controls.Add(new LiteralControl(
                                     string.Format(@"<div class=""{0}""><label for=""{1}"">{2}</label><div id=""{3}"">",
                                                   css, id, field.Caption, id)));
                    _container.Controls.Add(ctrl);
                    _container.Controls.Add(new LiteralControl("</div></div>"));
                    break;
                case FilterPanelType.Grid:
                    _container.Controls.Add(new LiteralControl(string.Format(@"<td valign=""top"" class=""ms-formbody""><label>{0}</label><span dir=""none"">", field.Caption)));
                    _container.Controls.Add(ctrl);
                    _container.Controls.Add(new LiteralControl("</span></td>"));
                    break;
                case FilterPanelType.StackPanel:
                    _container.Controls.Add(new LiteralControl(string.Format(@"<tr><td nowrap=""true"" valign=""top"" width=""190px"" class=""ms-formlabel"">
                                        <h3 class=""ms-standardheader""><nobr>{0}</nobr></h3></td><td valign=""top"" class=""ms-formbody""><label></label><span dir=""none"">", field.Caption)));
                    _container.Controls.Add(ctrl);
                    _container.Controls.Add(new LiteralControl("</span></td></tr>"));
                    break;
            }
        }

        private SPWebPartManager SPWebPartManager
        {
            get
            {
                return _spWebPartManager
                    ?? (_spWebPartManager = WPM.GetCurrentWebPartManager(Page) as SPWebPartManager);
            }
        }

        private SPWebPartManager _spWebPartManager;

        internal XsltListViewWebPart ListViewWebPart
        {
            get
            {
                if (SPWebPartManager == null) return null;
                return _listViewWebPart
                       ?? (_listViewWebPart = WebPartManager.Connections
                                                  .Cast<WebPartConnection>()
                                                  .Where(x => x.Provider == this)
                                                  .Select(x => x.Consumer)
                                                  .OfType<XsltListViewWebPart>()
                                                  .FirstOrDefault());
            }
        }

        private XsltListViewWebPart _listViewWebPart;

        private void FilterData()
        {
            if (SPWebPartManager == null) return;
            if (ListViewWebPart == null) return;

            var predicates = CAMLPredicates;
            if (predicates.Count == 0)
                return;

            ListViewWebPart.HasOverrideSelectCommand = true;
            ListViewWebPart.CleanUpDataSource();
            ModifyCAMLFilter(ListViewWebPart.GetDataSource());
        }


        /// <summary>
        /// Gets the value of the data from the connection provider.
        /// </summary>
        /// <param name="callback">
        /// The method to call to process the data from the provider.
        /// </param>
        public void GetParametersData(ParametersCallback callback)
        {
            var objParameters = new StateBag();
            callback.Invoke(objParameters);
        }

        /// <summary>
        /// Sets the property descriptors for the properties that the consumer receives when calling the 
        /// <see cref="M:System.Web.UI.WebControls.WebParts.IWebPartParameters.GetParametersData(System.Web.UI.WebControls.WebParts.ParametersCallback)"/> method.
        /// </summary>
        /// <param name="schema">
        /// The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"/> returned by <see cref="P:System.Web.UI.WebControls.WebParts.IWebPartParameters.Schema"/>.
        /// </param>
        public void SetConsumerSchema(PropertyDescriptorCollection schema)
        {
            Parameters = schema;
        }

        /// <summary>
        /// Gets the property descriptors for the data to be received by the consumer.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"/> describing the data.
        /// </returns>
        public PropertyDescriptorCollection Schema
        {
            get
            {
                var arrProperties =
                    new PropertyDescriptor[Parameters.Count];
                TypeDescriptor.GetProperties(this);

                var intParameterCount = 0;
                foreach (PropertyDescriptor objProperty in Parameters
                    .Cast<PropertyDescriptor>()
                    .Where(objProperty => Parameters[objProperty.Name] != null))
                {
                    intParameterCount++;
                    arrProperties[intParameterCount] = objProperty;
                }

                var objProperties = new PropertyDescriptorCollection(arrProperties);
                return objProperties;
            }
        }

        private void RenderMessage(string text, string iconUrl, string iconAlt)
        {
            var str =
                string.Format(
                    @"<table class=""ms-WPBody"" style=""padding:0px;width:100%;""><tbody><tr>
					<td valign=""top"" style=""padding-left:4px;padding-right:4px;""><img src=""{0}"" alt=""{2}""></td>
                    <td width=""100%"" style=""padding-left:4px;padding-right:4px;"">{1}</td></tr></tbody></table>",
                    iconUrl, text, iconAlt);
            Controls.Add(new LiteralControl(str));
        }

        private static string _styles =
@"<style>
    div.spfilter-field, div.spfilter-field-wide {     display: block;
    float: left;
    width: 248px;
    height: auto;
    min-height: 55px;
    border-width: 1px;
    border-style: solid;
    padding-left: 2px;
    margin: 0;
    border-color: #DEDEDE;
    background-color: white;
    border-collapse: collapse; }
    div.spfilter-field-wide { width: 500px; }
    div.spfilter-field-wide table { display: block; float: left; }
    td.ms-formbody label { white-space: nowrap; display: block; }
    td.ms-formbody table { display: block; float: left; }
    span.sp-menu-qnt { margin-left: 20px; font-size: 14px; font-weight: bold; }
</style>";

        private static string _itemsCountingJavaScriptFormat = @"
<script>
SP.SOD.executeOrDelayUntilScriptLoaded(function(){{
    var pm = SP.Ribbon.PageManager.get_instance();
    pm.add_ribbonInited(function(){{
        FetchEcbInfo(ctx, ""{2}-{3}"", ""TABLE"", function(){{
            var tblId = ""{2}-{3}""; 
            var key = 'ecbtab_ctx' + ctx.ctxId; 
            var ecbTab = document.getElementById(key);
            if(ecbTab){{
                var dict = ecbTab.dict; 
                $(document.getElementById(tblId)).find(""div.itx"").each(function(){{ 
                    var itemId = $(this).attr(""id""); 
                    if (!dict[itemId]){{ 
                        dict[itemId] = $(this).get(0);
                    }} 
                }});
            }}
        }});
    }});
    if(pm.get_ribbon()){{
        FetchEcbInfo(ctx, ""{2}-{3}"", ""TABLE"", function(){{
            var tblId = ""{2}-{3}""; 
            var key = 'ecbtab_ctx' + ctx.ctxId; 
            var ecbTab = document.getElementById(key);
            var dict = ecbTab.dict; 
            $(document.getElementById(tblId)).find(""div.itx"").each(function(){{ 
                var itemId = $(this).attr(""id""); 
                if (!dict[itemId]){{ 
                    dict[itemId] = $(this).get(0);
                }} 
            }});
        }});
    }}
}}, ""sp.ribbon.js"");
</script>";
    }
}
