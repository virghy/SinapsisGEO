<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="Reporting.Mapa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/jquery-ui-1.10.3.min.js"></script>
    <script src="Scripts/GEO.js"></script>

    <script>
        function load() {
            var map;
            var geoXml;

        }


        $(function () {
            // run the currently selected effect
            function runEffect() {
                // get effect type from
                var selectedEffect = "slide";

                // most effect types need no options passed by default
                var options = {};
                // some effects have required parameters
                if (selectedEffect === "scale") {
                    options = { percent: 0 };
                } else if (selectedEffect === "size") {
                    options = { to: { width: 200, height: 60 } };
                }

                // run the effect
                $("#effect").toggle(selectedEffect, options, 500);
            };

            // set effect from select menu value
            $("#button").click(function () {
                runEffect();
                return false;
            });

            $("#toggler").click(function () {
                runEffect();
                return false;
            });
        });

        google.maps.event.addDomListener(window, 'load', initialize);
      //  google.maps.event.addDomListener(window, 'loaded', getCars);

        function getCars() {
            clearOverlays();

            $.ajax({

                type: "POST",

                url: "GEOService.asmx/ListaConsumo",

                data: "{Sucursal: " + $('#<%= cboSucursal.ClientID %>').val() +
                        ",dFecha: '" + $('#<%= txtdFecha.ClientID %>').val() +
                        "',hFecha: '" + $('#<%= txthFecha.ClientID %>').val() +
                        "',IdReporte:" + $('#<%= IdReporte.ClientID %>').val()
                    + " }",

                contentType: "application/json; charset=utf-8",

                dataType: "json",

                success: function (response) {

                    var cars = response.d;

                    $('#output').empty();

                    $.each(cars, function (index, car) {

                        SetMarker(car.Data1, car.Lat, car.Lng);

                    });

                    getLimites($('#<%= cboSucursal.ClientID %>').val());

                },

                failure: function (msg) {

                    $('#output').text(msg);

                }

            });

        }

        function getLimites(IdSucursal) {


            $.ajax({

                type: "POST",

                url: "GEOService.asmx/GetLimiteSucursal",

                data: "{IdSucursal: " + IdSucursal + " }",

                contentType: "application/json; charset=utf-8",

                dataType: "json",

                success: function (response) {

                    var cars = response.d;

                    setLimites(cars);

                },

                failure: function (msg) {

                    $('#output').text(msg);

                }

            });

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="lblTitulo" runat="server" ></asp:Label>
        <%# Request.QueryString["titulo"] %>
        <asp:HiddenField ID="IdReporte" runat="server" />
    </h2>
   
    <div id="toggler" class="toggler">
  <div id="effect"  style="display: none;" class="ui-widget-content ui-corner-all">
    <h3 class="ui-widget-header ui-corner-all">Tabla de Datos</h3>
    <p>
      Etiam libero neque, luctus a, eleifend nec, semper at, lorem. Sed pede. Nulla lorem metus, adipiscing ut, luctus sed, hendrerit vitae, mi.
    </p>
  </div>
</div>
    <a href="#" id="button" class="ui-state-default ui-corner-all">Tabla de Datos</a>
    <div>
        <p>
            <%--Formato:
            <asp:DropDownList ID="cboReporte" SelectMethod="GetReportes" DataTextField="Nombre" DataValueField="IdReporte" ItemType="DAL.sys_ReportesGEO" runat="server">
            </asp:DropDownList>--%>
        Sucursal: 
        
        <asp:DropDownList ID="cboSucursal" SelectMethod="GetSucursal" ItemType="DAL.tel_Sucursal" DataTextField="Sucursal" DataValueField="IdSucursal"  runat="server">
        </asp:DropDownList>
        Desde Fecha: <asp:TextBox ID="txtdFecha" runat="server"></asp:TextBox>
            Hasta Fecha: <asp:TextBox ID="txthFecha" runat="server"></asp:TextBox>
            <asp:Button ID="btnCargar" runat="server" Text="Cargar" OnClientClick="getCars(); return(false);" OnClick="btnCargar_Click" />
        </p>
    </div>
    <div id="map-canvas" style="width:100%; height:600px;" ></div>
    <div id="output"></div>
</asp:Content>
