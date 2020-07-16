<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CMultiField.StateAddressTemplate.ascx.cs" Inherits="CMultiField.ControlTemplates.CMultiField.CMultiField" %>


<SharePoint:RenderingTemplate runat="server"
                        ID="UnitedStatesAddressRenderingTemplate" >
  <Template>
    <table>
      <tr>
        <td>Address1:</td>
        <td><asp:TextBox ID="txtAddress1"  runat="server" /></td>
      </tr>
      <tr>
        <td>Address2:</td>
        <td><asp:TextBox ID="txtAddress2" runat="server" /></td>
      </tr>
      <tr>
        <td class="AddressLabel">City:</td>
        <td>
          <asp:TextBox ID="txtCity" runat="server" />
          &nbsp;State:&nbsp;
          <asp:TextBox ID="txtState" runat="server" MaxLength="2" />
          &nbsp;Zipcode:&nbsp;
          <asp:TextBox ID="txtZipcode" runat="server" />
        </td></tr>
    </table>
  </Template>
</SharePoint:RenderingTemplate>