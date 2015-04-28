<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="SinapsisGEO.Admin.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Productos</h2>
    <p>Familia
        <asp:DropDownList ID="cboFamilia" runat="server" Width="147px" AutoPostBack="True" DataSourceID="edsFamilia" DataTextField="Familia" DataValueField="IdFamilia">
        </asp:DropDownList>
        <asp:EntityDataSource ID="edsFamilia" runat="server" ConnectionString="name=SinapsisEntities" DefaultContainerName="SinapsisEntities" EnableFlattening="False" EntitySetName="tel_Familia" EntityTypeFilter="tel_Familia" Select="it.[IdFamilia], it.[Familia]">
        </asp:EntityDataSource>
&nbsp;Linea
        <asp:DropDownList ID="cboLinea" runat="server" Width="130px" AutoPostBack="True" DataSourceID="edsLinea" DataTextField="Linea" DataValueField="IdLinea">
        </asp:DropDownList>
        <asp:EntityDataSource ID="edsLinea" runat="server" AutoGenerateWhereClause="True" ConnectionString="name=SinapsisEntities" DefaultContainerName="SinapsisEntities" EnableFlattening="False" EntitySetName="tel_Linea" Select="it.[IdFamilia], it.[IdLinea], it.[Linea]" Where="">
            <WhereParameters>
                <asp:ControlParameter ControlID="cboFamilia" Name="IdFamilia" PropertyName="SelectedValue" />
            </WhereParameters>
        </asp:EntityDataSource>
&nbsp;Grupo
        <asp:DropDownList ID="cboGrupo" runat="server" Width="108px" AutoPostBack="True" DataSourceID="edsGrupo" DataTextField="Grupo" DataValueField="IdGrupo">
        </asp:DropDownList>
        <asp:EntityDataSource ID="edsGrupo" runat="server" AutoGenerateWhereClause="True" ConnectionString="name=SinapsisEntities" DefaultContainerName="SinapsisEntities" EnableFlattening="False" EntitySetName="tel_Grupo" Select="it.[IdFamilia], it.[IdLinea], it.[IdGrupo], it.[Grupo]" Where="">
            <WhereParameters>
                <asp:ControlParameter ControlID="cboFamilia" Name="IdFamilia" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="cboLinea" Name="IdLinea" PropertyName="SelectedValue" />
            </WhereParameters>
        </asp:EntityDataSource>
&nbsp;</p>
    <hr />
    <asp:GridView ID="GridView1" DataKeyNames="IdProducto" AutoGenerateColumns="False" ItemType="DAL.tel_Productos" SelectMethod="GridView1_GetData" runat="server" 
        AllowPaging="True" AllowSorting="True" PageSize="20" UpdateMethod="GridView1_UpdateItem" AutoGenerateEditButton="True">
        <Columns>
            <asp:BoundField HeaderText="Id" ReadOnly="true" DataField="IdProducto" />
            <asp:BoundField HeaderText="Descripcion" ReadOnly="true" DataField="Descripcion" />
            <asp:TemplateField HeaderText="Contenido">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" Width="400px" TextMode="MultiLine" Height="50px" runat="server" Text='<%# Bind("Contenido") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Contenido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Activo">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkActivo" Checked='<%# Bind("Activo") %>' runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkActivo" Enabled="false" Checked='<%# Bind("Activo") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
