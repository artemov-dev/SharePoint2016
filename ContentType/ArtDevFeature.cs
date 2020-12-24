using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentType
{
    public class ArtDevFeature
    {
        private SPWeb web = null;
        private SPSite site = null;
        private string columnGroup = "ArtDev";
        private string contentTypeGroup = "ArtDev Types";
        public List<SPField> Fields = null;


        public ArtDevFeature(SPFeatureReceiverProperties properties)
        {
            this.web = null;
            if (properties.Feature.Parent is SPSite)
            {
                this.site = (SPSite)properties.Feature.Parent;
                this.web = this.site.RootWeb;
            }
            else
            {
                this.web = (SPWeb)properties.Feature.Parent;
            }
            if (this.web == null)
                return;
        }

        public SPFieldCurrency NewOrRefCurrency(string Name)
        {
            string CurrencyName = this.web.Fields.ContainsField(Name) ? Name : this.web.Fields.Add(Name, SPFieldType.Currency, false);
            SPFieldCurrency CurrencyField = (SPFieldCurrency)this.web.Fields.GetFieldByInternalName(CurrencyName);
            CurrencyField.Group = this.columnGroup;
            return CurrencyField;
        }

        public SPFieldText NewOrRefText(string Name)
        {
            string TextName = this.web.Fields.ContainsField(Name) ? Name : web.Fields.Add(Name, SPFieldType.Text, false);
            SPFieldText TextField = (SPFieldText)web.Fields.GetFieldByInternalName(TextName);
            TextField.Group = this.columnGroup;
            return TextField;
        }

        public SPFieldDateTime NewOrRefDateTime(string Name)
        {
            string DateTimeName = this.web.Fields.ContainsField(Name) ? Name : this.web.Fields.Add(Name, SPFieldType.DateTime, false);
            SPFieldDateTime DateTimeField = (SPFieldDateTime)this.web.Fields.GetFieldByInternalName(DateTimeName);
            DateTimeField.Group = this.columnGroup;
            return DateTimeField;
        }

        public SPFieldChoice NewOrRefChoice(string Name)
        {
            string ChoiceName = this.web.Fields.ContainsField(Name) ? Name : this.web.Fields.Add(Name, SPFieldType.Choice, false);
            SPFieldChoice ChoiceField = (SPFieldChoice)this.web.Fields.GetFieldByInternalName(ChoiceName);
            ChoiceField.Group = this.columnGroup;
            return ChoiceField;
        }

        public SPFieldMultiLineText NewOrRefMultiLineText(string Name)
        {
            string NoteName = this.web.Fields.ContainsField(Name) ? Name : this.web.Fields.Add(Name, SPFieldType.Note, false);
            SPFieldMultiLineText NoteField = (SPFieldMultiLineText)this.web.Fields.GetFieldByInternalName(NoteName);
            NoteField.Group = this.columnGroup;
            return NoteField;
        }
        public SPFieldBoolean NewOrRefBoolean(string Name)
        {
            string BooleanName = this.web.Fields.ContainsField(Name) ? Name : this.web.Fields.Add(Name, SPFieldType.Boolean, false);
            SPFieldBoolean BooleanField = (SPFieldBoolean)this.web.Fields.GetFieldByInternalName(BooleanName);
            BooleanField.Group = this.columnGroup;
            return BooleanField;
        }
        public SPFieldUser NewOrRefUser(string Name)
        {
            string UserName = this.web.Fields.ContainsField(Name) ? Name : this.web.Fields.Add(Name, SPFieldType.User, false);
            SPFieldUser UserField = (SPFieldUser)this.web.Fields.GetFieldByInternalName(UserName);
            UserField.Group = this.columnGroup;
            return UserField;
        }
        public SPFieldUrl NewOrRefURL(string Name)
        {
            string URLName = this.web.Fields.ContainsField(Name) ? Name : this.web.Fields.Add(Name, SPFieldType.URL, false);
            SPFieldUrl URLField = (SPFieldUrl)this.web.Fields.GetFieldByInternalName(URLName);
            URLField.Group = this.columnGroup;
            return URLField;
        }
        public SPFieldLookup NewOrRefLookup(string Name)
        {
            string LookupName = this.web.Fields.ContainsField(Name) ? Name : this.web.Fields.Add(Name, SPFieldType.Lookup, false);
            SPFieldLookup LookupField = (SPFieldLookup)this.web.Fields.GetFieldByInternalName(LookupName);
            LookupField.Group = this.columnGroup;
            return LookupField;
        }

        public SPContentType NewOrRefContentType(string Name, SPContentTypeId InheritedTypeID )
        {
            SPContentType InheritedCType = this.web.AvailableContentTypes[InheritedTypeID];
            SPContentType CType = this.web.AvailableContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(Name)) ?? new SPContentType(InheritedCType, this.web.ContentTypes, Name);
            // A content type is not initialized until after it is added
            CType = this.web.ContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(Name)) ?? this.web.ContentTypes.Add(CType);
            CType.Group = this.contentTypeGroup;
            return CType;
        }

        public SPList NewOrRefList(string Name)
        {            
            SPList list = this.web.Lists.Cast<SPList>().FirstOrDefault(c => c.EntityTypeName.Equals(Name+"List")) ?? null;
            if (list == null) { Guid id = this.web.Lists.Add(Name, null, SPListTemplateType.GenericList); list = this.web.Lists[id]; }
            list.ContentTypesEnabled = true;
            list.Update();
            return list;            
        }

        public SPList NewOrRefLibrary(string Name)
        {
            SPList Document = this.web.Lists.Cast<SPList>().FirstOrDefault(c => c.EntityTypeName.Equals(Name)) ?? null;              
            if (Document == null) { this.web.Lists.Add(Name, null, SPListTemplateType.DocumentLibrary); Document = this.web.Lists[Name]; }            
            Document.ContentTypesEnabled = true;
            Document.Update();
            return Document;
        }

        public SPList NewOrRefListTemplate(string Name)
        {
            SPList ListInstance = this.web.Lists.Cast<SPList>().FirstOrDefault(c => c.EntityTypeName.Equals(Name+"List")) ?? null;            
            if (ListInstance == null) { this.web.Lists.Add(Name, null, this.web.ListTemplates[Name]); ListInstance = this.web.Lists[Name]; }
            ListInstance.ContentTypesEnabled = true;
            ListInstance.Update();
            return ListInstance;
        }

    }
}
