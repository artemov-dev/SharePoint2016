using Microsoft.SharePoint;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using ArtDev;

namespace ContentType.Features.Feature_Content_Type
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("dbdd5ff4-f9a8-4580-93a3-2256dff11971")]
    public class Feature_Content_TypeEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            ArtDevFeature Feature = new ArtDevFeature(properties);

            //Amount 
            ArtDevField amountField = Feature.CreateFieldCurrency("Amount")
                .SetTitle("Количество")
                .SetDisplayFormat(SPNumberFormatTypes.TwoDecimals)
                .SetMinimumValue(0);

            // Client Name       
            ArtDevField clientField = Feature.CreateFieldText("ClientName")
                .SetTitle("Имя Клиента");

            // Date Opened            
            ArtDevField dateOpenedField = Feature.CreateFieldDateTime("DateOpened")
                .SetTitle("Дата открытия")
                .SetDisplayFormat(SPDateTimeFieldFormatType.DateOnly)
                .SetDefaultValue("[today]");

            // Cost Center Name           
            ArtDevField costCenterField = Feature.CreateFieldChoice("CostCenter")
                .SetChoices("Administration", "Information Services", "Facilities", "Operations", "Sales", "Marketing")
                .SetTitle("Центр затрат");

            ArtDevField EmployeeField = Feature.CreateFieldUser("FIOEmployee")
                .SetTitle("ФИО Сотрудников").SetMultipleValue(false);

            ArtDevField ActiveSiteField = Feature.CreateFieldLookup("ActiveSite", "SiteAssets")
                .SetTitle("Активы сайта").SetMultipleValue(false).SetLookupField("Title");

            ArtDevField SettingValueField = Feature.CreateFieldText("SettingValue")
                .SetTitle("Значение");
                

            /* CREATE SITE CONTENT TYPES */

            // Create the Financial Document
            ArtDevContentType financialDocumentCType = Feature.CreateContentType("Financial Document", SPBuiltInContentTypeId.Document)
                .RemoveOldLinks()
                .AddFieldLink(dateOpenedField).SetRequired(true).Commit()
                .AddFieldLink(amountField).Commit();

            // Create the Invoice content type.
            ArtDevContentType invoiceCType = Feature.CreateContentType("Invoice", financialDocumentCType.type.Id)
                .RemoveOldLinks()
                .GetFieldLink(SPBuiltInFieldId.Title).SetDisplayName("Service").SetRequired(true).Commit()                
                .AddFieldLink(clientField).SetRequired(true).Commit()
                .SetDocumentTemplate("/ArtDevTemplates/Invoice.docx").Commit();

            // Create the Purchase Order content type.
            ArtDevContentType purchaseOrderCType = Feature.CreateContentType("Purchase Order", financialDocumentCType.type.Id)
                .RemoveOldLinks()
                .GetFieldLink(SPBuiltInFieldId.Title).SetDisplayName("Item").SetRequired(true).Commit()
                .AddFieldLink(costCenterField).SetDisplayName("Department").SetRequired(true).Commit()
                .SetDocumentTemplate("/ArtDevTemplates/PurchaseOrder.docx").Commit();

            ArtDevContentType CTypeOrder = Feature.CreateContentType("Orders", SPBuiltInContentTypeId.Item)
               .RemoveOldLinks()
               .GetFieldLink(SPBuiltInFieldId.Title).SetDisplayName("ФИО Клиента").SetRequired(true).Commit()               
               .AddFieldLink(clientField).SetRequired(true).Commit()
               .AddFieldLink(dateOpenedField).SetRequired(true).Commit()
               .AddFieldLink(amountField).SetRequired(false).Commit()
               .AddFieldLink(EmployeeField).SetRequired(true).Commit()
               .AddFieldLink(costCenterField).SetRequired(true).Commit()
             //  .AddFieldLink(ActiveSiteField).SetRequired(true).Commit()
               ;



            /* CREATE SITE LISTS BY CONTENT TYPE */
            ArtDevList DocumentList = Feature.CreateDocumentLibrary("ArtDevDocument")
                .SetListTitle("ArtDev Документы")
                .RemoveStandartContentType()
                .addContentType(invoiceCType);


            ArtDevList OrderList = Feature.CreateList("Orders")
                .SetListTitle("ArtDev Заказы")
                .RemoveStandartContentType()
                .addContentType(CTypeOrder)
                .GetFieldLink(SPBuiltInFieldId.Title).SetFieldTitle("ФИО Клиента").Commit()
                .AddFieldLink(ActiveSiteField).SetFieldTitle("Активы сайтов").Commit();

            
            // Name Template equal Name list
            ArtDevList ArtDevForms = Feature.CreateListTemplate("ArtDevForms")
                .SetListTitle("ArtDev Формы")
                .RemoveStandartContentType()
                .addContentType(CTypeOrder)
                .GetFieldLink(SPBuiltInFieldId.Title).SetFieldTitle("ФИО Клиента").Commit();



            ArtDevList ListSetting = Feature.CreateList("ArtDevSettings")
                .SetListTitle("ArtDev Настройки")
                .GetFieldLink(SPBuiltInFieldId.Title).SetFieldTitle("Параметр").SetFieldRequired(true).Commit()
                .AddFieldLink(SettingValueField).SetFieldRequired(true).Commit()
                .GetItemByTitle("URL2").SetItem(SettingValueField.field.Id, "http://{url}").Commit()
                .GetItem(SettingValueField.field.Id, "http://{url}").SetItem(SPBuiltInFieldId.Title, "URL").Commit()
                .AddItemIfNotExsist("URL2", "http://").Commit()
                ; 
            

            

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
