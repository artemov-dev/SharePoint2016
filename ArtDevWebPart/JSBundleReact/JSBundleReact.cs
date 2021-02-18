using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Security.Cryptography;
using System.IO;
using Microsoft.SharePoint.Utilities;

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

        private string GetMD5Hash(string  filename)
        {

            
            string hive = SPUtility.GetGenericSetupPath(string.Empty) + "TEMPLATE\\";
            using (var md5 = MD5.Create())
            {
                filename = filename.Replace("/15/", "/").Replace("/14/", "/").Replace("/12/", "/").Replace("/_layouts/", "/layouts/");
                try
                {
                    using (var stream = File.OpenRead(hive + filename))
                    {
                        var hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                } catch(Exception e) { return ""; }
            }
        }

        protected override void CreateChildControls()
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", this.ReactRootElement);
            this.Controls.AddAt(0, div);
            this.ChromeType = PartChromeType.None;
           
            //make script
            if (this.ReactRootElement != null && this.JSBundleFile != null)
            {
                string hash = GetMD5Hash(this.JSBundleFile);
                string mode = (string)SPContext.Current.Web.AllProperties["DEV"] ?? null;
                string filename = this.JSBundleFile.Substring(this.JSBundleFile.LastIndexOf('/') + 1);
                string file = mode == "true" ? "http://localhost:3000/public/" + filename : this.JSBundleFile + "?hash=" + hash;

                ClientScriptManager csm = this.Page.ClientScript;
                //Render the function invocation. 
                string funcCall = "<script src='" + file + "' language='javascript'></script>";

                if (!csm.IsStartupScriptRegistered("JSScript_" + this.ReactRootElement))
                {
                    csm.RegisterStartupScript(this.GetType(), "JSScript_" + this.ReactRootElement, funcCall);
                }

                /*StringBuilder sb = new StringBuilder();
                sb.Append("<script language='javascript'>");
                sb.Append("var script = document.createElement('script');");
                sb.Append("script.setAttribute('src', '" + file + "');");
                sb.Append("document.head.appendChild(script);");
                sb.Append("</script>");
                ClientScriptManager csm = this.Page.ClientScript;
                if (!csm.IsClientScriptBlockRegistered("JSScriptBlock_"+ this.ReactRootElement))
                {
                    csm.RegisterClientScriptBlock(this.GetType(), "JSScriptBlock_" + this.ReactRootElement, sb.ToString());
                } */
            }

        }
    }
}
