<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IIS.aspx.cs" Inherits="Tools.IIS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="cmdReciclar" OnClick="cmdReciclar_Click" runat="server" Text="Reciclar Sinapsis" />
    <asp:Label ID="lblResultado" Text="" runat="server"></asp:Label>
</asp:Content>
