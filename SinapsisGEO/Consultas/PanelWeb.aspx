<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelWeb.aspx.cs" Inherits="SinapsisGEO.Consultas.PanelWeb" %>


<%@ Register Src="~/Control/PanelEntrante.ascx" TagPrefix="uc1" TagName="PanelEntrante" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id ="izquierda">
        <uc1:PanelEntrante runat="server" ID="PanelEntrante" />
    </div>

</asp:Content>
