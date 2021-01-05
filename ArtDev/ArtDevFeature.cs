using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtDev
{
    public class ArtDevFeature
    {
        private SPWeb web = null;


        private SPSite site = null;
        private string columnGroup = "ArtDev";
        private string contentTypeGroup = "ArtDev Types";


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
                this.site = this.web.Site;
            }
            if (this.web == null)
                return;
        }        

        public SPWeb Web()
        {
            using (SPSite site = new SPSite(this.site.Url))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    return web;
                }
            }
        }

        public ArtDevList CreateDocumentLibrary(string Name)
        {            
            SPList Document = NewOrRefLibrary(Name);
            ArtDevList ArtDevDocument = new ArtDevList(Document);            
            return ArtDevDocument;

        }

        public ArtDevList CreateList(string Name)
        {
            SPList list = NewOrRefList(Name);
            ArtDevList ArtDevList = new ArtDevList(list);
            return ArtDevList;

        }

        public ArtDevList CreateListTemplate(string Name)
        {
            SPList list = NewOrRefListTemplate(Name);
            ArtDevList ArtDevList = new ArtDevList(list);
            return ArtDevList;

        }

        public ArtDevField CreateFieldCurrency(string Name)
        {
            SPFieldCurrency Field = NewOrRefCurrency(Name);
            ArtDevField ArtDevField = new ArtDevField(Field);
            return ArtDevField;
        }

        public ArtDevField CreateFieldText(string Name)
        {
            SPFieldText Field = NewOrRefText(Name);
            ArtDevField ArtDevField = new ArtDevField(Field);
            return ArtDevField;
        }

        public ArtDevField CreateFieldDateTime(string Name)
        {
            SPFieldDateTime Field = NewOrRefDateTime(Name);
            ArtDevField ArtDevField = new ArtDevField(Field);
            return ArtDevField;
        }

        public ArtDevField CreateFieldChoice(string Name)
        {
            SPFieldChoice Field = NewOrRefChoice(Name);
            ArtDevField ArtDevField = new ArtDevField(Field);
            return ArtDevField;
        }

        public ArtDevField CreateFieldUser(string Name)
        {
            SPFieldUser Field = NewOrRefUser(Name);            
            ArtDevField ArtDevField = new ArtDevField(Field);
            return ArtDevField;
        }

        public ArtDevField CreateFieldLookup(string Name, string ListUrl, string WebUrl = null)
        {
            SPList list = null; SPFieldLookup Field = null;
            if (WebUrl == null)
            {
                list = this.Web().GetList(ListUrl); 
                Field = NewOrRefLookup(Name, list);
            }
            else
            {
                using (SPSite site = new SPSite(this.site.Url))
                {
                    using (SPWeb web = site.OpenWeb(WebUrl))
                    {
                        list = web.GetList(ListUrl);
                        Field = NewOrRefLookup(Name, list, web);
                    }
                }
                
            }
            ArtDevField ArtDevField = new ArtDevField(Field);
            return ArtDevField;
        }

        public ArtDevContentType CreateContentType(string Name, SPContentTypeId parent)
        {
            SPContentType type = NewOrRefContentType(Name, parent);
            ArtDevContentType ArtDevType = new ArtDevContentType(type);
            return ArtDevType;
        }


        public SPFieldCurrency NewOrRefCurrency(string Name)
        {
            string CurrencyName = this.Web().Fields.ContainsField(Name) ? Name : this.Web().Fields.Add(Name, SPFieldType.Currency, false);
            SPFieldCurrency CurrencyField = (SPFieldCurrency)this.Web().Fields.GetFieldByInternalName(CurrencyName);
            CurrencyField.Group = this.columnGroup;
            return CurrencyField;
        }

        public SPFieldText NewOrRefText(string Name)
        {
            string TextName = this.Web().Fields.ContainsField(Name) ? Name : web.Fields.Add(Name, SPFieldType.Text, false);
            SPFieldText TextField = (SPFieldText)web.Fields.GetFieldByInternalName(TextName);
            TextField.Group = this.columnGroup;
            return TextField;
        }

        public SPFieldDateTime NewOrRefDateTime(string Name)
        {
            string DateTimeName = this.Web().Fields.ContainsField(Name) ? Name : this.Web().Fields.Add(Name, SPFieldType.DateTime, false);
            SPFieldDateTime DateTimeField = (SPFieldDateTime)this.Web().Fields.GetFieldByInternalName(DateTimeName);
            DateTimeField.Group = this.columnGroup;
            return DateTimeField;
        }

        public SPFieldChoice NewOrRefChoice(string Name)
        {
            string ChoiceName = this.Web().Fields.ContainsField(Name) ? Name : this.Web().Fields.Add(Name, SPFieldType.Choice, false);
            SPFieldChoice ChoiceField = (SPFieldChoice)this.Web().Fields.GetFieldByInternalName(ChoiceName);
            ChoiceField.Group = this.columnGroup;
            return ChoiceField;
        }

        public SPFieldMultiLineText NewOrRefMultiLineText(string Name)
        {
            string NoteName = this.Web().Fields.ContainsField(Name) ? Name : this.Web().Fields.Add(Name, SPFieldType.Note, false);
            SPFieldMultiLineText NoteField = (SPFieldMultiLineText)this.Web().Fields.GetFieldByInternalName(NoteName);
            NoteField.Group = this.columnGroup;
            return NoteField;
        }
        public SPFieldBoolean NewOrRefBoolean(string Name)
        {
            string BooleanName = this.Web().Fields.ContainsField(Name) ? Name : this.Web().Fields.Add(Name, SPFieldType.Boolean, false);
            SPFieldBoolean BooleanField = (SPFieldBoolean)this.Web().Fields.GetFieldByInternalName(BooleanName);
            BooleanField.Group = this.columnGroup;
            return BooleanField;
        }
        public SPFieldUser NewOrRefUser(string Name)
        {
            string UserName = this.Web().Fields.ContainsField(Name) ? Name : this.Web().Fields.Add(Name, SPFieldType.User, false);
            SPFieldUser UserField = (SPFieldUser)this.Web().Fields.GetFieldByInternalName(UserName);
            UserField.Group = this.columnGroup;
            return UserField;
        }
        public SPFieldUrl NewOrRefURL(string Name)
        {
            string URLName = this.Web().Fields.ContainsField(Name) ? Name : this.Web().Fields.Add(Name, SPFieldType.URL, false);
            SPFieldUrl URLField = (SPFieldUrl)this.Web().Fields.GetFieldByInternalName(URLName);
            URLField.Group = this.columnGroup;
            return URLField;
        }
        public SPFieldLookup NewOrRefLookup(string Name, SPList List, SPWeb web = null)
        {
            string LookupName = ""; SPFieldLookup LookupField = null;
            if (web == null) 
            { 
                LookupName = this.Web().Fields.ContainsField(Name) ? Name : this.Web().Fields.AddLookup(Name, List.ID, false);
                LookupField = (SPFieldLookup)this.Web().Fields.GetFieldByInternalName(LookupName);
            }
            else 
            { 
                LookupName = web.Fields.ContainsField(Name) ? Name : web.Fields.AddLookup(Name, List.ID, web.ID, false);
                LookupField = (SPFieldLookup)web.Fields.GetFieldByInternalName(LookupName);
            }
            LookupField.Group = this.columnGroup;
            return LookupField;
        }

        public SPContentType NewOrRefContentType(string Name, SPContentTypeId InheritedTypeID )
        {
            SPContentType InheritedCType = this.Web().AvailableContentTypes[InheritedTypeID];
            SPContentType CType = this.Web().AvailableContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(Name)) ?? new SPContentType(InheritedCType, this.Web().ContentTypes, Name);
            // A content type is not initialized until after it is added
            CType = this.Web().ContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(Name)) ?? this.Web().ContentTypes.Add(CType);
            CType.Group = this.contentTypeGroup;
            return CType;
        }

        public SPList NewOrRefList(string Name)
        {
            SPList list = this.Web().Lists.Cast<SPList>().FirstOrDefault(c => c.EntityTypeName.Equals(Name+"List")) ?? null;
            //SPList list = GetSPList(Name + "List");
            if (list == null) { Guid id = this.Web().Lists.Add(Name, null, SPListTemplateType.GenericList); list = this.Web().Lists[id];  }
            list.ContentTypesEnabled = true; 
            list.Update();
            return list;            
        }

        public SPList NewOrRefLibrary(string Name)
        {
            SPList Document = this.Web().Lists.Cast<SPList>().FirstOrDefault(c => c.EntityTypeName.Equals(Name)) ?? null; 
            //SPList Document = GetSPList(Name);
            if (Document == null) { this.Web().Lists.Add(Name, null, SPListTemplateType.DocumentLibrary); Document = this.Web().Lists[Name]; }            
            Document.ContentTypesEnabled = true;
            Document.Update();
            return Document;
        }
        

        public SPList NewOrRefListTemplate(string Name)
        {
            SPList ListInstance = this.Web().Lists.Cast<SPList>().FirstOrDefault(c => c.EntityTypeName.Equals(Name+"List")) ?? null;            
            if (ListInstance == null) { this.Web().Lists.Add(Name, null, this.Web().ListTemplates[Name]); ListInstance = this.Web().Lists[Name]; }
            ListInstance.ContentTypesEnabled = true;
            ListInstance.Update();
            return ListInstance;
        }

    }
}
