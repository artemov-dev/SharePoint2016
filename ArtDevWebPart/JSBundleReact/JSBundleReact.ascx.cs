using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

namespace ArtDevWebPart.JSBundleReact
{
    [ToolboxItemAttribute(false)]
    public partial class JSBundleReact : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public JSBundleReact()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string ReactRootElement = ((JSBundleReact)sender).ReactRootElement;
            string JSBundleFile = ((JSBundleReact)sender).JSBundleFile;
            ControlCollection controlCollection = ((JSBundleReact)sender).Controls;
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", ReactRootElement);
            controlCollection.AddAt(0, div);
            ((JSBundleReact)sender).ChromeType = PartChromeType.None;
            ClientScriptManager csm = ((JSBundleReact)sender).Page.ClientScript;
            string script = "window.onload = function() { CallBackScriptBundle('" + JSBundleFile + "'); };";

            if (!csm.IsStartupScriptRegistered(this.GetType(), "CallBackScriptBundle"))
            {
                csm.RegisterStartupScript(this.GetType(), "CallBackScriptBundle", script, true);
            }
        }


        [Personalizable(PersonalizationScope.Shared)]
        [WebBrowsable(true)]
        [Category("Настрока")]
        [WebDisplayName("JSBundleFile")]
        [Description("JSBundleFile")]
        public string JSBundleFile { get; set; }

        [Personalizable(PersonalizationScope.Shared)]
        [WebBrowsable(true)]
        [Category("Настрока")]
        [WebDisplayName("ReactRootElement")]
        [Description("ReactRootElement")]
        public string ReactRootElement { get; set; }
    }
}
