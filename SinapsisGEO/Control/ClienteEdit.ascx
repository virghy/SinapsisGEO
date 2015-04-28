<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClienteEdit.ascx.cs" Inherits="SinapsisGEO.Control.ClienteEdit" %>
            <h3>Datos del Cliente</h3>
 <asp:FormView ID="fvCliente" DataKeyNames="IdCliente" OnDataBound="fvCliente_DataBound" ItemType="DAL.tel_Clientes" InsertMethod="dvClientes_InsertItem" UpdateMethod="dvClientes_UpdateItem"  SelectMethod="GetClienteById" runat="server">
        <EditItemTemplate>
            <fieldset>
                <ul>
                  <div style="display:none;">
                    <asp:TextBox Text="<%# BindItem.Telefono %>" ID="txtTelefono" Width="120px"   runat="server"></asp:TextBox>
                    </div>

                    <li><asp:Label ID="Label1" runat="server" AssociatedControlID="firstName">Nombre: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="firstName" MaxLength="50" Text='<%# BindItem.Nombre %>' /> </li>

                    <li><asp:Label ID="Label2" runat="server" AssociatedControlID="txtApellido">Apellido: </asp:Label></li>
                    <li><asp:TextBox runat="server" MaxLength="50" ID="txtApellido" Text='<%# BindItem.Apellido %>' /> </li>

                    <li><asp:Label ID="Label3" runat="server" AssociatedControlID="txtEmpresa">Empresa: </asp:Label></li>
                    <li><asp:TextBox runat="server" MaxLength="50" ID="txtEmpresa" Text='<%# BindItem.Empresa %>' /> </li>
                    
                    <li><asp:Label ID="Label6" runat="server" AssociatedControlID="txtRUC">RUC: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtRUC" MaxLength="20" Text='<%# BindItem.RUC %>' /> </li>


                    <li><asp:Label ID="Label5" runat="server" AssociatedControlID="txtObs">Obs: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtObs" MaxLength="50" Text='<%# BindItem.obs %>' /> </li>

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
<%--                    <li><asp:Label ID="Label4" runat="server" AssociatedControlID="txtTelefono">Telefono: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtTelefono" Text='<%#: BindItem.Telefono %>' /> </li>--%>
                <div style="display:none;">
                <asp:TextBox Text="<%#: BindItem.Telefono %>" ID="txtTelefono" Width="120px"   runat="server"></asp:TextBox>
                </div>

                    <li><asp:Label ID="Label1" runat="server" AssociatedControlID="firstName">Nombre: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="firstName" Text='<%#: BindItem.Nombre %>' /> </li>

                    <li><asp:Label ID="Label2" runat="server" AssociatedControlID="txtApellido">Apellido: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtApellido" Text='<%#: BindItem.Apellido %>' /> </li>

                    <li><asp:Label ID="Label3" runat="server" AssociatedControlID="txtEmpresa">Empresa: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtEmpresa" Text='<%#: BindItem.Empresa %>' /> </li>

                    <li><asp:Label ID="Label6" runat="server" AssociatedControlID="txtRUC">RUC: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtRUC" Text='<%#: BindItem.RUC %>' /> </li>


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
<asp:Label ID="lblError" CssClass="error" runat="server" Text=""></asp:Label>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" />
