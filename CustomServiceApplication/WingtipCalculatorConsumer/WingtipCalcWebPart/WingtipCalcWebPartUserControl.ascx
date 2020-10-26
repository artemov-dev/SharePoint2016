<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WingtipCalcWebPartUserControl.ascx.cs" Inherits="CriticalPath.SharePoint.Samples.WingtipCalculator.WingtipCalcWebPart.WingtipCalcWebPartUserControl" %>
<style type="text/css">
    .tableCell
    {
        text-align: right;
        font-weight: bold;
    }
</style>
<h3>Wingtip Calculator</h3>
Enter two values in to add or subtract using the Wingtip Calculator Service application.

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <table style="width:200">
            <tr>
                <td class="tableCell">First Integer:</td>
                <td>
                    <asp:TextBox ID="FirstIntTextBox" runat="server" Width="75px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tableCell">Operation:</td>
                <td>
                    <asp:DropDownList ID="OperandDropDownList" runat="server" Width="75px">
                        <asp:ListItem>Subtract</asp:ListItem>
                        <asp:ListItem>Add</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tableCell">Second Interger:</td>
                <td>
                    <asp:TextBox ID="SecondIntTextBox" runat="server" Width="75px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ExecuteButton" runat="server" Text="Get Result:" onclick="ExecuteButton_Click" />
                </td>
                <td style="text-align: right">
                    <asp:Label ID="AnswerLabel" runat="server" style="font-weight: 700"></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>