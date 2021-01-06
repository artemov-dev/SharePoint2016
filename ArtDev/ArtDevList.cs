using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtDev
{
   
    public class ArtDevList
    {
        public SPField Field;
        public SPListItem Item;
        public List<ArtDevContentType> artDevContentTypes;
        public List<ArtDevField> artDevFields;
        public List<SPField> sPFields;
        public SPList list
        {
            get;
            set;
        }

        public ArtDevList (SPList list)
        {
            this.list = list;
            this.artDevContentTypes = new List<ArtDevContentType>();
            this.artDevFields = new List<ArtDevField>();
            this.sPFields = new List<SPField>();
        }
        public ArtDevList addContentType(ArtDevContentType type)
        {
            this.artDevContentTypes.Add(type);
            SPContentType CType = this.list.ContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(type.type.Name)) ?? this.list.ContentTypes.Add(type.type);                   
            this.list.Update();
            return this;
        }

        public ArtDevList addContentType(SPContentTypeId typeID)
        {
            SPContentType CType = this.list.ParentWeb.AvailableContentTypes[typeID];
            CType = this.list.ContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(CType.Name)) ?? this.list.ContentTypes.Add(CType);            
            this.list.Update();            
            return this;
        }


        public ArtDevList removeContentTypeID(SPContentTypeId typeID)
        {
            SPContentType CType = this.list.ParentWeb.AvailableContentTypes[typeID];
            CType = this.list.ContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(CType.Name)) ?? null;
            if (CType != null) { this.list.ContentTypes.Delete(CType.Id);  }
            this.list.Update();
            return this;
        }  

        public ArtDevList RemoveStandartContentType()
        {

            SPContentType DocType = this.list.ParentWeb.AvailableContentTypes[SPBuiltInContentTypeId.Document];
            SPContentType ItemType = this.list.ParentWeb.AvailableContentTypes[SPBuiltInContentTypeId.Item];
            DocType = this.list.ContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(DocType.Name)) ?? null;
            ItemType = this.list.ContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(ItemType.Name)) ?? null;
            if (DocType != null) { this.list.ContentTypes.Delete(DocType.Id); }
            if (ItemType != null) { this.list.ContentTypes.Delete(ItemType.Id); }
            this.list.Update();
            return this;
        }
        
        public ArtDevList removeFieldID(Guid guid)
        {
            SPField Field = this.list.ParentWeb.AvailableFields[guid];
            Field = this.list.Fields.GetFieldByInternalName(Field.InternalName) ?? null;
            if (Field != null) { this.list.Fields.Delete(Field.InternalName); }
            this.list.Update();
            return this;
        }  

        public ArtDevList GetFieldLink(Guid guid)
        {
            SPField Field = this.list.ParentWeb.AvailableFields[guid];            
            this.Field = this.list.Fields.GetFieldByInternalName(Field.InternalName) ?? null;  
            if (this.Field != null) { this.sPFields.Add(this.Field); }
            return this;
        }

        public SPField GetField(Guid guid)
        {
            return this.list.ParentWeb.AvailableFields[guid];
        }

        public ArtDevList AddFieldLink(ArtDevField field)
        {
            this.artDevFields.Add(field);
            this.sPFields.Add(field.field);
            SPField sPField = this.list.Fields.TryGetFieldByStaticName(field.field.StaticName) ?? null;
            if (sPField == null) { this.list.Fields.Add(field.field); this.Field = field.field; }
            else { this.Field = sPField; }            
            return this;
        }

        public ArtDevList SetFieldRequired(bool condition)
        {
            this.Field.Required = true;
            this.Field.Update();
            return this;
        }

        public ArtDevList SetFieldTitle(string Title)
        {
            this.Field.Title = Title;
            this.Field.Update();
            return this;
        }

        public ArtDevList Commit()
        {
            this.list.Update();            
            return this;
        }

        public ArtDevList SetListTitle(string Name)
        {
            this.list.Title = Name;
            this.list.Update();
            return this;
        }

        public ArtDevList GetItemByTitle(string Value)
        {
            this.Item = null;
            SPQuery query = new SPQuery
            {
                Query = @"<Where>
		                         <Eq>
				                      <FieldRef Name='Title' />
				                      <Value Type='Text'>" + Value + @"</Value>
			                     </Eq>
                          </Where>"
            };
            this.Item = list.GetItems(query).Cast<SPListItem>().FirstOrDefault();
            return this;
        }

        public ArtDevList SetItem(Guid FieldGuid, string Value)
        {
            this.Field = this.GetField(FieldGuid);
            if (this.Item != null && this.Field != null) { this.Item[this.Field.Id] = Value; this.Item.Update(); }             
            return this;
        }

        public ArtDevList GetItem(Guid FieldGuid, string Value)
        {
            this.Item = null;
            this.Field = this.GetField(FieldGuid);
            SPQuery query = new SPQuery
            {
                Query = @"<Where>
		                         <Eq>
				                      <FieldRef Name='" + this.Field.InternalName + @"' />
				                      <Value Type='Text'>" + Value + @"</Value>
			                     </Eq>
                          </Where>"
            };
            this.Item = list.GetItems(query).Cast<SPListItem>().FirstOrDefault();
            return this;
        }

        public ArtDevList AddItem(params string[] Values)
        {
            SPListItem sPListItem = this.list.Items.Add();          
            int i = 0;            
            Values.ToList<string>().ForEach(value => {
                
                string Name = this.sPFields[i].InternalName;
                sPListItem[Name] = value;
                i++;
            });
            sPListItem.Update();
            return this;
        }

        public ArtDevList AddItemIfNotExsist(params string[] Values)
        {
            this.GetItem(SPBuiltInFieldId.Title, Values[0]);
            if (this.Item == null)
            {
                SPListItem sPListItem = this.list.Items.Add();
                int i = 0;
                Values.ToList<string>().ForEach(value =>
                {

                    string Name = this.sPFields[i].InternalName;
                    sPListItem[Name] = value;
                    i++;
                });
                sPListItem.Update();
            }
            return this;
        }

    }
}
 