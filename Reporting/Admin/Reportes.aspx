<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Reporting.Admin.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="IdReporte" DataSourceID="edsReportes">
        <Columns>
            <asp:HyperLinkField HeaderText="IdReporte" DataNavigateUrlFields="IdReporte" DataNavigateUrlFormatString="EditReporte.aspx?IdReporte={0}" DataTextField="IdReporte" />
            <asp:BoundField DataField="IdObjeto" HeaderText="IdObjeto" SortExpression="IdObjeto" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Archivo" HeaderText="Archivo" SortExpression="Archivo" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:CheckBoxField DataField="Disponible" HeaderText="Disponible" SortExpression="Disponible" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
            <asp:BoundField DataField="Script" HeaderText="Script" SortExpression="Script" />
            <asp:BoundField DataField="Script2" HeaderText="Script2" SortExpression="Script2" />
        </Columns>
    </asp:GridView>
    <asp:EntityDataSource ID="edsReportes" runat="server" ConnectionString="name=SinapsisEntities" DefaultContainerName="SinapsisEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="sys_Reportes">
    </asp:EntityDataSource>
</asp:Content>
