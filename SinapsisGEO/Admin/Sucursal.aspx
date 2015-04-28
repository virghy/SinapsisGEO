<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sucursal.aspx.cs" Inherits="SinapsisGEO.Admin.Sucursal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView ID="DetailsView1" SelectMethod="DetailsView1_GetItem" ItemType="DAL.tel_Sucursal" runat="server" Height="50px" Width="125px">

    </asp:DetailsView>
</asp:Content>
