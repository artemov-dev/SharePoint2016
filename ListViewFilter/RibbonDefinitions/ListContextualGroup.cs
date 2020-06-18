using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace ListViewFilter.RibbonDefinitions
{
    public static partial class ContextualGroups
    {
        public static ContextualGroup ListContextualGroup = new ContextualGroup
        {
            Id = "Ribbon.ListContextualGroup",
            Title = SPUtility.GetLocalizedString("$Resources:core,cui_ContextualTabList", "core", LCID),
            Tabs = new[]
                {
                    new RibbonTab
                    {
                        Id = "Ribbon.ListItem",
                        Title = SPUtility.GetLocalizedString("$Resources:core,cui_TabItems;", "core", LCID),
                        Groups = new[]
                        {
                            new RibbonGroup
                            {
                                Id = "Ribbon.ListItem.New",
                                Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpNew;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.New.NewListItem",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButNewItem;", "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.New.NewFolder",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButNewFolder;", "core",
                                                LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.ListItem.Manage",
                                Title = SPUtility.GetLocalizedString("$Resources:core,GrpManage;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Manage.ViewProperties",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButViewItem;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Manage.EditProperties",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButEditItem;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Manage.ViewVersions",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButVersionHistory;",
                                                "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Manage.ManagePermissions",
                                        Title =
                                            SPUtility.GetLocalizedString(
                                                "$Resources:core,cui_ButListFormDisplaySharedWith;", "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Manage.Delete",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButDeleteItem;", "core",
                                                LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.ListItem.Hierarchy",
                                Title =
                                    SPUtility.GetLocalizedString("$Resources:core,cui_GrpItemHierarchy;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Hierarchy.Outdent",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButItemOutdent;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Hierarchy.Indent",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButItemIndent;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Hierarchy.ShowSubitems",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButItemShowSubItems;",
                                                "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Hierarchy.HideSubItems",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButItemHideSubItems;",
                                                "core", LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.ListItem.Actions",
                                Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpActions;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Actions.AttachFile",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButAttachFile;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Actions.ChangeItemOrder",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButChangeItemOrder;",
                                                "core", LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.ListItem.Share",
                                Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpShare;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Share.AlertMe",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButAlertMe;", "core", LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.ListItem.Workflow",
                                Title = SPUtility.GetLocalizedString("$Resources:core,GrpWorkflow;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Workflow.ViewWorkflows",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButWorkflows;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.ListItem.Workflow.Moderate",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButApproveReject;", "core",
                                                LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.ListItem.QuickSteps",
                                Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpQuickSteps;", "core", LCID)
                            },
                        }
                    },
                    new RibbonTab
                    {
                        Id = "Ribbon.List",
                        Title = SPUtility.GetLocalizedString("$Resources:core,cui_TabList;", "core", LCID),
                        Groups = new[]
                        {
                            new RibbonGroup
                            {
                                Id = "Ribbon.List.ViewFormat",
                                Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpViewFormat;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.ViewFormat.Standard",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButStandardView15;",
                                                "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.ViewFormat.Datasheet",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButInlineEditView15;",
                                                "core", LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.List.Datasheet",
                                Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpDatasheet;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Datasheet.NewRow",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButNewRow;", "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Datasheet.ShowTaskPane",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButShowTaskPane", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Datasheet.ShowTotals",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButShowTotals;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Datasheet.RefreshData",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButRefreshData;", "core",
                                                LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.List.GanttView",
                                Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpGanttView;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.GanttView.ZoomIn",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButGanttZoomIn;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.GanttView.ZoomOut",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButGanttZoomOut;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.GanttView.ScrollToTask",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButGanttScrollToTask;",
                                                "core", LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.List.CustomViews",
                                Title =
                                    SPUtility.GetLocalizedString("$Resources:core,cui_GrpManageViews;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Actions.AllMeetings",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButAllMeetings;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomViews.CreateView",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButCreateView;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomViews.ModifyView",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButModifyThisView;",
                                                "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomViews.CreateColumn",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButCreateColumn;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomViews.NavigateUp",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButNavigateUp;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomViews.CurrentView",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButCurrentView;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomViews.DisplayView",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButViewSelector;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomViews.PreviousPage",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButPreviousPage;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomViews.CurrentPage",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButCurrentPage;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomViews.NextPage",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButNextPage;", "core",
                                                LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.List.Share",
                                Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpShare;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Share.EmailLibraryLink",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButEmailLink;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Share.AlertMe",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButAlertMe;", "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Share.ViewRSSFeed",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButViewRSSFeed;", "core",
                                                LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.List.Actions",
                                Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpConnect;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Actions.ConnectToClient",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButConnectToClient;",
                                                "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Actions.ExportToSpreadsheet",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButExportToSpreadsheet;",
                                                "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Actions.OpenWithAccess",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButOpenWithAccess;",
                                                "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Actions.ExportToProject",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButSyncWithProject;",
                                                "core", LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.List.CustomizeList",
                                Title =
                                    SPUtility.GetLocalizedString("$Resources:core,cui_GrpCustomizeList;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomizeList.EditDefaultForms",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButEditDefaultForms;",
                                                "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomizeList.EditList",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButEditList;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.CustomizeList.AddButton",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButAddButton;", "core",
                                                LCID),
                                    },
                                }
                            },
                            new RibbonGroup
                            {
                                Id = "Ribbon.List.Settings",
                                Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpSettings;", "core", LCID),
                                Elements = new[]
                                {
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Settings.ListSettings",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButListSettings;", "core",
                                                LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Settings.ListPermissions",
                                        Title =
                                            SPUtility.GetLocalizedString(
                                                "$Resources:core,cui_ButListFormDisplaySharedWith;", "core", LCID),
                                    },
                                    new RibbonElement
                                    {
                                        Id = "Ribbon.List.Settings.ManageWorkflows",
                                        Title =
                                            SPUtility.GetLocalizedString("$Resources:core,cui_ButManageWorkflow;",
                                                "core", LCID),
                                    },
                                }
                            },
                        }
                    },
                }
        };
    }
}
