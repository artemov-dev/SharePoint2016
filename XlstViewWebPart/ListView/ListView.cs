using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebControls;
using WebPart = System.Web.UI.WebControls.WebParts.WebPart;

namespace XlstViewWebPart.ListView
{
    [ToolboxItemAttribute(false)]
    public class ListView : WebPart
    {
        protected override void CreateChildControls()
        {
            XsltListViewWebPart wp = new XsltListViewWebPart();
            this.Controls.Add(wp);

        }
    }
}
