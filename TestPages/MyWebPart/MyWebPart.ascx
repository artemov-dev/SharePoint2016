<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyWebPart.ascx.cs" Inherits="TestPages.MyWebPart.MyWebPart" %>
<script type="text/javascript">
    function UpdateLblTest(time) {
        document.getElementById("<%=lblTest.ClientID %>").innerHTML = time;        
    }

    var selectedUsers = [];
    function MyPeoplePickerOnValueChanged(elemId, userKeys) {
        console.log(elemId);
        console.log(userKeys);
    }   
</script>
<asp:Label ID="lblTest" runat="server" Text="Выберите сотрудника: "></asp:Label>

<SharePoint:ClientPeoplePicker ID="MyPeoplePicker" runat="server" OnValueChangedClientScript="MyPeoplePickerOnValueChanged" />
<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
