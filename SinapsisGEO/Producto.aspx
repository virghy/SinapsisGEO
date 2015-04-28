<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="SinapsisGEO.Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .oculto
        {
            visibility:hidden;
        }
.content {
	min-height: 100%;
	position: relative;
	overflow: auto;
	z-index: 0; 
}

.background {
	position: absolute;
	z-index: -1;
	top: 0;
	bottom: 0;
	margin: 0;
	padding: 0;
}

.top_block {
	width: 100%;
	display: block; 
}

.bottom_block {
	position: absolute;
	width: 100%;
	display: block;
	bottom: 0; 
}

.left_block {
	display: block;
	float: left; 
}

.right_block {
	display: block;
	float: right; 
}

.center_block {
	display: block;
	width: auto; 
}

.background.panelIzq {
	height: auto !important;
	padding-bottom: 0;
	left: 0;
	width: 300px;
 
}

.panelIzq {
	height: auto;
	width: 300px;
	padding-bottom: 0px;
}



    </style>
    <script src="Scripts/Sinapsis.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<h3>CONFIRMAR PEDIDO</h3>
    <br />

    	<div class="content">
		<div class="background panelIzq">
		</div>
		<div class="left_block panelIzq">
			<div class="content">

<h3><asp:Label ID="lblProducto" runat="server"></asp:Label></h3>
            <div> 
                <asp:Image width="300" height="300" ID="imgProducto" runat="server" /> <%--<img src="images/productos/prod_grande.jpg" width="300" height="300" />--%></div>
            <h4>PRECIO: Gs. </h4>
            <div>
            <h4>
            <asp:Label ID="lblImporte" runat="server">0</asp:Label> </h4>
     <div class="cantidad">
          Cantidad 
          <asp:DropDownList OnClick="javascript:SumarAdicionales();" ID="cboCantidad" runat="server">
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
         <asp:Button ID="Button1" runat="server" Text="Agregar" />
        </div> 
			</div>
		</div>
	</div>
</div>
	
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

   <%-- <div class="spaceproducto">
	<h3 align="center">CONFIRMAR PEDIDO</h3><br />

	<table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-top:0px solid #f4ca00;">
  <tr>
            <td width="24%" align="center" valign="top" style="border-right:1px solid #a00202;">
          
            </td>
            <td width="76%" valign="top">
            
            <div class="agregados">
           

</div>


        
      
        
        <div class="enviar" >
        <a href="#" onclick="javascript:return AgregarCarrito();">
        <img alt="Agregar" src="images/btnagregar.jpg"  width="67" height="28" />
        </a>
        </div>
        
        </td>
          </tr>
        </table>


</div>--%>
                    <asp:Label ID="lblAdicional" Text="0" CssClass="oculto" runat="server"></asp:Label>
                    <asp:Label ID="lblItems" Text="0" CssClass="oculto" runat="server"></asp:Label>
                    <asp:Label ID="lblPrecio" CssClass="oculto" runat="server"></asp:Label>
                    <asp:Label ID="IdProducto" CssClass="oculto" runat="server"></asp:Label>

</asp:Content>
