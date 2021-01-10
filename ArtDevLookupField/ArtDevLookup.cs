using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Security;
using System.Web.UI;
using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace ArtDevLookupField
{
    public class ArtDevLookup : SPFieldText   
    {
        public ArtDevLookup(SPFieldCollection fields, string fieldName)
            : base(fields, fieldName) { }

        public ArtDevLookup(SPFieldCollection fields, string typeName, string displayName)
            : base(fields, typeName, displayName) { }

        BaseFieldControl fieldControl;

        public override BaseFieldControl FieldRenderingControl
        {
            [SharePointPermission(SecurityAction.LinkDemand, ObjectModel = true)]
            get
            {
                fieldControl = new ArtDevLookupFieldControl();
                fieldControl.FieldName = this.InternalName;

                return fieldControl;
            }
        }

        public override string JSLink
        {
            get
            {
                return "clienttemplates.js";
            }
        }

        public override Dictionary<string, object> GetJsonClientFormFieldSchema(SPControlMode mode)
        {
            var formctx = base.GetJsonClientFormFieldSchema(mode);
            formctx["artDevContent"] = ((ArtDevLookupFieldControl)fieldControl).ListName;
            return formctx;

        }
    }

    public class ArtDevLookupFieldControl : BaseFieldControl
    {       

        public string ListName;
     

        protected override void CreateChildControls()
        {
            base.CreateChildControls();            
            ListName = Field.GetCustomProperty("List").ToString();            
        }
       
    }
}


    
