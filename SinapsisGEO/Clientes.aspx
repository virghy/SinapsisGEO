<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="SinapsisGEO.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Detalle del Cliente</h3>
    <asp:FormView ID="FormView1" DataKeyNames="IdCliente" DefaultMode="Edit" ItemType="DAL.tel_Clientes" InsertMethod="dvClientes_InsertItem" UpdateMethod="dvClientes_UpdateItem" runat="server" SelectMethod="GetCliente">
        <EditItemTemplate>
            <fieldset>
                <ul>
                    <li><asp:Label ID="Label1" runat="server" AssociatedControlID="firstName">Nombre: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="firstName" Text='<%#: BindItem.Nombre %>' /> </li>

                    <li><asp:Label ID="Label2" runat="server" AssociatedControlID="txtApellido">Apellido: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtApellido" Text='<%#: BindItem.Apellido %>' /> </li>

                    <li><asp:Label ID="Label3" runat="server" AssociatedControlID="txtEmpresa">Empresa: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtEmpresa" Text='<%#: BindItem.Empresa %>' /> </li>

                    <li><asp:Label ID="Label5" runat="server" AssociatedControlID="txtObs">Obs: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtObs" Text='<%#: BindItem.obs %>' /> </li>

                </ul>

                <ul><li>
                <asp:Button ID="Button1" runat="server" CommandName="Update" Text="Grabar" />
                <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="Cancelar" CausesValidation="false" />

            </li></ul>

            </fieldset>
        </EditItemTemplate>
           <InsertItemTemplate>
            <fieldset>
                <ul>
                    <li><asp:Label ID="Label4" runat="server" AssociatedControlID="txtTelefono">Telefono: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtTelefono" Text='<%#: BindItem.Telefono %>' /> </li>

                    <li><asp:Label ID="Label1" runat="server" AssociatedControlID="firstName">Nombre: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="firstName" Text='<%#: BindItem.Nombre %>' /> </li>

                    <li><asp:Label ID="Label2" runat="server" AssociatedControlID="txtApellido">Apellido: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtApellido" Text='<%#: BindItem.Apellido %>' /> </li>

                    <li><asp:Label ID="Label3" runat="server" AssociatedControlID="txtEmpresa">Empresa: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtEmpresa" Text='<%#: BindItem.Empresa %>' /> </li>

                    <li><asp:Label ID="Label5" runat="server" AssociatedControlID="txtObs">Obs: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtObs" Text='<%#: BindItem.obs %>' /> </li>

                </ul>

                <ul><li>
                <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="Grabar" />
                <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="Cancelar" CausesValidation="false" />
            </li></ul>

            </fieldset>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
