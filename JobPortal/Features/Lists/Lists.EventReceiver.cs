using Microsoft.SharePoint;
using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using ArtDev;

namespace JobPortal.Features.Lists
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("9f4d3ab0-84b4-4d32-b697-038b13d4fe41")]
    public class ListsEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            ArtDevFeature feature = new ArtDevFeature(properties);

            ArtDevField FieldMenu2Level = feature.CreateFieldText("Menu2Level").SetTitle("Меню второго уровня");
            ArtDevField FieldMenuLink = feature.CreateFieldText("MenuLink").SetTitle("Ссылка в меню");
            ArtDevField FieldMenuOrderNumber = feature.CreateFieldNumber("MenuOrderNumber").SetTitle("Порядковый номер");


            feature.CreateList("ArtDevHeaderMenu").SetListTitle("ArtDev меню")
                .GetFieldLink(SPBuiltInFieldId.Title).SetFieldTitle("Меню первого уровня").SetFieldRequired(true).Commit()  
                .AddFieldLink(FieldMenu2Level).SetFieldRequired(false).Commit()
                .AddFieldLink(FieldMenuLink).Commit()
                .AddFieldLink(FieldMenuOrderNumber).SetFieldRequired(false).Commit()
                .CreateListView("VewTable", true)
                .ClearItemsIfModeDev()
                .AddItemIfModeDevOrFirstDeploy("Home", "" ,"/", "1")
                .AddItemIfModeDevOrFirstDeploy("Jobs", "", "#", "2")
                .AddItemIfModeDevOrFirstDeploy("Candidates", "", "#", "3")
                .AddItemIfModeDevOrFirstDeploy("Employers", "", "#", "4")
                .AddItemIfModeDevOrFirstDeploy("Blog", "", "#", "5")
                .AddItemIfModeDevOrFirstDeploy("Pages", "" ,"#", "6")
                .AddItemIfModeDevOrFirstDeploy("Home", "Header layout 1", "index.html", "1")
                .AddItemIfModeDevOrFirstDeploy("Home", "Header layout 2", "index2.html", "2")
                .AddItemIfModeDevOrFirstDeploy("Home", "Header layout 3", "index3.html", "3")
                .AddItemIfModeDevOrFirstDeploy("Home", "Header layout 4", "index4.html", "4")
                ;

            ArtDevList ArtDevSitePagesLibrary = feature.CreateDocumentLibrary("ArtDevPages")
                .SetListTitle("ArtDev Страницы")
                .RemoveStandartContentType()
                .addContentType(SPBuiltInContentTypeId.WebPartPage)
                .addContentType(SPBuiltInContentTypeId.WikiDocument);

        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
