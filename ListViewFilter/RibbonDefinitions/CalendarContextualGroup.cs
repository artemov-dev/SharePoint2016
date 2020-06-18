using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Utilities;

namespace ListViewFilter.RibbonDefinitions
{
    public static partial class ContextualGroups
    {
        public static ContextualGroup CalendarContextualGroup = new ContextualGroup
        {
            Id = "Ribbon.Calendar",
            Title = SPUtility.GetLocalizedString("$Resources:core,cui_CalendarContexualGroupTitle;", "core", LCID),
            Tabs = new[]
            {
                new RibbonTab
                {
                    Id = "Ribbon.Calendar.Events",
                    Title = SPUtility.GetLocalizedString("$Resources:core,cui_EventsTabTitle;", "core", LCID),
                    Groups = new[]
                    {
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Events.New",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpNew;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Events.New.NewListItem",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButNewEvent;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Events.Manage",
                            Title = SPUtility.GetLocalizedString("$Resources:core,GrpManage;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Events.Manage.ViewProperties",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButViewEvent;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Events.Manage.EditProperties",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButEditEvent;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Events.Manage.ViewVersions",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButVersionHistory;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Events.Manage.ManagePermissions",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButEventPermissions;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Events.Manage.Delete",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButDeleteEvent;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Events.Actions",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpActions;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Events.Actions.AttachFile",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButAttachFile;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Events.Share",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpShare;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Events.Share.AlertMe",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButAlertMe;", "core", LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Events.Workflow",
                            Title = SPUtility.GetLocalizedString("$Resources:core,GrpWorkflow;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Events.Workflow.ViewWorkflows",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButWorkflows;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Events.Workflow.Moderate",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButApproveReject;", "core",
                                            LCID),
                                },
                            }
                        },
                    }
                },
                new RibbonTab
                {
                    Id = "Ribbon.Calendar.Calendar",
                    Title = SPUtility.GetLocalizedString("$Resources:core,cui_CalendarTabTitle;", "core", LCID),
                    Groups = new[]
                    {
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Calendar.Selector",
                            Title =
                                SPUtility.GetLocalizedString("$Resources:core,cui_CalendarSelectorGroupTitle;",
                                    "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Selector.People",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_CalendarPeople;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Selector.Resource",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_CalendarResource;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Calendar.Scope",
                            Title =
                                SPUtility.GetLocalizedString("$Resources:core,cui_CalendarScopeGroupTitle;", "core",
                                    LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Scope.DayGroup",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_CalendarScopeDayGroup;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Scope.WeekGroup",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_CalendarScopeWeekGroup;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Scope.Day",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_CalendarScopeDay;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Scope.Week",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_CalendarScopeWeek;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Scope.Month",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_CalendarScopeMonth;",
                                            "core", LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Calendar.Expander",
                            Title =
                                SPUtility.GetLocalizedString("$Resources:core,cui_CalendarExpandarGroupTitle;",
                                    "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Expander.ExpandAll",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_CalendarExpand;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Expander.CollapseAll",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_CalendarCollapse;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Calendar.CustomViews",
                            Title =
                                SPUtility.GetLocalizedString("$Resources:core,cui_GrpManageViews;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.CustomViews.AddCalendar",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_CalendarAddCalendar;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.CustomViews.CreateView",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButCreateView;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.CustomViews.ModifyView",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButModifyThisView;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.CustomViews.CreateColumn",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButCreateColumn;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.CustomViews.CurrentView",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButCurrentView;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.CustomViews.DisplayView",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButViewSelector;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Calendar.Share",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpShare;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Share.EmailLibraryLink",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButEmailLink;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Share.AlertMe",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButAlertMe;", "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Share.ViewRSSFeed",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButViewRSSFeed;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Calendar.Actions",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpConnect;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Actions.ConnectToClient",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButConnectToClient;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Actions.ExportToSpreadsheet",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButExportToSpreadsheet;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Actions.OpenWithAccess",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButOpenWithAccess;",
                                            "core", LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Calendar.CustomizeList",
                            Title =
                                SPUtility.GetLocalizedString("$Resources:core,cui_GrpCustomizeList;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.CustomizeList.EditList",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButEditList;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.CustomizeList.EditDefaultForms",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButEditDefaultForms;",
                                            "core", LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Calendar.Calendar.Settings",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpSettings;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Settings.ListSettings",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButListSettings;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Settings.ManageWorkflows",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButManageWorkflow;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Calendar.Calendar.Settings.ListPermissions",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButListPermissions;",
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
