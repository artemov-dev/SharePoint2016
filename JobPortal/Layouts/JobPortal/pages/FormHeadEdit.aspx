<%@ Assembly Name="JobPortal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a583f37958f7f7b4" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="ArtDevWebPart" Namespace="ArtDevWebPart.JSBundleReact" Assembly="artdevwebpart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f75bdce9f316ed9a" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormHeadEdit.aspx.cs" Inherits="JobPortal.Layouts.JobPortal.pages.FormHeadEdit" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <SharePoint:ScriptLink name="sp.js" runat="server" OnDemand="false" LoadAfterUI="true" Localizable="false" />
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Edit - Header
</asp:Content>


<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <ArtDevWebPart:JSBundleReact runat="server" JSBundleFile="/_layouts/15/JobPortal/react/public/headerForm.bundle.js" ReactRootElement="headerForm" />	
</asp:Content>
