using Microsoft.SharePoint;
using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using ArtDev;

namespace ArtDevLookupField.Features.ArtDevLookupField
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("2a51ec82-8e3d-4ce6-94b9-0a64b4dd365d")]
    public class ArtDevLookupFieldEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            ArtDevFeature feature = new ArtDevFeature(properties);
            ArtDevList ListAddress = feature.CreateList("ArtDevAddressEmp").SetListTitle("ArtDev Адреса")
                .GetFieldLink(SPBuiltInFieldId.Title).SetFieldTitle("Адрес").Commit()
                .AddOrUpdateItem("Москва, Ул. Маршала Воронова, 2а")
                .AddOrUpdateItem("Нижний Новгород, Авангардная, 11")
                .AddOrUpdateItem("Нижний Новгород, Тихорецкая, 10");

            ArtDevField FieldAddress = feature.CreateFieldLookup("FieldAddress", ListAddress.list.RootFolder.Url)
                .SetTitle("Адрес").SetLookupField("Title");
            ArtDevField FieldComment = feature.CreateFieldMultiLineText("Comment")
                .SetTitle("Комментарий");

            ArtDevList ListEmployee = feature.CreateList("ArtDevEmployee").SetListTitle("ArtDev сотрудники")
                .GetFieldLink(SPBuiltInFieldId.Title).SetFieldTitle("ФИО").Commit()
                .AddFieldLink(SPBuiltInFieldId.JobTitle).SetFieldTitle("Должность").Commit()
                .AddFieldLink(FieldAddress).Commit()
                .AddFieldLink(FieldComment).Commit()
                .AddOrUpdateItem("Иванов Иван Иванович", "Директор2")
                .AddOrUpdateItem("Петров Петр Петрович", "Бухгалтер")
                .AddOrUpdateItem("Сидоров Сидр Сидорович", "Рабочий");
            


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
