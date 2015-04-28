<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditReporte.aspx.cs" Inherits="Reporting.Admin.EditReporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="IdReporte" DataSourceID="edsReportes" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="IdReporte" HeaderText="IdReporte" ReadOnly="True" SortExpression="IdReporte" />
            <asp:BoundField DataField="IdObjeto" HeaderText="IdObjeto" SortExpression="IdObjeto" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Archivo" HeaderText="Archivo" SortExpression="Archivo" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:CheckBoxField DataField="Disponible" HeaderText="Disponible" SortExpression="Disponible" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
            <asp:BoundField DataField="Script" HeaderText="Script" SortExpression="Script" />
            <asp:BoundField DataField="Script2" HeaderText="Script2" SortExpression="Script2" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="IdReporte,IdEmpresa" DataSourceID="edsEmpresa">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="IdReporte" HeaderText="IdReporte" ReadOnly="True" SortExpression="IdReporte" Visible="False" />
            <asp:BoundField DataField="IdEmpresa" HeaderText="IdEmpresa" ReadOnly="True" SortExpression="IdEmpresa" />
            <asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />
        </Columns>
    </asp:GridView>

    <asp:EntityDataSource ID="edsEmpresa" runat="server" ConnectionString="name=SinapsisEntities" DefaultContainerName="SinapsisEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="sys_ReporteEmpresa" Where="it.IdReporte=@IdReporte">
        <WhereParameters>
            <asp:QueryStringParameter DbType="Int32" Name="IdReporte" QueryStringField="IdReporte" />
        </WhereParameters>
    </asp:EntityDataSource>

    <asp:EntityDataSource ID="edsReportes" runat="server" ConnectionString="name=SinapsisEntities" DefaultContainerName="SinapsisEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="sys_Reportes" EntityTypeFilter="sys_Reportes" Where="it.IdReporte = @IdReporte" Select="">
        <WhereParameters>
            <asp:QueryStringParameter Name="IdReporte" QueryStringField="IdReporte" DbType="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
    <div>
        Empresa: <asp:TextBox ID="txtEmpresa" runat="server"></asp:TextBox>
        <asp:Button ID="cmdAgregar" runat="server" Text="Agregar" OnClick="cmdAgregar_Click" />
        <asp:Label ID="lblError" CssClass="Error"  runat="server"></asp:Label>
    </div>

    <div style="text-align:right;"  >
        <asp:HyperLink  ID="HyperLink1" NavigateUrl="~/Admin/Reportes.aspx" runat="server">Volver a Lista de Reportes</asp:HyperLink>
    </div>

</asp:Content>
