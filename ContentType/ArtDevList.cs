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
        public SPList list
        {
            get;
            set;
        }

        public ArtDevList (SPList list)
        {
            this.list = list;
        }
        public void addContentType(SPContentType type)
        {
            SPContentType CType = this.list.ContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(type.Name)) ?? this.list.ContentTypes.Add(type);
            this.list.Update();
        }

        public void removeContentTypeID(SPContentTypeId typeID)
        {
            SPContentType CType = list.ParentWeb.AvailableContentTypes[typeID];
            CType = this.list.ContentTypes.Cast<SPContentType>().FirstOrDefault(c => c.Name.Equals(CType.Name)) ?? null;
            if (CType != null) { this.list.ContentTypes.Delete(CType.Id); this.list.Update(); }
        }     

        public void Update()
        {
            this.list.Update();
        }

    }
}
