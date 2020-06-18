using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebPartPages;
using ListViewFilter.Extensions;

namespace ListViewFilter.WebParts.SPListViewFilter.ToolParts
{
    internal class AdvancedSettings : ToolPart
    {
        public AdvancedSettings()
        {
            Title = this.LocalizedString("ToolTip_Advanced");
        }

        private CheckBox _diacriticVariations;
        private CheckBox _preventDataViewUntilFiltering;
        private CheckBox _sqlCheckBox;
        private CheckBox _jqueryCheckBox;
        private CheckBox _jqueryUICheckBox;

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            _preventDataViewUntilFiltering = new CheckBox
            {
                Text = this.LocalizedString("Text_PreventDataViewUntilFiltering"),
                Checked = WebPart.PreventDataViewUntilFiltering
            };
            _sqlCheckBox = new CheckBox
            {
                Text = this.LocalizedString("Text_UseSqlQueries"),
                Checked = WebPart.UseSqlQueries
            };
            _jqueryCheckBox = new CheckBox
            {
                Text = this.LocalizedString("Text_UsejQuery"),
                Checked = WebPart.RegisterjQueryOnPage
            };
            _jqueryUICheckBox = new CheckBox
            {
                Text = this.LocalizedString("Text_UsejQueryUI"),
                Checked = WebPart.RegisterjQueryUIOnPage
            };
            _diacriticVariations = new CheckBox
            {
                Text = this.LocalizedString("Text_DiacriticalVariations"),
                Checked = WebPart.PrepareDiacriticalVariations
            };
            Controls.Add(_preventDataViewUntilFiltering);
            Controls.Add(new LiteralControl(@"<br/>"));
            Controls.Add(_diacriticVariations);
            Controls.Add(new LiteralControl(@"<br/>"));
            Controls.Add(_sqlCheckBox);
            Controls.Add(new LiteralControl(@"<br/>"));
            Controls.Add(_jqueryCheckBox);
            Controls.Add(new LiteralControl(@"<br/>"));
            Controls.Add(_jqueryUICheckBox);
            Controls.Add(new LiteralControl(@"<br/>"));
        }

        private SPListViewFilter WebPart
        {
            get
            {
                return WebPartToEdit as SPListViewFilter;
            }
        }

        public override void ApplyChanges()
        {
            base.ApplyChanges();
            WebPart.UseSqlQueries = _sqlCheckBox.Checked;
            WebPart.RegisterjQueryOnPage = _jqueryCheckBox.Checked;
            WebPart.RegisterjQueryUIOnPage = _jqueryUICheckBox.Checked;
            WebPart.PreventDataViewUntilFiltering = _preventDataViewUntilFiltering.Checked;
            WebPart.PrepareDiacriticalVariations = _diacriticVariations.Checked;
        }
    }
}
