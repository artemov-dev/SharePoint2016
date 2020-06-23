using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.Script.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using System.Linq;

namespace TestPages.WebPartPages
{
    public partial class GetDatabase : WebPartPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
                IEnumerable<databases> databases = common.GetContentDataBases();
                JavaScriptSerializer oSerializer = new JavaScriptSerializer();
                string d = oSerializer.Serialize(databases);            
                string script = "window.onload = function() { StartupScriptRegister('" + d + "'); };";
                ClientScriptManager csm = this.Page.ClientScript;
                if (!csm.IsStartupScriptRegistered(this.GetType(), "StartupScriptRegister"))
                {
                    csm.RegisterStartupScript(this.GetType(), "StartupScriptRegister", script, true);
                }         


        }

       
    }
    
}
