<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerCadena.aspx.cs" Inherits="SinapsisGEO.Consultas.VerCadena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    


    <script>
        //$(document).ready(function () {
        //    $("#MainContent_txtFecha").datepicker("option", "dateFormat", "dd/mm/yyyy");

        //});

        $(function () {
            $("#time1").datepicker("option", "dateFormat", "dd/mm/yyyy");
        });


    </script>
    <div>
    <input name="time1" type="time" id="time1" />
        </div>
    <h3>Consulta de Cadena de Envio</h3>
    <ul>
        <li>
            Fecha: 
             
            <asp:TextBox ID="txtFecha" TextMode="Date"  runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtFecha"  runat="server" ErrorMessage="Ingrese una fecha"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtFecha"  runat="server" ErrorMessage="Ingrese una fecha válida" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
            </li>
        <li>
            <asp:Button ID="cmdBuscar" OnClick="cmdBuscar_Click" runat="server" Text="Buscar" />
        </li>
        </ul>
    <asp:GridView ID="GridView1" ItemType="DAL.tel_Ph_Interfase" SelectMethod="GetInterfase" runat="server"
         CssClass="mGrid"  
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"> </asp:GridView>
</asp:Content>
