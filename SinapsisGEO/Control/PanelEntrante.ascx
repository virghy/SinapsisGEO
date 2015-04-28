<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelEntrante.ascx.cs" Inherits="SinapsisGEO.Control.PanelEntrante" %>
      <div class="barraTitulo">
        <strong>Pedidos Entrantes</strong>
      </div>
<asp:Repeater ID="Repeater1" runat="server" ItemType="DAL.tel_Carrito" SelectMethod="GetCarrito">
    <ItemTemplate>
        <fieldset>
            <a href="<%# this.ResolveUrl(string.Format("~/Pedido.aspx?Id={0}",Eval("IdCarrito"))) %>">
            <%# Item.tel_Clientes.Nombre %> <%# Item.tel_Clientes.Apellido %>
            <br />
            <%# Item.Tel_Direcciones.Direccion %> 
            <%# Item.Tel_Direcciones.NroCasa %> 
            <%# Item.Tel_Direcciones.Direccion1 %> 
             (<%# Item.Tel_Direcciones.cuadrante %>) 
                <br />
            Suc: <%# Item.Tel_Direcciones.IdSucursal%>
                
            <br />
           <strong>
            (<%# Eval("TotalGeneral","{0:N2}")%>)
               <br />
               <%# Eval("Audit_Fecha","{0:dd-MM-yy HH:mm:ss}")%>
               </strong>
            </a>
         <%--   <asp:Button ID="btnDelete" CssClass="delete"  ToolTip="Eliminar este Pedido" OnClick="btnDelete_Click" CommandArgument="<%# Item.IdCarrito %>" OnClientClick="return confirm('Esta seguro que desea eliminar?');" runat="server" Text="X" />--%>
        </fieldset>

    </ItemTemplate>
    <SeparatorTemplate>
        <hr />
    </SeparatorTemplate>
</asp:Repeater>

<p>
   Ultima actualización: <asp:Label runat="server" ID="lblHora" />
    <asp:HiddenField ID="Notificar" runat="server" />
</p>



