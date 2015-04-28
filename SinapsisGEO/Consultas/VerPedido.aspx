<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerPedido.aspx.cs" Inherits="SinapsisGEO.Consultas.VerPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <h3>Consulta de Pedido</h3>
        Nro de Pedido:
    <asp:TextBox ID="txtNroPedido" runat="server" Width="80px" ValidationGroup="NroPedido"></asp:TextBox>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtNroPedido"
        ErrorMessage="Ingrese un valor numerico" Operator="DataTypeCheck" Type="Integer" ValidationGroup="NroPedido">* Ingrese un valor numerico</asp:CompareValidator>
    <table>
    <tr>
    <td width="200px">
     <asp:Button ID="ThemeButton1" runat="server" Text="Buscar" CausesValidation="true" ValidationGroup="NroPedido" OnClick="ThemeButton1_Click" />
    </td>
    
    <td>
 <asp:LinkButton ID="LinkButton1" runat="server" EnableTheming="True" ForeColor="#FF8000">Transferir este pedido a otra Sucursal</asp:LinkButton>
    </td>
    </tr>
    </table>
   
                           
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
                SelectMethod="GetPedidos" Height="50px" Width="150px">
                <Fields>
                    <asp:BoundField DataField="IdPedido" HeaderText="IdPedido" ReadOnly="True" SortExpression="IdPedido" Visible="False" />
                    <asp:BoundField DataField="IdEmpresa" HeaderText="IdEmpresa" SortExpression="IdEmpresa" Visible="False" />
                    <asp:TemplateField HeaderText="NroPedido" SortExpression="NroPedido">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NroPedido") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NroPedido") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" CssClass="NormalBold" EnableTheming="False"
                                Text='<%# Bind("NroPedido") %>'></asp:Label>
                            &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;

                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Comentarios.aspx?NroPedido=" + Eval("NroPedido") + " &IdCliente="+ Eval("IdCliente") + "&Nombre=" + Eval("Nombre") + " " + Eval("Apellido") %>'>Agregar Reclamo de este pedido</asp:HyperLink>
                            <br /><br />&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:HyperLink ID="HyperLink2" onclick="return confirm('Esta seguro que desea anular este pedido?');"
                             ForeColor="red" runat="server" NavigateUrl='<%# "~/Comentarios.aspx?Anula=True&NroPedido=" +Eval("NroPedido") +"&IdCliente=" +Eval("IdCliente")+ "&Nombre="+ Eval("Nombre") + " " + Eval("Apellido")%>'>Anular este pedido</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Audit_Fecha" HeaderText="Fecha" HtmlEncode="False" DataFormatString="{0:dd/MM/yy HH:mm}" SortExpression="Audit_Fecha" />
                    <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" SortExpression="IdCliente" />
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
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
    <asp:TemplateField HeaderText="Tiempos" >
        <ItemTemplate>
            <strong>
            Cola: <%# SinapsisGEO.Utility.HoraString(Item.horaCola) %> 
             | Preparacion: <%# SinapsisGEO.Utility.HoraString(Item.horaPreparacion) %>
            | Envio: <%# SinapsisGEO.Utility.HoraString(Item.HoraEnvio) %>
            | Entrega: <%# SinapsisGEO.Utility.HoraString(Item.HoraEntrega) %>
           </strong>
        </ItemTemplate>
        </asp:TemplateField>
                    <asp:BoundField DataField="TiempoServicio" HeaderText="Tiempo Servicio" SortExpression="TiempoServicio" />                    
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
                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ItemType="DAL.tel_Comentarios" SelectMethod="GetComentarios" DataKeyNames="IdComentario"
                         GridLines="None"  
                CssClass="mGrid"  
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"> 
                    <Columns>
                        <asp:BoundField DataField="Comentario" HeaderText="Comentario" SortExpression="Comentario" />
                        <asp:BoundField DataField="audit_Usuario" HeaderText="Usuario" SortExpression="audit_Usuario" />
                        <asp:BoundField DataField="tel_TipoReclamo.TipoReclamo" HeaderText="Tipo" SortExpression="IdTipoReclamo" />
                        <asp:BoundField DataField="Audit_Fecha" HeaderText="Fecha" SortExpression="Audit_Fecha" DataFormatString="{0:dd/MM HH:mm}" HtmlEncode="False" />
                        <asp:BoundField DataField="visto_Usuario" HeaderText="Leido Por" SortExpression="visto_Usuario" />
                        <asp:BoundField DataField="Visto_Fecha" DataFormatString="{0:dd/MM HH:mm}" HeaderText="Leido el"
                            HtmlEncode="False" SortExpression="Visto_Fecha" />
                    </Columns>
                </asp:GridView>
            </td>
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
    &nbsp; &nbsp;&nbsp;
    <br />
</asp:Content>
