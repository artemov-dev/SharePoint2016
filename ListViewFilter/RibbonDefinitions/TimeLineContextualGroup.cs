using Microsoft.SharePoint.Utilities;

namespace ListViewFilter.RibbonDefinitions
{
    public static partial class ContextualGroups
    {
        public static ContextualGroup TimeLineContextualGroup =

            new ContextualGroup
            {
                Id = "Ribbon.ContextualTabs.Timeline",
                Title = SPUtility.GetLocalizedString("$Resources:core,TimelineGroupTabTitle;", "core", LCID),
                Tabs = new[]
                {
                    new RibbonTab
                    {
                        Id = "Ribbon.Timeline",
                        Title = SPUtility.GetLocalizedString("$Resources:core,TimelineTabTitle;", "core", LCID),
                        Groups = new[]
                        {
                            new RibbonGroup
                            {
                                Id = "Ribbon.Timeline.EditFont",
                                Title = SPUtility.GetLocalizedString("$Resources:core,GrpFont;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.EditFont.Fonts",
                                        Title = SPUtility.GetLocalizedString("$Resources:core,FontAlt;", "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.EditFont.FontSize",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,FontSizeAlt;", "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.EditFont.Bold",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,ButBoldTitle;", "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.EditFont.Italics",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,ButItalicsTitle;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.EditFont.Underline",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,ButUnderlineTitle;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.EditFont.Strikethrough",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,ButStrikethroughAlt;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.EditFont.Subscript",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,ButSubscriptAlt;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.EditFont.Superscript",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,ButSuperscriptAlt;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.EditFont.FontBackgroundColor",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,HighlightColorAlt;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.EditFont.FontColor",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,FontColorAlt;", "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.EditFont.ClearFormat",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,ButClearFormatTitle;", "core",
                                                LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.Timeline.ShowHide",
                                Title =
                                    SPUtility.GetLocalizedString("$Resources:core,TLShowHideGroupTitle;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.ShowHide.Dates",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,TLShowDatesLabel;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.ShowHide.ShowProjSummDates",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,TLShowProjSummDatesLabel;",
                                                "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.ShowHide.Today",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,TLShowTodayLabel;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.ShowHide.Timescale",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,TLShowTimescaleLabel;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.ShowHide.DateFmt",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,TLDateFmtLabel;", "core", LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.Timeline.Action",
                                Title =
                                    SPUtility.GetLocalizedString("$Resources:core,TLActionGroupTitle;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.Action.FixTLWidth",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,TLActionFixTLWidthLabel;",
                                                "core", LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.Timeline.CurrentSel",
                                Title =
                                    SPUtility.GetLocalizedString("$Resources:core,TLCurSelGroupTitle;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.ShowHide.DispBar",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,TLDispBarLabel;", "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.CurrentSel.DispCallout",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,TLDispCalloutLabel;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.Timeline.CurrentSel.Remove",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,TLRemoveLabel;", "core", LCID),
                                    },
                                }
                            },
                        }
                    },
                }
            };
    }
}