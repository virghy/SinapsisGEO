<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelAddProducto.ascx.cs" Inherits="SinapsisGEO.Control.PanelAddProducto" %>
<%@ Register Src="~/Control/Opciones.ascx" TagPrefix="uc1" TagName="Opciones" %>

<script>
    $(document).ready(function () {
        $("#mitadMitad").css("display", "none");
        $("MainContent_PanelAddProducto_chkMitadMitad").click(function () {
            $("#mitadMitad").css("display", "block");
        });
    });

</script>


<div id="contenedor">
  <div id ="cabecera">

  </div>

  <div id ="barraMenu">
      
      <h3 style="color:white;">AGREGAR PRODUCTO</h3>
</div>
  <div id ="izquierda">


<table style="width: 100%;">
    <tr>
        <td>
            
<h3><asp:Label ID="lblProducto" runat="server"></asp:Label></h3>
            <div> 
                <asp:Image width="100" height="100" ID="imgProducto" runat="server" /> <%--<img src="images/productos/prod_grande.jpg" width="300" height="300" />--%>
            </div>

        </td>
        <td><div class="cantidad">

                        <asp:Label ID="Label1" runat="server" AssociatedControlID="chkMitad" CssClass="checkbox">¿Mitad/Mitad?</asp:Label>
                        <asp:CheckBox runat="server" ID="chkMitad" onClick='$("#MitadMitad").toggle();' />

              <%--  <asp:CheckBox ID="chkMitadMitad" runat="server" onClick='$("#MitadMitad").toggle();' Text="Pedir Mitad/Mitad?"  />--%>

            <div id="MitadMitad" style="display: none;">
                Seleccione la otra midad: <asp:DropDownList ID="cboMitad" ItemType="DAL.tel_Productos" DataTextField="Descripcion" DataValueField="IdProducto" runat="server"></asp:DropDownList>
            </div>
                        <h4>PRECIO: Gs. 
                            <asp:Label ID="lblImporte" runat="server">0</asp:Label> </h4>
          Cantidad 
          <asp:DropDownList ID="cboCantidad" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
         <asp:Button ID="cmdAgregar" runat="server" Text="Agregar" OnClick="Button1_Click" />
            <br />
            Indicaciones: <asp:TextBox ID="txtIndicaciones" Width="200px" runat="server"></asp:TextBox>
            <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
        </div> </td>
        <td>
            <h4>
            Agregados:</h4>
            <br />
            <asp:ListBox ID="lstAgregados" runat="server"></asp:ListBox>


            <asp:Button ID="cmdBorrarItem" OnClick="cmdBorrarItem_Click" runat="server" Text="<=" />


        </td>
    </tr>
    <tr>
        <td colspan="3">
            (Los precios son referenciales y serán actualizados al agregar al pedido)
        </td>
    </tr>
    <tr>
        <td colspan="3">
 
         <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <div style="display:grid;">
            <asp:Repeater ID="rptOpciones" ItemType="DAL.tel_ProductoOpcion" runat="server">

                <ItemTemplate>
                    <uc1:Opciones runat="server" IdOpcion="<%# Item.IdOpcion %>" ID="Opciones" />
                </ItemTemplate>
            </asp:Repeater>
            </div>
             <asp:Label ID="lblAdicional" Text="0" CssClass="oculto" runat="server"></asp:Label>
                    <asp:Label ID="lblItems" Text="0" CssClass="oculto" runat="server"></asp:Label>
                    <asp:Label ID="lblPrecio" Visible="false" CssClass="oculto" runat="server"></asp:Label>
                    <asp:Label ID="IdProducto" CssClass="oculto" runat="server"></asp:Label>
                    <asp:Label ID="EsCombo" CssClass="oculto" runat="server"></asp:Label>
        <asp:Button ID="cmdCancel" runat="server" Text="Volver" OnClick="cmdCancel_Click" />
        </td>
    </tr>
</table>
</div>



	
       

  
               
