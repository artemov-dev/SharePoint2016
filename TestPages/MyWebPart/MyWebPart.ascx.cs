using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;



namespace TestPages.MyWebPart
{
    [ToolboxItemAttribute(false)]
    public partial class MyWebPart : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public MyWebPart()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("hh:mm:ss tt");
            string script = "window.onload = function() { UpdateLblTest('" + time + "'); };";
            ClientScriptManager csm = this.Page.ClientScript;
            if (!csm.IsStartupScriptRegistered(this.GetType(), "UpdateLblTest"))
            {
                csm.RegisterStartupScript(this.GetType(), "UpdateLblTest", script, true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
       

    }

    
}
