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
        public static uint LCID = Convert.ToUInt32(SPContext.Current.Web.UICulture.LCID);

        public static ContextualGroup LibraryContextualGroup = new ContextualGroup
        {
            Id = "Ribbon.LibraryContextualGroup",
            Title = SPUtility.GetLocalizedString("$Resources:core,cui_ContextualTabLibrary", "core", LCID),
            Tabs = new[]
            {
                new RibbonTab
                {
                    Id = "Ribbon.Document",
                    Title = SPUtility.GetLocalizedString("$Resources:core,cui_TabDocuments_15;", "core", LCID),
                    Groups = new[]
                    {
                        new RibbonGroup
                        {
                            Id = "Ribbon.Documents.New",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpNew;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.New.NewDocument",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButNewDocument;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.New.AddDocument",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButUploadDocument;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.New.NewFolder",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButNewFolder;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Documents.EditCheckout",
                            Title =
                                SPUtility.GetLocalizedString("$Resources:core,cui_GrpOpenAndCheckout;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.EditCheckout.EditDocument",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButEditDocument;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.EditCheckout.CheckOut",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,ButCheckout;", "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.EditCheckout.CheckIn",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,ButCheckin;", "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.EditCheckout.DiscardCheckOut",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,ButDiscardCheckout;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Documents.Manage",
                            Title = SPUtility.GetLocalizedString("$Resources:core,GrpManage;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Manage.ViewProperties",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,ButViewProperties;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Manage.EditProperties",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,ButEditProperties;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Manage.ViewVersions",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,ButVersionHistory;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Manage.ManagePermissions",
                                    Title =
                                        SPUtility.GetLocalizedString(
                                            "$Resources:core,cui_ButListFormDisplaySharedWith;", "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Manage.Delete",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButDeleteDocument;",
                                            "core", LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Documents.Share",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpShare;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Share.ShareItem",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButShareItem;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Share.AlertMe",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButAlertMe;", "core", LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Documents.Copies",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpCopies;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Copies.Download",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButDownloadCopy;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Copies.SendTo",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButSendTo;", "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Copies.ManageCopies",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButManageCopies;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Copies.GoToSourceItem",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButGoToSource;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Documents.Workflow",
                            Title = SPUtility.GetLocalizedString("$Resources:core,GrpWorkflow;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Workflow.ViewWorkflows",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButWorkflows;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Workflow.Publish",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,ButPublish;", "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Workflow.Unpublish",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,ButUnpublish;", "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Workflow.Moderate",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButApproveReject;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.Workflow.CancelApproval",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButCancelApproval;",
                                            "core", LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Documents.QuickSteps",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpQuickSteps;", "core", LCID),
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Documents.FormActions",
                            Title = SPUtility.GetLocalizedString("$Resources:core,GrpFormActions;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.FormActions.RepairItems",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButRepairItems;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.FormActions.RepairAllItems",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButRepairAllItems;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Documents.FormActions.MergeDocuments",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButMergeDocuments;",
                                            "core", LCID),
                                },
                            }
                        },
                    }
                },
                new RibbonTab
                {
                    Id = "Ribbon.Library",
                    Title = SPUtility.GetLocalizedString("$Resources:core,cui_TabLibrary;", "core", LCID),
                    Groups = new[]
                    {
                        new RibbonGroup
                        {
                            Id = "Ribbon.Library.ViewFormat",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpViewFormat;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.ViewFormat.Standard",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButStandardView15;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.ViewFormat.Datasheet",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButInlineEditView15;",
                                            "core", LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Library.Datasheet",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpDatasheet;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Datasheet.NewRow",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButNewRow;", "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Datasheet.ShowTaskPane",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButShowTaskPane", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Datasheet.ShowTotals",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButShowTotals;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Datasheet.RefreshData",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButRefreshData;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Library.CustomViews",
                            Title =
                                SPUtility.GetLocalizedString("$Resources:core,cui_GrpManageViews;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Actions.AllMeetings",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButAllMeetings;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomViews.CreateView",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButCreateView;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomViews.ModifyView",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButModifyThisView;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomViews.CreateColumn",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButCreateColumn;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomViews.NavigateUp",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButNavigateUp;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomViews.CurrentView",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButCurrentView;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomViews.DisplayView",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButViewSelector;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomViews.PreviousPage",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButPreviousPage;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomViews.CurrentPage",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButCurrentPage;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomViews.NextPage",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButNextPage;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Library.Share",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpShare;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Share.EmailLibraryLink",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButEmailLink;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Share.AlertMe",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButAlertMe;", "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Share.ViewRSSFeed",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButViewRSSFeed;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Library.Actions",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpConnect;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Actions.ConnectToClient",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButConnectToClient;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Actions.ExportToSpreadsheet",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButExportToSpreadsheet;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Actions.OpenWithExplorer",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButOpenWithExplorer;",
                                            "core", LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Library.CustomizeLibrary",
                            Title =
                                SPUtility.GetLocalizedString("$Resources:core,cui_GrpCustomizeLibrary;", "core",
                                    LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomizeLibrary.EditDefaultForms",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButEditDefaultForms;",
                                            "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomizeLibrary.EditList",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButEditLibrary;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.CustomizeLibrary.AddButton",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButAddButton;", "core",
                                            LCID),
                                },
                            }
                        },
                        new RibbonGroup
                        {
                            Id = "Ribbon.Library.Settings",
                            Title = SPUtility.GetLocalizedString("$Resources:core,cui_GrpSettings;", "core", LCID),
                            Elements = new[]
                            {
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Settings.DocumentLibrarySettings",
                                    Title =
                                        SPUtility.GetLocalizedString("$Resources:core,cui_ButLibSettings;", "core",
                                            LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Settings.LibraryPermissions",
                                    Title =
                                        SPUtility.GetLocalizedString(
                                            "$Resources:core,cui_ButListFormDisplaySharedWith;", "core", LCID),
                                },
                                new RibbonElement
                                {
                                    Id = "Ribbon.Library.Settings.ManageWorkflows",
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
