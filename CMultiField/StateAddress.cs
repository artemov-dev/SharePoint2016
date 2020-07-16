using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace CMultiField
{
    //fiels type

    public class StateAddress : SPFieldMultiColumn
    {
        public StateAddress(SPFieldCollection fields,
                                   string fieldName)
          : base(fields, fieldName) { }

        public StateAddress(SPFieldCollection fields,
                                   string typeName,
                                   string displayName)
          : base(fields, typeName, displayName) { }

        public override BaseFieldControl FieldRenderingControl
        {
            get
            {
                BaseFieldControl ctr = new AddressFieldControl();
                ctr.FieldName = this.InternalName;
                return ctr;
            }
        }

        public override string GetFieldValueAsHtml(object value)
        {
            string HtmlLineBreak = @"<br />";
            SPFieldMultiColumnValue mcv =
              new SPFieldMultiColumnValue(value.ToString());
            string HtmlAddress = mcv[0].ToString() + HtmlLineBreak;
            if (!string.IsNullOrEmpty(mcv[1]))
            {
                HtmlAddress += mcv[1].ToString() + HtmlLineBreak;
            }
            HtmlAddress += mcv[2].ToString() + ", " + mcv[3] + "  " + mcv[4];
            return HtmlAddress;
        }

        
    }

    //field control type

    public class AddressFieldControl : BaseFieldControl
    {
        protected override string DefaultTemplateName {
            get { return "UnitedStatesAddressRenderingTemplate"; }
        }

        protected TextBox txtAddress1;
        protected TextBox txtAddress2;
        protected TextBox txtCity;
        protected TextBox txtState;
        protected TextBox txtZipcode;

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            txtAddress1 =
                (TextBox)this.TemplateContainer.FindControl("txtAddress1");
            txtAddress2 =
                (TextBox)this.TemplateContainer.FindControl("txtAddress2");
            txtCity =
                (TextBox)this.TemplateContainer.FindControl("txtCity");
            txtState =
                (TextBox)this.TemplateContainer.FindControl("txtState");
            txtZipcode =
                (TextBox)this.TemplateContainer.FindControl("txtZipcode");
        }

        public override object Value { 
            get {
                this.EnsureChildControls();
                SPFieldMultiColumnValue mcv = new SPFieldMultiColumnValue(5);
                mcv[0] = txtAddress1.Text;
                mcv[1] = txtAddress2.Text;
                mcv[2] = txtCity.Text.ToUpper();
                mcv[3] = txtState.Text;
                mcv[4] = txtZipcode.Text;
                return mcv;
            }
            set {
                this.EnsureChildControls();
                SPFieldMultiColumnValue mcv =
                          (SPFieldMultiColumnValue)this.ItemFieldValue;
                txtAddress1.Text = mcv[0];
                txtAddress2.Text = mcv[1];
                txtCity.Text = mcv[2];
                txtState.Text = mcv[3]; ;
                txtZipcode.Text = mcv[4];
            } 
        }
    }


}
