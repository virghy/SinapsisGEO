<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Llamadas.aspx.cs" Inherits="SinapsisGEO.Llamadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Registro de Llamada</h2>
    <br />
    <fieldset>
        <legend>Registro de Llamadas</legend>

        <ul>
            <li>
                <asp:Label ID="Label4" runat="server" AssociatedControlID="txtTelefono">Telefono: </asp:Label></li>
                
            <li>
                <asp:TextBox runat="server" ID="txtTelefono" MaxLength="10" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Requerido" CssClass="error" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>
            </li>

            <li>
                <asp:Label ID="Label3" runat="server" AssociatedControlID="cboTipoReclamo">Tipo de Llamada: </asp:Label></li>
                
            <li>
                <asp:DropDownList ID="cboTipoReclamo" ItemType="DAL.tel_TipoReclamo" SelectMethod="GetTipoReclamo" DataTextField="TipoReclamo" DataValueField="IdTipoReclamo" runat="server"></asp:DropDownList>

            </li>

            <li>
                <asp:Label ID="Label5" runat="server" AssociatedControlID="txtObs">Comentario: </asp:Label></li>
            <li>
                <asp:TextBox runat="server" ID="txtObs" Text=''  MaxLength="500"  TextMode="MultiLine" Height="100px" Width="400px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="error" runat="server" ControlToValidate="txtObs" ErrorMessage="Requerido"></asp:RequiredFieldValidator>
            </li>

        </ul>

        <ul>
            <li>
                <asp:Button ID="Button1" runat="server" CommandName="Update" Text="Grabar" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="Cancelar" PostBackUrl="~/Default.aspx" CausesValidation="false"/>

            </li>
        </ul>
    

    </fieldset>
</asp:Content>
