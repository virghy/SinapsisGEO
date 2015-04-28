<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SinapsisGEO._Default" %>

<%@ Register Src="~/Control/PanelProducto.ascx" TagPrefix="uc1" TagName="PanelProducto" %>
<%@ Register Src="~/Control/PanelCliente.ascx" TagPrefix="uc1" TagName="PanelCliente" %>



<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
   <%--   <uc1:PanelProducto runat="server" id="PanelProducto" />--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:PanelCliente runat="server" ID="PanelCliente" />
</asp:Content>