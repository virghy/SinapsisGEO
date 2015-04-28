<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Direccion.aspx.cs" Inherits="SinapsisGEO.Consultas.Direccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Consulta de Direcciones</h2>

    <fieldset>
        <legend>
            </legend>

       <blockquote>Ingrese Nombres, Direcciones, Nros y Referencias</blockquote> 
    <ul>
       
        <li>
            <label for="txtDir1">Campo 1</label>
            <asp:TextBox ID="txtDir1" runat="server"></asp:TextBox>

            </li>
        <li>
            <label for="txtDir2">Campo 2</label>
            <asp:TextBox ID="txtDir2" runat="server"></asp:TextBox>            
        </li>
        <li>
            <label for="txtDir3">Campo 3</label>
            <asp:TextBox ID="txtDir3" runat="server"></asp:TextBox>            
        </li>
        <li>
            <label for="txtDir4">Campo 4</label>
            <asp:TextBox ID="txtDir4" runat="server"></asp:TextBox>            
        </li>

        <li>
            <asp:Button Text="Buscar" ID="cmdBuscar" OnClick="cmdBuscar_Click" runat="server" />
        </li>
        </ul>
        </fieldset>
    <asp:GridView runat="server" ID="grvDireccion" CssClass="mGrid"  
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"></asp:GridView>

</asp:Content>
