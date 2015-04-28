<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PedidosTop5.ascx.cs" Inherits="SinapsisGEO.Control.PedidosTop5" %>
  <script>
      $(function () {
          $("#accordion").accordion({
              heightStyle: "content",
              collapsible: true,
              active: false
          });
      });

  </script>

  <div class="barraTitulo">
        <strong>Ultimos Pedidos </strong>
      </div>
 
    <div id="accordion">
<asp:Repeater ID="Repeater1" ItemType="DAL.tel_Pedidos"  runat="server">
    <HeaderTemplate>
    

    </HeaderTemplate>
    <ItemTemplate>
    <h5>
        <asp:Label ID="IdPedidoLabel" runat="server" Text='<%# Eval("NroPedido") %>'></asp:Label>
 - 
        <asp:Label ID="FechaLabel" runat="server" Text='<%# Eval("Audit_Fecha", "{0:dd-MM-yy HH:mm}") %>'></asp:Label>&nbsp;-
        <asp:Label ID="TotalPedidoLabel" runat="server" Text='<%# Eval("TotalPedido", "{0:N0}") %>'></asp:Label>


    </h5>

      <div>
          <asp:Repeater ID="Repeater2" DataSource="<%# Item.tel_PedidosDet %>" ItemType="DAL.tel_PedidosDet" runat="server">
              <ItemTemplate>
                  <fieldset class="ui-state-highlight" >
                    (<%# Item.Cantidad %>) <%# Item.tel_Productos.Descripcion %> <%# " - " + Item.Obs %> (<%# String.Format("{0:N2}",(Item.Cantidad*Item.Precio)) %>)
                  </fieldset>
              </ItemTemplate>
          </asp:Repeater>
        <asp:Button ID="btnDuplicar" ToolTip="Duplicar este producto" OnClick="btnDuplicar_Click" CommandArgument="<%# Item.IdPedido %>" runat="server" Text="Duplicar" />
      <asp:HyperLink ImageHeight="18" ImageWidth="18" ID="HyperLink1" ToolTip="Mas Info" runat="server" ImageUrl="~/Images/Info.png" NavigateUrl='<%# String.Format("~/consultas/Verpedido.aspx?IdPedido={0}", Item.IdPedido) %>' >Mas Info</asp:HyperLink>
      </div> 

    </ItemTemplate>
    <SeparatorTemplate>
   
    </SeparatorTemplate>
    <FooterTemplate>
   
    </FooterTemplate>
</asp:Repeater>
        </div>
