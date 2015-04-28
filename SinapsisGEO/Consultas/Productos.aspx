<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="SinapsisGEO.Consultas.Productos" %>

<%@ Register Src="~/Control/PanelProducto.ascx" TagPrefix="uc1" TagName="PanelProducto" %>
<%@ Register Src="~/Control/PanelAddProducto.ascx" TagPrefix="uc1" TagName="PanelAddProducto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:PanelProducto runat="server" ID="PanelProducto" />
    <uc1:PanelAddProducto runat="server" ID="PanelAddProducto" Visible="false" />
</asp:Content>
