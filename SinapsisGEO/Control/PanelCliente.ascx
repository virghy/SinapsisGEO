<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCliente.ascx.cs" Inherits="SinapsisGEO.Control.PanelCliente" %>
<%@ Register Src="~/Control/PanelCarrito.ascx" TagPrefix="uc1" TagName="PanelCarrito" %>
<%@ Register Src="~/Control/PedidosTop5.ascx" TagPrefix="uc1" TagName="PedidosTop5" %>

<script>

    var esDireccion = false,
        esNuevo = false,
        rowIndex = 0;
    $(function () {

        var name = $("#name"),

          apellido = $("#apellido"),

          empresa = $("#empresa"),

          ruc = $("#ruc"),

          obs = $("#obs"),
          direccion = $("#direccion"),
          nro = $("#nro"),
          direccion1 = $("#direccion1"),
          referencia = $("#referencia"),
          cuadrante = $("#cuadrante"),
          sucursal = $("#sucursal"),
          diplomatico = $("#diplomatico"),
          allFields = $([]).add(name).add(apellido).add(empresa).add(ruc).add(obs).add(direccion).add(nro).add(direccion1).add(referencia).add(cuadrante).add(sucursal).add(diplomatico),

          tips = $(".validateTips"),
          idCliente = 0;
         
 


        $.ajax({
            type: "POST",
            url: "GEOService.asmx/GetSucursales",
            data: "{}",
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //       $("#ddlLanguage").empty().append($("<option></option>").val("[-]").html("Seleccione Sucursal")); 
                $.each(data.d, function () {
                    $("#sucursal").append($("<option></option>").val(this['IdSucursal']).html(this['Nombre']));
                });
                $("#sucursal").val(1);

            },
            failure: function (msg) {
                $('#error').text(msg);
            }
        });



        function updateCliente() {
            //            clearOverlays();

            var cliente = new Object();
            var resultado = -1;
            cliente.IdCliente = $('#idCliente').val();
            cliente.IdDireccion = $('#idDir').val();
            cliente.Nombre = $('#name').val();
            cliente.Apellido = $('#apellido').val();
            cliente.Empresa = $('#empresa').val();
            cliente.RUC = $('#ruc').val();
            cliente.Obs = $('#obs').val();
            cliente.Diplomatico = $('#diplomatico').is(":checked");

            cliente.Telefono = $("#<%=txtTelefono.ClientID %>").val();

            cliente.Direccion = $('#direccion').val();

            if ($('#nro').val().length > 0)
            {
                cliente.Nro = $('#nro').val();
            }
            
            cliente.Direccion1 = $('#direccion1').val();
            cliente.Referencia = $('#referencia').val();
            cliente.Cuadrante = $('#cuadrante').val();
            cliente.IdSucursal = $('#sucursal').val();

            cliente.EditandoDireccion = esDireccion;

            var customerString = JSON.stringify(cliente);
            var urlws;

            //$('#error').text(customerString);

            //if (esDireccion) {
            //    urlws = "../GEOService.asmx/DireccionUpdate"
            //}
            //else
            //{
            //    urlws = "../GEOService.asmx/ClienteUpdate"
            //}

            $.ajax({
                type: "POST",
                url: "GEOService.asmx/ClienteUpdate",
                data: "{cliente: " + customerString + " }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (response) {
                    var cl = response.d;
                    resultado = cl;
                    $("#dialog-form").dialog("close");

                    if (!esDireccion) {
                       WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$MainContent$PanelCliente$btnBuscar", "", false, "", "", false, true));
                    }
                    else
                    {
                        rowIndex = $('#idRow').val();

                        //alert("ctl00$MainContent$PanelCliente$grvClientes$ctl0" + rowIndex.toString() + "$cmdSelect");
                        WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$MainContent$PanelCliente$grvClientes$ctl02$cmdSelect", "", true, "", "", false, true))

                        if (rowIndex < 10) {
                            //WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$MainContent$PanelCliente$grvClientes$ctl0" + rowIndex.toString() + "$cmdSelect", "", false, "", "", false, true))

                        }
                        else {
                            //WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$MainContent$PanelCliente$grvClientes$ctl" + rowIndex.toString() + "$cmdSelect", "", false, "", "", false, true))
                        }
                        //WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$MainContent$PanelCliente$grvClientes$ctl14$cmdSelect", "", true, "", "", false, true))
                      //  __doPostBack('ctl00$MainContent$PanelCliente$grvClientes', 'Select$'+ rowIndex.toString());
                    }
                },

                failure: function (msg) {

                    $('#error').text(msg);

                }

            });
            return resultado;

        }


        function updateTips(t) {

            tips

              .text(t)

              .addClass("ui-state-highlight");

            setTimeout(function () {

                tips.removeClass("ui-state-highlight", 1500);

            }, 500);

        }



        function checkLength(o, n, min, max) {

            if (o.val().length > max || o.val().trim().length < min) {

                o.addClass("ui-state-error");

                updateTips("La longitud de " + n + " debe estar entre " +

                  min + " y " + max + ".");

                return false;

            } else {

                return true;

            }

        }



        function checkRegexp(o, regexp, n) {

            if (!(regexp.test(o.val()))) {

                o.addClass("ui-state-error");

                updateTips(n);

                return false;

            } else {

                return true;

            }

        }



        $("#dialog-form").dialog({

            autoOpen: false,

            height: 520,

            width: 450,

            modal: true,

            buttons: {

                "Aceptar": function () {

                    var bValid = true;

                    allFields.removeClass("ui-state-error");


                    if (esDireccion == false) {
                        bValid = bValid && checkLength(name, "Nombre", 3, 50);

                        bValid = bValid && checkLength(apellido, "Apellido", 1, 50);

                        bValid = bValid && checkLength(empresa, "Empresa", 0, 50);

                    }

                    if (esNuevo == true | esDireccion==true)
                    {
                        bValid = bValid && checkLength(direccion, "Direccion", 3, 50);
                        bValid = bValid && checkLength(cuadrante, "Cuadrante", 1, 10);
                        bValid = bValid && checkRegexp(nro, /^$|^([0-9])+$/, "Ingrese un valor numérico.");

                    }
                    



                    //  bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z_])+$/i, "Username may consist of a-z, 0-9, underscores, begin with a letter.");

                    // From jquery.validate.js (by joern), contributed by Scott Gonzalez: http://projects.scottsplayground.com/email_address_validation/

                    //   bValid = bValid && checkRegexp(email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "eg. ui@jquery.com");

                    //   bValid = bValid && checkRegexp(password, /^([0-9a-zA-Z])+$/, "Password field only allow : a-z 0-9");



                    if (bValid) {

                        if (updateCliente() == 0) {
                            $(this).dialog("close");
                        }



                    }

                },

                Cancel: function () {

                    $(this).dialog("close");

                }

            },

            close: function () {

                allFields.val("").removeClass("ui-state-error");

            }

        });

        $('#btnResolver')

               .button()

               .click(function () {
                   var cl = new Object();
                 
                   cl.Calle1 = $('#direccion').val();
                   cl.Calle2 = $('#direccion1').val();
                   cl.Calle3 = "";
                   cl.Nro = $('#nro').val();
                 

            var customerString = JSON.stringify(cl);

                   $.ajax({
                       url: '<%=ResolveUrl("~/GEOService.asmx/GetCuadrante") %>',
                       data: "{cal: " + customerString + "}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    var cl = data.d;
                                    //alert(cl.Nombre);
                                    $('#cuadrante').val(cl.Cuadrante);

                                    if (cl.Sucursal !=0) {
                                        $('#sucursal').val(cl.Sucursal);
                                    }


                                },
                                error: function (response) {
                                    alert(response.responseText);
                                },
                                failure: function (response) {
                                    alert(response.responseText);
                                }
                            });


                   return (false);

               });

        $('#<%= cmdAgregar.ClientID %>')

               .button()

               .click(function () {

                   if ($("#<%=txtTelefono.ClientID %>").val().length > 0) {
                       $("#dialog-form").dialog("open");
                       $('#idCliente').val(0);

                       $("#panelDir").css("display", "block");
                       $("#panelCli").css("display", "block");
                       esNuevo = true;
                       esDireccion = false;
                   }
                   //              getCliente();

                   return (false);

               });


        $("#direccion").autocomplete({
            source: function (request, response) {
                var cl = new Object();

                cl = request.term;
                
                var customerString = JSON.stringify(cl);
                $.ajax({
                    url: '<%=ResolveUrl("~/GEOService.asmx/GetCalles") %>',
                    data: "{ Nombre: " + customerString + "}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },

        minLength: 3
    });



        $("#direccion1").autocomplete({
            source: function (request, response) {

                var cl = new Object();

                cl = request.term;

                var customerString = JSON.stringify(cl);

                $.ajax({
                    url: '<%=ResolveUrl("~/GEOService.asmx/GetCalles") %>',
                    data: "{ Nombre: " + customerString + "}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.split('-')[0],
                                val: item.split('-')[1]
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },

            minLength: 3
        });

    });



    function EditarCliente(id) {
        $("#dialog-form").dialog("open");
        $("#panelDir").css("display", "none");
        $("#panelCli").css("display", "block");
        esNuevo = false;
        esDireccion = false;
        getCliente(id);
        return (false);
    }

    function EditarDir(id) {
        $("#dialog-form").dialog("open");
        $("#panelDir").css("display", "block");
        $("#panelCli").css("display", "none");
        esNuevo = false;
        esDireccion = true;
        getDireccion(id);
        return (false);
    }

    function AddDir(id,ri) {
        $("#dialog-form").dialog("open");
        $("#panelDir").css("display", "block");
        $("#panelCli").css("display", "none");
        esNuevo = true;
        esDireccion = true;
        rowIndex = ri;
        //getDireccion(id);
        $("#idCliente").val(id);
        return (false);
    }

    function AddCliente() {

             if ($("#<%=txtTelefono.ClientID %>").val().length > 0) {
                  $("#dialog-form").dialog("open");
                  $('#idCliente').val(0);
                  $("#panelDir").css("display", "block");
                  $("#panelCli").css("display", "block");

                  $('#diplomatico').prop('checked', false);
                  esNuevo = true;
                  esDireccion = false;
              }
              //              getCliente();

              return (false);

    }

    function setRowId(idrow)
    {
        rowIndex = idrow;
        $('#idRow').val(idRow);
    }

    function getCliente(IdCliente) {
        //            clearOverlays();

        $.ajax({

            type: "POST",
            url: "GEOService.asmx/GetCliente",
            data: "{IdCliente: " + IdCliente + " }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                var cl = response.d;
                //alert(cl.Nombre);
                $('#name').val(cl.Nombre);
                $('#apellido').val(cl.Apellido);
                $('#empresa').val(cl.Empresa);
                $('#ruc').val(cl.RUC);
                $('#obs').val(cl.Obs);
                $('#diplomatico').prop('checked', cl.Diplomatico);
                $('#idCliente').val(cl.IdCliente);

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

    function getDireccion(IdDireccion) {
        //            clearOverlays();

        $.ajax({

            type: "POST",
            url: "GEOService.asmx/GetDireccion",
            data: "{IdDireccion: " + IdDireccion + " }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                var cl = response.d;
                //alert(cl.Nombre);
                $('#direccion').val(cl.Direccion);
                $('#nro').val(cl.Nro);
                $('#direccion1').val(cl.Direccion1);
                $('#sucursal').val(cl.IdSucursal);
                $('#referencia').val(cl.Referencia);
                $('#idCliente').val(cl.IdCliente);
                $('#idDir').val(cl.IdDireccion);
                $('#cuadrante').val(cl.Cuadrante);

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

<%--<asp:FormView ID="fvCliente" SelectMethod="GetCliente" ItemType="DAL.tel_Clientes" runat="server">
    <ItemTemplate>
        <%#: Item.Nombres %>  
    </ItemTemplate>

</asp:FormView>--%>



<div id="contenedor">

  <div id ="barraMenu">
      <p >
    
          <asp:Label ForeColor="White" Font-Bold="true" runat="server" ID="label1" Text="Nro Teléfono:"></asp:Label>
    <asp:TextBox ID="txtTelefono" Width="120px" runat="server"></asp:TextBox>

<asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    <asp:Button ID="cmdAgregar" runat="server" Text="Agregar Cliente" OnClick="cmdAgregar_Click" />
<%--    <button id="create-user">Agregar Cliente</button>--%>
<%--    <asp:Button ID="btnAddDir" Visible="false" runat="server" Text="Agregar Direccion" OnClick="btnAddDir_Click" />--%>
    <asp:Label ForeColor="White" Font-Bold="true" runat="server" ID="label2" Text="Tipo Pedido:"></asp:Label>
    <asp:DropDownList ID="cboTipoPedido" AppendDataBoundItems="true" runat="server">
        <asp:ListItem Text="Delivery" Value="01"></asp:ListItem>
        <asp:ListItem Text="Carry Out" Value="02"></asp:ListItem>
        <asp:ListItem Text="Delivery 10.000" Value="03"></asp:ListItem>
        <asp:ListItem Text="Delivery 12.000" Value="04"></asp:ListItem>
    </asp:DropDownList>

      <asp:HyperLink ID="HyperLink1" ForeColor="White" NavigateUrl="~/Llamadas.aspx" runat="server">Registro de Llamadas</asp:HyperLink>
          
</p>

  </div>

  <div id ="izquierda">
<asp:GridView ID="grvClientes" 
                CssClass="mGrid"  
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt" Width="750"

    OnSelectedIndexChanged="grvClientes_SelectedIndexChanged" DataKeyNames="IdCliente" AutoGenerateColumns="False" ItemType="DAL.tel_Clientes" runat="server" >
   
    <Columns>
        <asp:BoundField DataField="IdCliente" HeaderText="Id" />
        <asp:BoundField DataField="Nombres" HeaderText="Nombre" />
        <asp:BoundField DataField="Empresa" HeaderText="Empresa/Razon Social" />
        <asp:BoundField DataField="RUC" HeaderText="Ruc" />
        <asp:BoundField DataField="Obs" HeaderText="Obs" />
<%--        <asp:CommandField ShowSelectButton="True" />--%>
        <asp:TemplateField>
<%--                <ItemTemplate><a href="Clientes.aspx?IdCliente=<%#: Item.IdCliente %>">Editar</a></ItemTemplate>--%>
            <ItemTemplate>
                <asp:LinkButton ID="cmdSelect" CommandName="select" OnClientClick='<%# String.Format("setRowId({0})", grvClientes.Rows.Count ) %>' runat="server">Seleccionar</asp:LinkButton>
                <a  onclick='<%# String.Format("EditarCliente({0});", Item.IdCliente) %>' href="#">Editar</a>
                <a  onclick='<%# String.Format("AddDir({0},{1});", Item.IdCliente,grvClientes.Rows.Count) %>' href="#">Agregar Dir.</a>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
    <EmptyDataTemplate>
        No se encuentra ningún cliente con ese teléfono.
    </EmptyDataTemplate>
    <SelectedRowStyle CssClass="GridSelectedRow" BackColor="PaleGoldenrod" />
</asp:GridView>

<asp:Repeater ID="ASPxDataView1" runat="server">

<ItemTemplate>
<div id="producto">
   <strong>Direccion: </strong>
        <%# Eval("Direccion") %>
        <%# Eval("NroCasa") %>
        <%# Eval("Direccion1") %>
        <br />
        <%# Eval("referencia") %>
        
        <br />
        <strong>Cuadrante: </strong>
        <%# Eval("Cuadrante") %>
        
        <br />
        <strong>Sucursal: </strong>
        <%# Eval("IdSucursal") %>

        <br />
<%--        <asp:Button ID="btnEdit" CommandArgument='<%# Eval("Id") %>' CommandName="Select"  runat="server" Text="Editar" OnClick="btnEdit_Click" />--%>
        <a  onclick='<%# String.Format("EditarDir({0});", Eval("Id")) %>' href="#">Editar</a>
           
         <asp:Button ID="btnAddPedido" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Crear Pedido" OnClick="btnAddPedido_Click" />

</div>
</ItemTemplate>
      </asp:Repeater>



<asp:FormView ID="fvDireccion" InsertMethod="fvDireccion_InsertItem" UpdateMethod="fvDireccion_UpdateItem" SelectMethod="GetDireccion" ItemType="DAL.Tel_Direcciones" DataKeyNames="Id" runat="server">
    <EditItemTemplate>
        <table>
            <tr>
                <td>Direccion:</td>
                <td>
                    <asp:HiddenField ID="Id" runat="server" Value='<%# BindItem.Id %>'></asp:HiddenField>
                    
                    <asp:TextBox ID="txtDireccion" MaxLength="50" runat="server" Text='<%# BindItem.Direccion %>'></asp:TextBox>
                    
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Nro:</td>
                <td>
                    <asp:TextBox ID="txtNro" TextMode="Number" runat="server" Text='<%# BindItem.NroCasa %>'></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Direccion 1:</td>
                <td>
                    <asp:TextBox ID="txtDireccion1" MaxLength="50" runat="server" Text='<%# BindItem.Direccion1 %>'></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Referencia</td>
                <td>
                    <asp:TextBox ID="txtReferencia" MaxLength="50" runat="server" Text='<%# BindItem.referencia %>'></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Cuadrante</td>
                <td>
                    <asp:TextBox ID="txtCuadrante" runat="server" Text='<%# BindItem.cuadrante %>'></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Sucursal</td>
                <td>
<%--                    <asp:TextBox ID="txtSucursal" runat="server" Text='<%# BindItem.IdSucursal %>'></asp:TextBox>--%>
                    <asp:DropDownList ID="cboSucursal" SelectedValue="<%# BindItem.IdSucursal %>" SelectMethod="GetSucursal" DataTextField="Sucursal" DataValueField="IdSucursal" runat="server"></asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CommandName="Update"/></td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CommandName="Cancel" /></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </EditItemTemplate>
    <InsertItemTemplate>
        <table>
            <tr>
                <td>Id:</td>
                <td><asp:TextBox ID="IdDireccion" runat="server" Text='<%# BindItem.Id %>'></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td>Direccion:</td>
                <td>
                 <%--   <asp:HiddenField ID="IdDireccion" runat="server" Value='<%# BindItem.Id %>'></asp:HiddenField>--%>
                    <asp:TextBox ID="txtDireccion" MaxLength="50"  runat="server" Text='<%# BindItem.Direccion %>'></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Nro:</td>
                <td>
                    <asp:TextBox ID="txtNro" runat="server" Text='<%# BindItem.NroCasa %>'></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Direccion 1:</td>
                <td>
                    <asp:TextBox ID="txtDireccion1" MaxLength="50" runat="server" Text='<%# BindItem.Direccion1 %>'></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Referencia</td>
                <td>
                    <asp:TextBox ID="txtReferencia" MaxLength="50" runat="server" Text='<%# BindItem.referencia %>'></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Cuadrante</td>
                <td>
                    <asp:TextBox ID="txtCuadrante" runat="server" Text='<%# BindItem.cuadrante %>'></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Sucursal</td>
                <td>
                    <%--<asp:TextBox ID="txtSucursal" runat="server" Text='<%# BindItem.IdSucursal %>'></asp:TextBox>--%>
                    <asp:DropDownList ID="cboSucursal" SelectedValue="<%# BindItem.IdSucursal %>" SelectMethod="GetSucursal" DataTextField="Sucursal" DataValueField="IdSucursal" runat="server"></asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CommandName="Insert"/></td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CommandName="Cancel" /></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </InsertItemTemplate>
</asp:FormView>



<%--<div class="menu">
<ul>

<asp:Repeater ID="rptDirecciones" ItemType="DAL.Tel_Direcciones" SelectMethod="GetDirecciones" runat="server">
    <ItemTemplate>
        <li>
            <%#: Item.Direccion %>
            <%#: Item.Direccion1 %>
            <%#: Item.NroCasa %>
            <br />
            <%#: Item.referencia %>

        </li>
    </ItemTemplate>
</asp:Repeater>
</ul>
</div>--%>

 
    <asp:FormView ID="fvCliente" DataKeyNames="IdCliente" ItemType="DAL.tel_Clientes" InsertMethod="dvClientes_InsertItem" Visible="false" UpdateMethod="dvClientes_UpdateItem" runat="server" SelectMethod="GetClienteById">
        <HeaderTemplate>
            <h3>Detalle del Cliente</h3>
        </HeaderTemplate>
        <EditItemTemplate>
            <fieldset>
                <ul>
                    <li><asp:Label ID="Label1" runat="server" AssociatedControlID="firstName">Nombre: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="firstName" Text='<%# BindItem.Nombre %>' /> </li>

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
                <asp:Button ID="Button2" runat="server" PostBackUrl="~/Default.aspx" CommandName="Cancel" Text="Cancelar" CausesValidation="false" />

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
                    <li><asp:TextBox runat="server" ID="firstName" Text='<%# BindItem.Nombre %>' /> </li>

                    <li><asp:Label ID="Label2" runat="server" AssociatedControlID="txtApellido">Apellido: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtApellido" Text='<%# BindItem.Apellido %>' /> </li>

                    <li><asp:Label ID="Label3" runat="server" AssociatedControlID="txtEmpresa">Empresa: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtEmpresa" Text='<%# BindItem.Empresa %>' /> </li>

                    <li><asp:Label ID="Label6" runat="server" AssociatedControlID="txtRUC">RUC: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtRUC" Text='<%# BindItem.RUC %>' /> </li>


                    <li><asp:Label ID="Label5" runat="server" AssociatedControlID="txtObs">Obs: </asp:Label></li>
                    <li><asp:TextBox runat="server" ID="txtObs" Text='<%# BindItem.obs %>' /> </li>

                </ul>

                <ul><li>
                <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="Grabar" />
                <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="Cancelar" CausesValidation="false" />
            </li></ul>

            </fieldset>
        </InsertItemTemplate>
    </asp:FormView>


<asp:CompareValidator ControlToValidate="txtTelefono" ID="CompareValidator1" runat="server" Text="* Nro Teléfono" CssClass="error" ErrorMessage="Ingrese un valor numerico" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTelefono" CssClass="error"   runat="server" ErrorMessage="Ingrese el telefono"></asp:RequiredFieldValidator>
<%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" />--%>

  </div>
  <div id ="derecha">
      <uc1:PedidosTop5 runat="server" ID="PedidosTop5" />
      <uc1:PanelCarrito runat="server" ID="PanelCarrito" />
     
  </div>

 
</div>



<div id="dialog-form" style="display:none;" title="Datos del Cliente">

  <p class="validateTips"></p>

  <fieldset>
<legend></legend>
<div id="panelCli">
    <input type="hidden" name="idCliente" id="idCliente" class="text ui-widget-content ui-corner-all" />
    <input type="hidden" name="idDir" value="0" id="idDir" class="text ui-widget-content ui-corner-all" />
    <label for="name">Nombre</label>
    <input type="text" name="name" id="name" maxlength="50" class="text ui-widget-content ui-corner-all" />

    <label for="apellido">Apellido</label>
    <input type="text" name="apellido" id="apellido" value="" maxlength="50"  class="text ui-widget-content ui-corner-all" />

    <label for="empresa">Empresa</label>
    <input type="text" name="empresa" id="empresa" value="" maxlength="50" class="text ui-widget-content ui-corner-all" />

    <label for="ruc">RUC</label>
    <input type="text" name="ruc" id="ruc" value="" maxlength="20" class="text ui-widget-content ui-corner-all" />

    <label for="diplomatico">Diplomatico</label>
    <input type="checkbox" name="diplomatico" style="width:150px;" id="diplomatico" class="checkbox ui-widget-content ui-corner-all" />
    <br />
    <label for="obs">OBS</label>
    <input type="text" name="obs" id="obs" style="width:250px;"   maxlength="50"  value="" class="text ui-widget-content ui-corner-all" />
</div>
<div id="panelDir">

    <label for="direccion">Direccion</label>
    <input type="text" name="direccion" style="width:250px; " maxlength="50"   id="direccion" value="" class="text ui-widget-content ui-corner-all" />

    <label for="nro">Nro</label>
    <input type="number"  name="nro" id="nro" value="" max="10" class="text ui-widget-content ui-corner-all" />

    <label for="direccion1">Direccion 1</label>
    <input type="text" name="direccion1" id="direccion1" maxlength="50"  style="width:250px; "   value="" class="text ui-widget-content ui-corner-all" />

    <label for="referencia">Referencia</label>
    <input type="text" name="referencia" id="referencia" maxlength="50" style="width:250px; "   value="" class="text ui-widget-content ui-corner-all" />


    <label for="cuadrante">Cuadrante</label>
    <input type="text" name="cuadrante" id="cuadrante" maxlength="5"  value="" class="text ui-widget-content ui-corner-all" />

    <label for="sucursal">Sucursal</label>
    <select id="sucursal" name="sucursal" style="width:160px;" class="text ui-widget-content ui-corner-all" ></select>
        
    <button id="btnResolver" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" role="button" aria-disabled="false">
        <span class="ui-button-text">Resolver Direccion</span>
    </button>
    
  

</div>
    <label id="error"></label>
  </fieldset>
</div>

    <input id="idRow" name="idRow" style="display:none;"/>


