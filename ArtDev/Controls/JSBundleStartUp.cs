using Microsoft.SharePoint;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ArtDev.Controls
{
    public class JSBundleStartUp : UserControl
    {
        public string JSBundleFile { get; set; }

        protected override void CreateChildControls()
        {
            string mode = (string)SPContext.Current.Web.AllProperties["DEV"] ?? null;
            string filename = this.JSBundleFile.Substring(this.JSBundleFile.LastIndexOf('/') + 1);
            string file = mode == "true" ? "http://localhost:3000/public/" + filename : this.JSBundleFile;

            ClientScriptManager csm = this.Page.ClientScript;
            //Render the function invocation. 
            string funcCall = "<script src='" + file + "' language='javascript'></script>";

            if (!csm.IsStartupScriptRegistered("JSScript_" + filename))
            {
                csm.RegisterStartupScript(this.GetType(), "JSScript_" + filename, funcCall);
            }
        }

    }
    
}
