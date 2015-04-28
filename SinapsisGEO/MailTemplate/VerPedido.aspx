<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerPedido.aspx.cs"  EnableViewState="false"  Inherits="SinapsisGEO.MailTemplate.VerPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div style="width:400px"  class="Titulos"><h3> : : Datos del Pedido </h3></div>
    <table style="width: 100%; height: 100%">
        <tr>
            <td valign="top">
            <asp:DetailsView ID="DetailsView1" CssClass="mDetailView" 
                 PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"
                HeaderStyle-CssClass="mDetailViewheader"
            FieldHeaderStyle-CssClass="mDetailViewfieldHeader"

                 ItemType="DAL.tel_Pedidos" runat="server" AutoGenerateRows="False" DataKeyNames="NroPedido"
                SelectMethod="GetPedidos" Height="50px" Width="125px">
                <Fields>
                    <asp:BoundField DataField="IdPedido" HeaderText="IdPedido" ReadOnly="True" SortExpression="IdPedido" Visible="true" />
                    <asp:BoundField DataField="NroPedido" HeaderText="NroPedido" ReadOnly="True" SortExpression="IdPedido" Visible="true" />                 
                    <asp:BoundField DataField="Audit_Fecha" HeaderText="Fecha" HtmlEncode="False" DataFormatString="{0:dd/MM/yy HH:mm}" SortExpression="Audit_Fecha" />
                    <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" SortExpression="IdCliente" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" >
                        <ControlStyle CssClass="NormalBold" />
                        <ItemStyle CssClass="NormalBold" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                    <asp:BoundField DataField="Empresa" HeaderText="Empresa" SortExpression="Empresa" />
                    <asp:BoundField DataField="RUC" HeaderText="RUC" SortExpression="RUC" />
                    <asp:BoundField DataField="referencia" HeaderText="referencia" SortExpression="referencia" />
                    <asp:BoundField DataField="UserName" HeaderText="Operador" SortExpression="audit_Usuario" />
                    <asp:TemplateField HeaderText="horaCola" SortExpression="horaCola">
                        <ItemTemplate>
                        <%# SinapsisGEO.Utility.HoraString(Item.horaCola) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="horaPreparacion" SortExpression="horaPreparacion">
                        <ItemTemplate>
                        <%# SinapsisGEO.Utility.HoraString(Item.horaPreparacion) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="HoraEnvio" SortExpression="HoraEnvio">
                        <ItemTemplate>
                        <%# SinapsisGEO.Utility.HoraString(Item.HoraEnvio) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="HoraEntrega" SortExpression="HoraEntrega">
                        <ItemTemplate>
                          <%# SinapsisGEO.Utility.HoraString(Item.HoraEntrega) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="obs" HeaderText="obs" SortExpression="obs" />
                    <asp:BoundField DataField="IdMovil" HeaderText="IdMovil" SortExpression="IdMovil" />
                    <asp:BoundField DataField="IdSucursal" HeaderText="IdSucursal" SortExpression="IdSucursal" />
                    <asp:TemplateField HeaderText="cuadrante" SortExpression="cuadrante">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cuadrante") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cuadrante") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCuadrante" runat="server" Text='<%# Bind("cuadrante") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CostoEnvio" HeaderText="Costo Envio" SortExpression="CostoEnvio" DataFormatString="{0:N0}" HtmlEncode="False" />
                    <asp:BoundField DataField="TotalPedido" HeaderText="Total Pedido" SortExpression="TotalPedido" DataFormatString="{0:N0}" HtmlEncode="False" />
                    <asp:BoundField DataField="TotalGeneral" DataFormatString="{0:N0}" HeaderText="Total General"
                        HtmlEncode="False" SortExpression="TotalGeneral" />
                    <asp:BoundField DataField="Anulado" HeaderText="Anulado" SortExpression="Anulado" />
                    <asp:BoundField DataField="IdPedidoWeb" HeaderText="Nro Comanda" SortExpression="IdPedidoWeb" />
                    <asp:BoundField DataField="tel_TipoPedido.TipoPedido" HeaderText="Tipo Pedido" />
                    <asp:BoundField DataField="tel_FormaPago.FormaPago" HeaderText="Forma Pago" />
                    <asp:TemplateField HeaderText=": : Detalle">
                        <ItemTemplate>
               <asp:GridView ID="GridView1" ItemType="DAL.tel_PedidosDet" runat="server" DataSource="<%# Item.tel_PedidosDet %>" AutoGenerateColumns="False" DataKeyNames="IdPedidoDet"
                                   GridLines="None"  
                CssClass="mGrid"  
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"> 

        <Columns>
            <asp:BoundField DataField="IdPedidoDet" HeaderText="IdPedidoDet" InsertVisible="False"
                ReadOnly="True" SortExpression="IdPedidoDet" Visible="False" />
            <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" SortExpression="IdProducto" />
            <asp:BoundField DataField="tel_Productos.Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="Cantidad" DataFormatString="{0:N2}" HeaderText="Cantidad"
                HtmlEncode="False" SortExpression="Cantidad" />
            <asp:BoundField DataField="Precio" DataFormatString="{0:N2}" HeaderText="Precio"
                HtmlEncode="False" SortExpression="Precio" />
            <asp:TemplateField HeaderText="Precio">
                <ItemTemplate>
                    <%# String.Format("{0:N2}",(Item.Cantidad*Item.Precio)) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Obs" HeaderText="Obs" SortExpression="Obs" />
        </Columns>
    </asp:GridView>


                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
            </td>
            <td valign="top">
                     &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" valign="top">
  
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td valign="top">
            </td>
        </tr>
    </table>
        <p>
            Correo generado automaticamente por Sinapsis - Futura Software - 2013
        </p>
    </div>
    </form>
</body>
</html>
