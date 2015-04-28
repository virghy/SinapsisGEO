<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SinapsisGEO.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <strong><span style="color: #ff0066">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Default/Images/red-error.gif" Height="16px" /><span
                                    style="font-size: 10pt">
                                <span style="color: red">Un Error ha ocurrido.</span></span></span></strong><br />
								<asp:Literal runat="server" ID="litErrorText"  /><br />
                                <strong><span><span style="color: black"><span style="font-size: 9pt">
                                    <br />
								Por favor Contacte con el Administrador del Sistema si el Problema Persiste <br />
                                    <br />
                                    <br />
                                    <asp:HyperLink ID="HyperLink1" runat="server">Reintentar</asp:HyperLink>&nbsp;<br /></span>&nbsp;</span></span></strong>

</asp:Content>
