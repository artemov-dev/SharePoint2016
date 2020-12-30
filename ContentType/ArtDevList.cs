using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentType
{
   
    public class ArtDevList
    {
        public SPField Field = null;
        public SPList list
        {
            get;
            set;
        }

        public ArtDevList (SPList list)
        {
            this.list = list;
        }
        public ArtDevList addContentType(ArtDevContentType type)
        {  
            SPContentType CType = this.list.ContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(type.type.Name)) ?? this.list.ContentTypes.Add(type.type);                   
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


    }
}
