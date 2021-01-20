using Microsoft.SharePoint;
using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using ArtDev;

namespace JobPortal.Features.MasterPage
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("dcd676d2-2762-4180-b552-dbf17a3e74b1")]
    public class MasterPageEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            ArtDevFeature feature = new ArtDevFeature(properties);
            feature.MDSDisable()
                .ActivateMasterPage("/_catalogs/masterpage/JobPortal.master")
                .SetHomePage("ArtDevPages/MainPages.aspx")
                ;
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            ArtDevFeature feature = new ArtDevFeature(properties);
            feature.ActivateMasterPage("/_catalogs/masterpage/seattle.master");
        }


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
