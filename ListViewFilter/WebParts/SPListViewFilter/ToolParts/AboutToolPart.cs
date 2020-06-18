﻿using System.Web.UI;
using ListViewFilter.Extensions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;

namespace ListViewFilter.WebParts.SPListViewFilter.ToolParts
{
    ///<summary>
    ///</summary>
    public class AboutToolPart : ToolPart
    {
        ///<summary>
        ///</summary>
        public AboutToolPart()
        {
            Title = this.LocalizedString("ToolTip_About");
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            var lcid = SPContext.Current.Web.UICulture.LCID;
            Controls.Add(new LiteralControl(
                $@"<strong>SPListViewFilter 2.3</strong>
                      <p><strong>Author: </strong>Vitaly Zhukov</p>
                      <p><strong>Blog: </strong>
                        <a href=""http://blog.vitalyzhukov.ru/?ref=splistviewfilter22&lcid={
                    lcid}"" target=""_blank"">blog.vitalyzhukov.ru</a>
                      </p>"));
        }
    }
}
