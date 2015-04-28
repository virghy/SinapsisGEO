<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelProducto.ascx.cs" Inherits="SinapsisGEO.Control.PanelProducto" %>
<%@ Register Src="~/Control/PanelCarrito.ascx" TagPrefix="uc1" TagName="PanelCarrito" %>
<%@ Register Src="~/Control/PanelCombo.ascx" TagPrefix="uc1" TagName="PanelCombo" %>
<%@ Register Src="~/Control/PanelAviso.ascx" TagPrefix="uc1" TagName="PanelAviso" %>
<%@ Register Src="~/Control/PanelFaltante.ascx" TagPrefix="uc1" TagName="PanelFaltante" %>



<script type="text/javascript" src="Scripts/jquery.easyModal.js" ></script>


<script type = "text/javascript">

    function DisableButton(b)
    {
        //var submitButton = $(b, "input[type='submit']");
        //$(submitButton).attr("disabled", "true");
        $("#panelConfirmar").css("display", "none");
        $("#panelConfirmando").css("display", "block");
        //return true;

    }


    var defaultText = "Indicaciones";

    function WaterMark(txt, evt) {

        if (txt.value.length == 0 && evt.type == "blur") {

            txt.style.color = "gray";

            txt.value = defaultText;

        }

        if (txt.value == defaultText && evt.type == "focus") {

            txt.style.color = "black";

            txt.value = "";

        }

    }

</script>

<%--<asp:Repeater ID="Repeater1" ItemType="DAL.tel_Productos" SelectMethod="GetProductos" runat="server">
    <ItemTemplate>
        <asp:Button ID="btnProducto" runat="server" CommandArgument="<%#: Item.IdProducto %>" CommandName="<%#: Item.IdGrupo %>" Text="<%#: Item.Descripcion %>" OnClick="btnProducto_Click" />
    </ItemTemplate>
</asp:Repeater>--%>

<style>


/*Modal Popup*/
.modalBackground {
	background-color:Gray;
	filter:alpha(opacity=70);
	opacity:0.7;
}

.modalPopup {
	background-color:#ffffdd;
	border-width:3px;
	border-style:solid;
	border-color:Gray;
	padding:3px;
	width:400px;
}

.modalPopup p {
    padding: 5px;
}


 /**
 * Checkbox Three
 */

 /**
 * Start by hiding the checkboxes
 */
input[type=checkbox] {
	/*visibility: hidden;*/
}

.checkboxThree {
	width: 120px;
	height: 40px;
	background: #333;
	/*margin: 10px 10px;*/

	border-radius: 30px;
	position: relative;
}

/**
 * Create the text for the On position
 */
.checkboxThree:before {
	content: 'Si';
	position: absolute;
	top: 12px;
	left: 13px;
	height: 2px;
	color: #26ca28;
	font-size: 16px;
}  

/**
 * Create the label for the off position
 */
.checkboxThree:after {
	content: 'No';
	position: absolute;
	top: 12px;
	left: 84px;
	height: 2px;
	color: #111;
	font-size: 16px;
}

/**
 * Create the pill to click
 */
.checkboxThree label {
	display: block;
	width: 52px;
	height: 22px;
	border-radius: 50px;

	-webkit-transition: all .5s ease;
	-moz-transition: all .5s ease;
	-o-transition: all .5s ease;
	-ms-transition: all .5s ease;
	transition: all .5s ease;
	cursor: pointer;
	position: absolute;
	top: 9px;
	z-index: 1;
	left: 12px;
	background: #ddd;
}

/**
 * Create the checkbox event for the label
 */
.checkboxThree input[type=checkbox]:checked + label {
	left: 60px;
	background: #26ca28;
}




</style>

<div id="contenedor">

  <div id ="barraMenu">
            <table>
                <tr>
                    <td>
      <asp:Menu ID="Menu1" RenderingMode="List" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal" BackColor="#E3EAEB" DynamicHorizontalOffset="2" ForeColor="#666666" StaticSubMenuIndent="10px">

          <DynamicHoverStyle BackColor="#666666" ForeColor="White"></DynamicHoverStyle>

          <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px"></DynamicMenuItemStyle>

          <DynamicMenuStyle BackColor="#E3EAEB"></DynamicMenuStyle>

          <DynamicSelectedStyle BackColor="#ff9900"></DynamicSelectedStyle>

          <StaticHoverStyle BackColor="#666666" ForeColor="White"></StaticHoverStyle>

          <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px"></StaticMenuItemStyle>

          <StaticSelectedStyle BackColor="#ff9900"></StaticSelectedStyle>
      </asp:Menu>
                        
<%--                        <asp:Button ID="btnAnterior" runat="server" Text="Volver" Enabled="false" OnClick="btnAnterior_Click" /></td>--%>
                    <td>
                        <asp:CheckBox runat="server" Visible="false" ID="chkMitad" />
<%--                        <asp:Label ID="Label1" runat="server" ForeColor="White" AssociatedControlID="chkMitad" CssClass="checkbox">¿Mitad/Mitad?</asp:Label>--%>
                        <%-- <asp:Label ID="Label1" runat="server" ForeColor="White" AssociatedControlID="checkboxThreeInput" CssClass="checkbox">¿Mitad/Mitad?</asp:Label>--%>
                    </td>
                    <td>
                        <%--  	                    <div class="checkboxThree">
                            <input type="checkbox" value="0" runat="server" id="checkboxThreeInput" name="" />
                              <label for="checkboxThreeInput"></label>     
  	                    </div>--%>
                        

                    </td>
                </tr>
            </table>


              <!-- Squared ONE -->
            <%--      <div class="squaredOne">
                  Mitad: 
	              <input type="checkbox" value="None" id="squaredOne" name="check" checked />
	              <label for="squaredOne"></label>
              </div>--%>


    
  </div>
<div id="panelIzquierda">
    <uc1:PanelAviso runat="server" ID="PanelAviso1" />

</div>

  <div id ="izquierda">

<asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
<asp:HiddenField ID="txtIdFamilia" runat="server" />
<asp:HiddenField ID="txtIdLinea" runat="server" />
<asp:HiddenField ID="txtIdGrupo" runat="server" />

<asp:DataList ID="dlFamilia" runat="server" RepeatColumns="4" CellSpacing="2" RepeatDirection="Horizontal">
    <ItemTemplate>

        <asp:Button Width="150px" Height="100px" ID="btnProducto1" runat="server" CommandArgument='<%# Eval("IdFamilia") %>' Text='<%# Eval("Familia") %>' CommandName="F" OnClick="btnProducto_Click"/>
        
    </ItemTemplate>
</asp:DataList>


<asp:DataList ID="dlLinea" runat="server" RepeatColumns="4" CellSpacing="2" RepeatDirection="Horizontal">
    <ItemTemplate>

        <asp:Button Width="150px" Height="100px" ID="btnProducto1" runat="server" CommandArgument='<%# Eval("IdLinea") %>' CommandName='L' Text='<%# Eval("Linea") %>' OnClick="btnProducto_Click"/>
        
    </ItemTemplate>
</asp:DataList>

<asp:DataList ID="dlGrupo" runat="server" RepeatColumns="4" CellSpacing="2" RepeatDirection="Horizontal">
    <ItemTemplate>

        <asp:Button Width="150px" Height="100px" ID="btnProducto1" runat="server" CommandArgument='<%# Eval("IdGrupo") %>' CommandName='G' Text='<%# Eval("Grupo") %>' OnClick="btnProducto_Click"/>
        
    </ItemTemplate>
</asp:DataList>

<asp:DataList ID="dlProducto" runat="server" RepeatLayout="Flow" RepeatColumns="3" RepeatDirection="Horizontal">
    <ItemTemplate>
        <asp:LinkButton ID="btnAgregar" CommandArgument='<%# Eval("IdProducto") %>' CommandName='P' OnClick="btnAgregar_Click" runat="server">
                <div id="producto">
                            <strong>
                        <%# Eval("Descripcion") %>
                                </strong>
                        <br />

                        <%# Eval("Contenido") %>
             
                </div>
        </asp:LinkButton>  

    </ItemTemplate>
</asp:DataList>

        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup" 
            TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="programmaticPopup"
            BackgroundCssClass="modalBackground" CancelControlID="CancelButton">
        </ajaxToolkit:ModalPopupExtender>

 <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup" Style="display: none;
            width: 400px; padding: 10px">
                  <uc1:PanelCombo runat="server" ID="PanelCombo" />      

            <%--<a id="hideModalPopupViaClientButton" href="#">Cancelar</a>.--%>
             <p>
                    <asp:TextBox ID="txtObs" Text="Indicaciones" ForeColor="Gray" TextMode="SingleLine" runat="server" Visible='<%# Convert.ToBoolean(Eval("EsCombo")) != true %>' onblur = "WaterMark(this, event);" 
                    onfocus = "WaterMark(this, event);">
                    </asp:TextBox>

                 <asp:Button ID="cmdAgregar" runat="server" Text="Agregar" CommandName="C" OnClick="btnAgregar_Click" />
                 <asp:Button ID="CancelButton" runat="server" Text="Cancelar" />

             </p>
        </asp:Panel>
     


  </div>
  <div id ="derecha">
      <div id="barraTitulo" class="barraTitulo">
          <strong>Pedido Actual</strong>
      </div>
<div id="panelConfirmar">
    <asp:Repeater ID="Pedido" runat="server" ItemType="DAL.tel_Carrito" SelectMethod="GetCarritoActual">
    <ItemTemplate>
        <fieldset>

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
               </strong>
            <hr />
              <asp:Repeater ID="PedidoDet" runat="server" DataSource="<%# Item.tel_Carrito_Item  %>" ItemType="DAL.tel_Carrito_Item ">
                <ItemTemplate>
                    <fieldset>

                        (<%# Item.Cantidad %>) <%# Item.tel_Productos.Descripcion %> <%# " - " + Item.Obs %> (<%# String.Format("{0:N2}",(Item.Cantidad*Item.Precio)) %>)
<%--                        <asp:ImageButton CssClass="delete" Visible='<%# Item.IdCIPadre == null %>' Width="20px" Height="20px" ImageUrl="~/Images/delete.jpg" OnClick="btnBorraItem_Click" ID="btnBorraItem" CommandArgument="<%# Item.IdCarritoItem %>" runat="server" />--%>
                        <asp:Button ID="btnBorraItem" CssClass="delete" Visible='<%# Item.IdCIPadre == null %>'  ToolTip="Eliminar este producto" OnClick="btnBorraItem_Click"  CommandArgument="<%# Item.IdCarritoItem %>" OnClientClick="return confirm('Esta seguro que desea eliminar?');" runat="server" Text="X" />

                    </fieldset>

                </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
            
                <asp:Button ID="btnConfirmar" OnClientClick="DisableButton(this); return true;" OnClick="btnConfirmar_Click" runat="server" Text="Confirmar" />
            </div>
            <div id="panelConfirmando" style="display:none;">
                <img src="Images/cargando.gif" />
                <h3>Aguarde un momento.</h3>
                <h4>Enviado...</h4>
            </div>
        </fieldset>

    </ItemTemplate>
    <SeparatorTemplate>

    </SeparatorTemplate>
</asp:Repeater>
      
      <uc1:PanelCarrito runat="server" ID="PanelCarrito" />

  </div>
 

</div>
 
    </div>