using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator.WingtipCalcWebPart
{
    [ToolboxItemAttribute(false)]
    public class WingtipCalcWebPart : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
      private const string _ascxPath = @"~/_CONTROLTEMPLATES/CriticalPath.SharePoint.Samples.WingtipCalculator/WingtipCalcWebPart/WingtipCalcWebPartUserControl.ascx";

        protected override void CreateChildControls()
        {
            Control control = this.Page.LoadControl(_ascxPath);
            Controls.Add(control);
            base.CreateChildControls();
        }
    }
}
