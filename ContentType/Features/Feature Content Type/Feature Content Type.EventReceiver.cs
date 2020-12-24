using Microsoft.SharePoint;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;

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
            SPFieldCurrency amountField = Feature.NewOrRefCurrency("Amount");
            amountField.Title = "Количество";
            amountField.DisplayFormat = SPNumberFormatTypes.TwoDecimals;
            amountField.MinimumValue = 0;
            amountField.Update();

            // Client Name            
            SPFieldText clientField = Feature.NewOrRefText("ClientName");            
            clientField.Title = "Имя Клиента";
            clientField.Update();

            // Date Opened            
            SPFieldDateTime dateOpenedField = Feature.NewOrRefDateTime("DateOpened");
            dateOpenedField.DisplayFormat = SPDateTimeFieldFormatType.DateOnly;
            dateOpenedField.DefaultValue = "[today]";
            dateOpenedField.Title = "Дата открытия";
            dateOpenedField.Update();

            // Cost Center Name           
            SPFieldChoice costCenterField = Feature.NewOrRefChoice("CostCenter");
            costCenterField.Choices.Add("Administration");
            costCenterField.Choices.Add("Information Services");
            costCenterField.Choices.Add("Facilities");
            costCenterField.Choices.Add("Operations");
            costCenterField.Choices.Add("Sales");
            costCenterField.Choices.Add("Marketing");
            costCenterField.Title = "Центр Затрат";
            costCenterField.Update();


            /* CREATE SITE CONTENT TYPES */
            SPContentType financialDocumentCType = Feature.NewOrRefContentType("Financial Document", SPBuiltInContentTypeId.Document);            

            // Add the Date Opened column. Child content types inherit the column.
            SPFieldLink dateOpenedFieldRef = new SPFieldLink(dateOpenedField);
            dateOpenedFieldRef.Required = true;
            financialDocumentCType.FieldLinks.Add(dateOpenedFieldRef);

            // Add the Amount column. Child content types inherit the column.
            SPFieldLink amountFieldRef = new SPFieldLink(amountField);            
            financialDocumentCType.FieldLinks.Add(amountFieldRef);

            // Commit changes.
            financialDocumentCType.Update();

            // Create the Invoice content type.
            SPContentType invoiceCType = Feature.NewOrRefContentType("Invoice", financialDocumentCType.Id);

            // Modify the Title column inherited from the parent.
            SPFieldLink serviceFieldRef = invoiceCType.FieldLinks[SPBuiltInFieldId.Title];
            serviceFieldRef.DisplayName = "Service";
            serviceFieldRef.Required = true;

            // Add the Client column.
            SPFieldLink clientFieldRef = new SPFieldLink(clientField);
            clientFieldRef.Required = true;
            invoiceCType.FieldLinks.Add(clientFieldRef);

            // Specify a document template.
            invoiceCType.DocumentTemplate = "/ArtDevTemplates/Invoice.docx";

            // Commit changes.
            invoiceCType.Update();

            // Create the Purchase Order content type.
            SPContentType purchaseOrderCType = Feature.NewOrRefContentType("Purchase Order", financialDocumentCType.Id);

            // Modify the Title column inherited from the parent.
            SPFieldLink itemFieldRef = purchaseOrderCType.FieldLinks[SPBuiltInFieldId.Title];
            itemFieldRef.DisplayName = "Item";
            itemFieldRef.Required = true;

            // Add the Department column.
            SPFieldLink departmentFieldRef = new SPFieldLink(costCenterField);
            departmentFieldRef.DisplayName = "Department";
            departmentFieldRef.Required = true;
            purchaseOrderCType.FieldLinks.Add(departmentFieldRef);

            // Specify a document template.
            purchaseOrderCType.DocumentTemplate = "/ArtDevTemplates/PurchaseOrder.docx";

            // Commit changes.
            purchaseOrderCType.Update();

            /* CREATE SITE LISTS BY CONTENT TYPE */
            SPList document = Feature.NewOrRefLibrary("ArtDevDocuments");
            document.Title = "ArtDev Документы";
            ArtDevList list = new ArtDevList(document);            
            list.addContentType(invoiceCType);            
            list.removeContentTypeID(SPBuiltInContentTypeId.Document);

            SPList ArtDevForms = Feature.NewOrRefListTemplate("ArtDevForms");

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
