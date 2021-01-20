using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ArtDevWebPart.JSBundleReact
{
    [ToolboxItemAttribute(false)]
    public class JSBundleReact : WebPart
    {
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
        protected override void CreateChildControls()
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", this.ReactRootElement);
            this.Controls.AddAt(0, div);
            this.ChromeType = PartChromeType.None;
           
            //make script
            if (this.ReactRootElement != null && this.JSBundleFile != null)
            {
                string mode = (string)SPContext.Current.Web.AllProperties["DEV"] ?? null;
                string file = mode == "true" ? "http://localhost:3000/public/" + this.JSBundleFile.Substring(this.JSBundleFile.LastIndexOf('/') + 1) : this.JSBundleFile;
                StringBuilder sb = new StringBuilder();
                sb.Append("<script language='javascript'>");
                sb.Append("var script = document.createElement('script');");
                sb.Append("script.setAttribute('src', '" + file + "');");
                sb.Append("document.head.appendChild(script);");
                sb.Append("</script>");
                ClientScriptManager csm = this.Page.ClientScript;
                if (!csm.IsClientScriptBlockRegistered("JSScriptBlock_"+ this.ReactRootElement))
                {
                    csm.RegisterClientScriptBlock(this.GetType(), "JSScriptBlock_" + this.ReactRootElement, sb.ToString());
                }
            }

        }
    }
}
