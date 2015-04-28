<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelPedido.ascx.cs" Inherits="SinapsisGEO.Control.PanelPedido" %>


 <script>
     alert("Ingresando1");
     $(document).ready(function () {

         alert("Ingresando2");
         // Set up the number formatting.
         $('#txtVuelto').number(true, 2);

         $('#txtProgramarEnvio').timepicker({
             hourMin: 8,
             hourMax: 16
         });
     });
    </script>
<script type="text/javascript">
    // JavaScript funciton to call inside UpdatePanel
    function jScript() {
       
            alert("Clicked Me!");
       
    }
</script>
<div id ="cabecera">

  </div>

  <div id ="barraMenu">
      
      <h3 style="color:white;">DATOS DEL PEDIDO</h3>
</div>

 <asp:FormView ID="fvCarrito" OnItemUpdating="fvCarrito_ItemUpdating" DataKeyNames="IdCarrito" ItemType="DAL.tel_Carrito" DefaultMode="Edit" SelectMethod="GetPedido" UpdateMethod="fvCarrito_UpdateItem" runat="server">
        <EditItemTemplate>
            <fieldset>
                <ul>
                    <li><asp:Label ID="Label11" runat="server" AssociatedControlID="txtTelefono">Telefono: </asp:Label>
                        <asp:Label runat="server" ID="txtTelefono" Text='<%# BindItem.tel_Clientes.Telefono %>' />
                    </li>

                    <li><asp:Label ID="Label1" runat="server" AssociatedControlID="firstName">Nombre: </asp:Label>
                        <asp:TextBox runat="server" ID="firstName" MaxLength="50" Text='<%# BindItem.tel_Clientes.Nombre%>' />
                    </li>

                    <li><asp:Label ID="Label2" runat="server" AssociatedControlID="txtApellido">Apellido: </asp:Label>
                    <asp:TextBox runat="server" ID="txtApellido" MaxLength="50" Text='<%# BindItem.tel_Clientes.Apellido %>' />
                        </li>

                    <li><asp:Label ID="Label10" runat="server" AssociatedControlID="txtProgramarEnvio">Programar envío: </asp:Label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtProgramarEnvio" MaxLength="50" Text='<%# BindItem.ProgramarEnvio %>' />
                    </li>


                    <li><asp:Label ID="Label3" runat="server" AssociatedControlID="txtEmpresa">Empresa: </asp:Label>
                    <asp:TextBox runat="server" ID="txtEmpresa" MaxLength="50" Text='<%# BindItem.tel_Clientes.Empresa %>' />
                    </li>
                    
                    <li>
                        <asp:Label ID="Label6" runat="server" AssociatedControlID="txtRUC">RUC: </asp:Label>
                        <asp:TextBox runat="server" ID="txtRUC" MaxLength="50" Text='<%# BindItem.tel_Clientes.RUC%>' /> 
                        
                        <asp:Label ID="Label17" runat="server" AssociatedControlID="chkDiplo">Diplomatico: </asp:Label>
                        <asp:Checkbox runat="server" ID="chkDiplo" Checked ='<%# BindItem.tel_Clientes.Diplomatico%>' /> 


                    </li>

                    <li>
                       <asp:Label ID="Label5" runat="server" AssociatedControlID="txtObs">Obs: </asp:Label>
                       <asp:TextBox runat="server" ID="txtObs" MaxLength="200" Width="400px" Text='<%# BindItem.obs %>' />
                    </li>
                    
                    <li><asp:Label ID="Label4" runat="server" AssociatedControlID="cboTipoPedido">Tipo Pedido: </asp:Label>
                                                <asp:DropDownList ID="cboTipoPedido" SelectedValue="<%# BindItem.IdTipoPedido %>"  AppendDataBoundItems="true" runat="server">
                            <asp:ListItem Text="Delivery" Value="01"></asp:ListItem>
                            <asp:ListItem Text="Carry Out" Value="02"></asp:ListItem>
                            <asp:ListItem Text="Delivery 10.000" Value="03"></asp:ListItem>
                            <asp:ListItem Text="Delivery 12.000" Value="04"></asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li>
                        <asp:Label ID="Label15" runat="server" AssociatedControlID="cboFormaPago">Forma Pago: </asp:Label>
                        <asp:DropDownList ID="cboFormaPago" SelectedValue="<%# BindItem.IdFormaPago %>" SelectMethod="GetFormaPago" DataTextField="FormaPago" DataValueField="IdFormaPago" runat="server"></asp:DropDownList>
                    </li>
                    
                    <li>
                       <asp:Label ID="Label16" runat="server" AssociatedControlID="txtVuelto">Vuelto de: </asp:Label>
                       <asp:TextBox runat="server" ClientIDMode="Static" ID="txtVuelto" Text='<%# BindItem.Vuelto %>' />
<%--                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Ingrese un valor numérico." ControlToValidate="txtVuelto" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>--%>
                    </li>


                    <li>
                       <asp:Label ID="Label7" runat="server" AssociatedControlID="txtDireccion">Direccion: </asp:Label>
                       <asp:TextBox runat="server" ID="txtDireccion" Width="400px" MaxLength="50" Text='<%# BindItem.Tel_Direcciones.Direccion %>' />
                    </li>
                    <li>
                       <asp:Label ID="Label12" runat="server" AssociatedControlID="txtNroCasa">Nro: </asp:Label>
                       <asp:TextBox runat="server" ID="txtNroCasa" MaxLength="50" Text='<%# BindItem.Tel_Direcciones.NroCasa %>' />
                       <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Ingrese un valor numérico." ControlToValidate="txtNroCasa" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                    </li>
                    <li>
                       <asp:Label ID="Label13" runat="server" AssociatedControlID="txtDireccion1">Direccion1: </asp:Label>
                       <asp:TextBox runat="server" ID="txtDireccion1" Width="400px" MaxLength="50" Text='<%# BindItem.Tel_Direcciones.Direccion1 %>' />
                    </li>

                    <li>
                       <asp:Label ID="Label8" runat="server" AssociatedControlID="txtReferencia">Referencia: </asp:Label>
                       <asp:TextBox runat="server" ID="txtReferencia" Width="400px" MaxLength="200" Text='<%# BindItem.Tel_Direcciones.referencia %>' />
                        </li>
                    <li>
                       <asp:Label ID="Label14" runat="server" AssociatedControlID="txtCuadrante">Cuadrante: </asp:Label>
                       <asp:TextBox runat="server" ID="txtCuadrante" MaxLength="10" Text='<%# BindItem.Tel_Direcciones.cuadrante %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Requerido" ControlToValidate="txtCuadrante"></asp:RequiredFieldValidator>
                        </li>

                    <li>
                        <div style="display:inline">
                        <asp:Label ID="Label9" runat="server" AssociatedControlID="cboSucursal">Sucursal: </asp:Label>
                        <asp:DropDownList ID="cboSucursal" SelectedValue="<%# BindItem.IdSucursal%>" SelectMethod="GetSucursal" DataTextField="Sucursal" DataValueField="IdSucursal" runat="server"></asp:DropDownList>
                         </div>

                        <div style="display:inline; float:right;">
                            <asp:Label ID="Label18" runat="server" AssociatedControlID="chkTemporal">Sucursal Temporal: </asp:Label>
                            <asp:Checkbox runat="server" ID="chkTemporal" Checked ='<%# BindItem.TransferTemporal%>' /> 
                        </div>
                    </li>
                </ul>
                <br />
                <ul>
                <asp:Button ID="Button1" runat="server" Text="Actualizar" CommandName="Update" />
                </ul>

            </fieldset>
        </EditItemTemplate>
         
    </asp:FormView>
