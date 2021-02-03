using Microsoft.SharePoint;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ArtDev.Controls
{
    public class JSBundleChunk : UserControl
    {
        public string JSBundleFile { get; set; }

       
        protected override void CreateChildControls()
        {          
            string mode = (string)SPContext.Current.Web.AllProperties["DEV"] ?? null;
            if (mode != "true")
            {
                string file = this.JSBundleFile;

                HtmlGenericControl script = new HtmlGenericControl("script");
                script.Attributes.Add("type", "text/javascript");
                script.Attributes.Add("src", file);
                this.Controls.AddAt(0, script);
            }
        }
    }
}
