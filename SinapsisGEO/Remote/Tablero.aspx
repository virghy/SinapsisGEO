<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tablero.aspx.cs" Inherits="SinapsisGEO.Remote.Tablero" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Futura Software - Tablero de Pedidos</title>
  <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" /> 
</head>
<body>

<%: Scripts.Render("~/bundles/modernizr") %>

   
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
         <Scripts>
       
        <asp:ScriptReference Name="jquery" />
        <asp:ScriptReference Name="jquery.ui.combined" />
        <asp:ScriptReference Name="WebForms.js"  Path="~/Scripts/WebForms/WebForms.js" />
        <asp:ScriptReference Name="WebUIValidation.js"  Path="~/Scripts/WebForms/WebUIValidation.js" />
        <asp:ScriptReference Name="MenuStandards.js"  Path="~/Scripts/WebForms/MenuStandards.js" />
        <asp:ScriptReference Name="GridView.js"  Path="~/Scripts/WebForms/GridView.js" />
        <asp:ScriptReference Name="DetailsView.js"  Path="~/Scripts/WebForms/DetailsView.js" />
        <asp:ScriptReference Name="TreeView.js"  Path="~/Scripts/WebForms/TreeView.js" />
        <asp:ScriptReference Name="WebParts.js"  Path="~/Scripts/WebForms/WebParts.js" />
        <asp:ScriptReference Name="Focus.js"  Path="~/Scripts/WebForms/Focus.js" />
        <asp:ScriptReference Name="WebFormsBundle" />

        
    </Scripts>
    </asp:ScriptManager>
    <script src="../Scripts/jquery.timer.js"></script>
        <style>
           .tableroRojo {
               background-color:red;
               width:10px;
               display:inline-block;
   
           }
           .tableroVerde {
               background-color:green;
               width:10px;
               display:inline-block;
   
           }

           .tableroAmarillo {
               background-color:yellow;
               width:10px;
               display:inline-block;
   
           }
         .tableroAzul {
               background-color:blue;
               width:10px;
               display:inline-block;
   
           }
        </style>
     


   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

   <div class="barraTitulo" >
            <h4>
            <strong>
                Sucursal Actual:
                 <asp:Label ID="lblSucursal" runat="server"></asp:Label>
                &nbsp;|&nbsp;Canal
            
        <select id="Filtro">
            <option value="00">Todos</option>
            <option value="01">Delivery</option>
            <option value="02">Carry Out</option>
        </select>
            &nbsp;|&nbsp;
                <a href='TiempoServicio.aspx?Id=<%=Request.QueryString["Id"]%>'>
            Tiempo de Servicio: 
            <asp:Label ID="lblTiempo" runat="server"></asp:Label>
                    </a>
                 &nbsp;|&nbsp;
                <a href='Faltantes.aspx?Id=<%=Request.QueryString["Id"]%>'>
            Faltantes </a>
            </strong>
        </h4>
        </div>
        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="30000">
           
        </asp:Timer>
    <div> 
   
                <asp:GridView ID="grvPedidos" runat="server" AutoGenerateColumns="False"
                CssClass="mGrid"  
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt" RowStyle-Height="25px" >
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:TemplateField HeaderText="Nro. ">
                            <ItemTemplate>
                                <a href='#' onclick='verPedido(<%# Eval("IdPedido")%>);'> 
                                    <%# Eval("NroPedido")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="Nombre" />
<%--                        <asp:HyperLinkField DataNavigateUrlFields="IdPedido" DataNavigateUrlFormatString="Verpedido.aspx?IdPedido={0}"
                            DataTextField="NroPedido" HeaderText="Nro." />--%>
<%--                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />--%>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                               
                                <div class='<%# Eval("Estado").ToString().StartsWith("P") && !Eval("Estado").ToString().Contains("L") &&  Convert.ToInt32(Eval("tCola"))>=5 ? "tableroRojo" 
                                : (Eval("Estado").ToString().StartsWith("V") ? "tableroAzul" 
                                : (Eval("Estado").ToString().StartsWith("E") ? "tableroAmarillo"
                                : (Eval("Estado").ToString().StartsWith("F") ? "tableroVerde": ""))) %> '>
                                    &nbsp&nbsp
                                </div>
                                <%# Eval("Estado") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Audit_Fecha" HeaderText="Hora" SortExpression="Audit_Fecha" DataFormatString="{0:dd-MMM HH:mm}" HtmlEncode="False" />
                        <asp:BoundField DataField="tCola" HeaderText="Tiempo Cola" ReadOnly="True" SortExpression="tCola" />
<%--                        <asp:BoundField DataField="tPreparacion" HeaderText="T. Prod." ReadOnly="True"
                            SortExpression="tPreparacion" />--%>
                        <asp:TemplateField HeaderText="Tiempo Prod." >
                            <ItemTemplate>
                                <asp:Label ID="Label1" Text='<%# Eval("tPreparacion")  %>'  CssClass='<%# Convert.ToInt32(Eval("tPreparacion"))>5 ? "error" : "" %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tiempo Viaj" >
                            <ItemTemplate>
                                <asp:Label ID="Label1" Text='<%# Eval("tEnvio")  %>'  CssClass='<%# Convert.ToInt32(Eval("tEnvio"))>30 ? "error" : "" %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
<%--                        <asp:BoundField DataField="tEnvio" HeaderText="T. Envio" ReadOnly="True" SortExpression="tEnvio" />--%>
                        <asp:BoundField DataField="tTotal" HeaderText="Tiempo Total" ReadOnly="True" SortExpression="tTotal" />
                        <asp:BoundField DataField="Anulado" HeaderText="Anul" ReadOnly="True" SortExpression="Anulado" />
                        <asp:TemplateField ItemStyle-Width="65px" >
                            <ItemTemplate>
                                <asp:Image ID="Image1" ImageUrl='<%# Eval("IdTipoPedido").ToString()=="02" ? "~/Images/carryout.png" : "~/Images/delivery.png"    %>' runat="server" />
                                <asp:Image ID="Image2" ImageUrl='<%# Eval("IdFormaPago").ToString()=="1" ? "~/Images/efectivo1.png" : "~/Images/tarjeta1.png"    %>' runat="server" />
                                <div style="display:none" >
                                <%#Eval("IdTipoPedido").ToString()=="02" ? "02" : "01"%>
                                </div>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pgr" />
                    <RowStyle Height="25px" />
                </asp:GridView>
    </div>

      

<p>
   Ultima actualización: <asp:Label runat="server" ID="lblHora" />
    <asp:HiddenField ID="Notificar" runat="server" />
</p>

 </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            
        </Triggers>

    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
               <img src="../Images/cargando.gif" />
            
        </ProgressTemplate>
    </asp:UpdateProgress>
  <script>

     


      //$(document).ready(function () {

      //    audioElement.setAttribute('src', 'alarma.mp3');
      //    audioElement.setAttribute('autoplay', 'autoplay');
      //    //audioElement.load()

      //    $.get();

      //    audioElement.addEventListener("load", function () {
      //        audioElement.play();
      //    }, true);

      //    $('.play').click(function () {
      //        audioElement.play();
      //    });

      //    $('.pause').click(function () {
      //        audioElement.pause();
      //    });
      //});

      function DoFiltrar()
      {
          //$(function () {
          //    Filtrar();
          //    function Filtrar() {
          //        var texto = $('#Filtro').val();
          //        if (texto == "00") {
          //            var rows = $("#grvPedidos tbody").find("tr").show();
          //            return;
          //        }

          //        var rows = $("#grvPedidos tbody").find("tr").hide();
          //        rows.filter(":contains('" + texto + "')").show();
          //        rows.first().show();

          //    };
          //});
      }



      $(function () {

          $('#Filtro')
                  .change(function () {
                      Filtrar();
                  });

          function Filtrar(){
              var texto = $('#Filtro').val();
              if (texto == "00") {
                  var rows = $("#grvPedidos tbody").find("tr").show();
                  return;
              }

              var rows = $("#grvPedidos tbody").find("tr").hide();
              rows.filter(":contains('" + texto + "')").show();
              rows.first().show();

          };


          var timer = $.timer(function () {
              if ($('#Notificar').val() == "S") {
                  audioElement.play();
              }

              //  alert('This message was sent by a timer.');
          });

          var idPedido;
          var audioElement = document.createElement('audio');

          timer.set({ time: 60000, autostart: true });

          audioElement.setAttribute('src', 'alarma.mp3');
          audioElement.setAttribute('autoplay', 'autoplay');

          $("#dialog-form").dialog({

              autoOpen: false,

              height: 600,

              width: 500,

              modal: true,

              buttons: {

                  "Aceptar": function () {

                      updatePedido();
                      $(this).dialog("close");


                  },

                  Cancel: function () {

                      $(this).dialog("close");

                  }

              },

              close: function () {

                  // allFields.val("").removeClass("ui-state-error");

              }

          });


      });

      function verPedido(id) {
          $("#dialog-form").dialog("open");
          //$("#panelDir").css("display", "none");
          //$("#panelCli").css("display", "block");
          idPedido = id;
          getPedido(id);
          return (false);
      };

      function updatePedido() {

            $.ajax({
                type: "POST",
                url: "../GEOService.asmx/PedidoUpdate",
                data: "{IdPedido: " + idPedido + " }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (response) {
                    var cl = response.d;
                    resultado = cl;
                    $("#dialog-form").dialog("close");
                },

                failure: function (msg) {

                    $('#error').text(msg);

                }

            });
            return resultado;

      }

      function getPedido(idPedido) {
          //            clearOverlays();

          $.ajax({

              type: "POST",
              url: "../GEOService.asmx/GetPedidobyId",
              data: "{IdPedido: " + idPedido + " }",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (response) {
                  var cl = response.d;

                  //alert(cl.Nombre);
                  $('#name').val(cl.NombreCliente);
                  $('#telefono').val(cl.Telefono);
                  $('#empresa').val(cl.Empresa);
                  $('#ruc').val(cl.RUC);
                  $('#direccion').val(cl.Direccion);
                  $('#obs').val(cl.Obs);
                  $('#referencia').val(cl.Referencia);
                  $('#cuadrante').val(cl.Cuadrante);
                  $('#tipoPedido').val(cl.TipoPedido);
                  $('#formapago').val(cl.FormaPago);
                  
                  $('#total').val(cl.Total);

                  $("#tdetalle tbody").children().remove();
                  $('#tdetalle tbody')
                  .append('<tr>'
                  + '<th>Producto</th>'
                  + '<th>Precio</th>'
                  + '<th>Cantidad</th>'
                  + '<th>Obs</th>'
                  + '</tr>');



                  $.each(cl.Detalle, function (index, det) {


                      //    $("#detalle ul").append('<li>Detalle</li>');


                      $('#tdetalle tbody')
                          .append('<tr>'
                          + '<td>' + det.IdProducto + det.Producto + '</td>'
                          + '<td>' + det.Precio + '</td>'
                          + '<td>' + det.Cantidad + '</td>'
                          + '<td>' + det.Obs + '</td>'
                          + '</tr>');
                  });

                  $("#tdetalle tr:even").addClass("alt");

                  //        $('#output').empty();



                  //$.each(cars, function (index, car) {

                  //    SetMarker(car.Data1, car.Lat, car.Lng);

                  //});

              },

              failure: function (msg) {

                  $('#error').text(msg);

              }

          });

      }

    </script>


<div id="dialog-form" style="display:none;" title="Datos del Pedido">

  <p class="validateTips"></p>

  <fieldset>
<legend></legend>
<div id="panelCli" style="display:inline-block">
    <input type="hidden" name="idCliente" id="idCliente" class="text ui-widget-content ui-corner-all" />
    <input type="hidden" name="idDir" value="0" id="idDir" class="text ui-widget-content ui-corner-all" />
        <label for="name">Nombre/e/e</label>

    <input readonly="true"  type="text" name="name" id="name" style="width:250px; " maxlength="50" class="text ui-widget-content ui-corner-all" />

    <label for="telefono">Telefono</label>
    <input type="text" name="telefono" id="telefono" value="" style="width:250px; " maxlength="50"  class="text ui-widget-content ui-corner-all" />

    <label for="empresa">Empresa</label>
    <input type="text" name="empresa" id="empresa" value=""style="width:250px; " maxlength="50" class="text ui-widget-content ui-corner-all" />

    <label for="ruc">RUC</label>
    <input type="text" name="ruc" id="ruc" value="" style="width:250px; "maxlength="20" class="text ui-widget-content ui-corner-all" />

    <label for="obs">OBS</label>
    <input type="text" name="obs" id="obs" style="width:250px; "   maxlength="50"  value="" class="text ui-widget-content ui-corner-all" />
</div>
<div id="panelDir" style="display:inline-block">

    <label for="direccion">Direccion</label>
    <input type="text" name="direccion" style="width:250px; " maxlength="50"   id="direccion" value="" class="text ui-widget-content ui-corner-all" />

    <label for="referencia">Referencia</label>
    <input type="text" name="referencia" id="referencia" maxlength="50" style="width:250px; "   value="" class="text ui-widget-content ui-corner-all" />

    <label for="cuadrante">Cuadrante</label>
    <input type="text" name="cuadrante" id="cuadrante" style="width:250px; " maxlength="5"  value="" class="text ui-widget-content ui-corner-all" />

    <label for="tipoPedido">Tipo Pedido</label>
    <input type="text" name="tipoPedido" id="tipoPedido" style="width:250px; " value="" class="text ui-widget-content ui-corner-all" />

    <label for="tipoPedido">Forma Pago</label>
    <input type="text" name="formapago" id="formapago" style="width:250px; " value="" class="text ui-widget-content ui-corner-all" />

    <label for="total">Importe</label>
    
    <input type="text" name="total" id="total" value="" class="text ui-widget-content ui-corner-all" />
 
</div>
  <div style="display:inline-block">
    <table id="tdetalle" class="mGrid">
        <tbody>
            <tr>
                <th scope="col">Producto</th>
                <th scope="col">Precio</th>
                <th scope="col">Cantidad</th>
                <th scope="col">Obs</th>
            </tr>

        </tbody>

    </table>
   </div> 
      <div>
    <label id="error"></label>
</div>
  </fieldset>

</div>


    </form>
</body>
</html>
