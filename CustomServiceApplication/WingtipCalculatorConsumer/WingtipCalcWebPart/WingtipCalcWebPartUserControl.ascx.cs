using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator.WingtipCalcWebPart
{
    public partial class WingtipCalcWebPartUserControl : UserControl
    {
        protected void ExecuteButton_Click(object sender, EventArgs e)
        {
            CalcServiceClient client = new CalcServiceClient(SPServiceContext.Current);

            int result = 0;

            switch (OperandDropDownList.SelectedItem.ToString())
            {
                case "Add":
                    result = client.Add(Int32.Parse(FirstIntTextBox.Text),
                        Int32.Parse(SecondIntTextBox.Text));
                    break;
                case "Subtract":
                    result = client.Subtract(Int32.Parse(FirstIntTextBox.Text),
                        Int32.Parse(SecondIntTextBox.Text));
                    break;
            }

            AnswerLabel.Text = result.ToString();
        }
    }
}
