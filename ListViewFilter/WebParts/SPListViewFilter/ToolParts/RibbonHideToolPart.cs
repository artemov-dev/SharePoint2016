using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListViewFilter.Extensions;
using Microsoft.SharePoint.WebPartPages;

namespace ListViewFilter.WebParts.SPListViewFilter.ToolParts
{
    public sealed class RibbonHideToolPart : ToolPart
    {
        public RibbonHideToolPart()
        {
            Title = this.LocalizedString("ToolTip_RibbonHide");
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            var rootNodes = Ribbon.GetContextualGroups(WebPart);
            foreach (var contextualGroup in rootNodes)
            {
                Controls.Add(new CheckBox
                {
                    Text = contextualGroup.Title,
                    Checked = WebPart.IsRibbonElementHidden(contextualGroup.Id),
                    ToolTip = contextualGroup.Id,
                    CssClass = "splistviewfilter-cb-cg"
                });
                if (contextualGroup.Tabs != null)
                {
                    foreach (var tab in contextualGroup.Tabs)
                    {
                        Controls.Add(new CheckBox
                        {
                            Text = tab.Title,
                            Checked = WebPart.IsRibbonElementHidden(tab.Id),
                            ToolTip = tab.Id,
                            CssClass = "splistviewfilter-cb-t"
                        });
                        if (tab.Groups != null)
                        {
                            foreach (var ribbonGroup in tab.Groups)
                            {
                                Controls.Add(new CheckBox
                                {
                                    Text = ribbonGroup.Title,
                                    Checked = WebPart.IsRibbonElementHidden(ribbonGroup.Id),
                                    ToolTip = ribbonGroup.Id,
                                    CssClass = "splistviewfilter-cb-g"
                                });
                                if (ribbonGroup.Elements != null)
                                {
                                    foreach (var element in ribbonGroup.Elements)
                                    {
                                        Controls.Add(new CheckBox
                                        {
                                            Text = element.Title,
                                            Checked = WebPart.IsRibbonElementHidden(element.Id),
                                            ToolTip = element.Id,
                                            CssClass = "splistviewfilter-cb-e"
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Controls.Add(new LiteralControl(@"<style>
.splistviewfilter-cb-cg{display:block; font-weight: bold;}
.splistviewfilter-cb-t{display:block; margin-left: 10px; border-left: 1px solid red;}
.splistviewfilter-cb-g{display:block; margin-left: 20px; border-left: 1px solid orange;}
.splistviewfilter-cb-e{display:block; margin-left: 30px; font-style: italic; border-left: 1px solid gray;}
</style>"));
        }

        private SPListViewFilter WebPart
        {
            get
            {
                return WebPartToEdit as SPListViewFilter;
            }
        }
        public override void ApplyChanges()
        {
            base.ApplyChanges();
            WebPart.RibbonHiddenElements = Controls
                .OfType<CheckBox>()
                .Where(x => x.Checked)
                .Select(x => x.ToolTip)
                .ToArray();
        }
    }
}
