<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarDir.aspx.cs" Inherits="SinapsisGEO.AsignarDir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script src="Scripts/GEO.js"></script>
    <script>

        var geocoder;
        
        var marker1;

        

        google.maps.event.addDomListener(window, 'load', initializeWithClick);

        //google.maps.event.addListener(map, 'click', seleccionar);
        

        function seleccionar(event)
        {

            document.getElementById('MainContent_txtLat').value = event.latLng.lat();
            document.getElementById('MainContent_txtLng').value = event.latLng.lng();


        }

    
        

        
        function codeAddress() {
            var address = document.getElementById('MainContent_txtDireccion').value + ',' + document.getElementById('MainContent_cboCiudad').value;
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);

                    //if (marker1 =! null)
                    //{
                    //    marker1.remove();
                    //}

                    clearOverlays();

                    marker1 = new google.maps.Marker({
                        map: map,
                        position: results[0].geometry.location,
                        draggable: true
                    });

                    markers.push(marker1);

                    google.maps.event.addListener(marker1, 'dragend', function () {
                        //map.setZoom(8);
                        //map.setCenter(marker.getPosition());
                        document.getElementById('MainContent_txtLat').value = marker1.getPosition().lat();
                        document.getElementById('MainContent_txtLng').value = marker1.getPosition().lng();

                    });

                } else {
                    alert('Error en recuperar las coordenadas: ' + status);
                }
            });
        }

    </script>
    <style type="text/css">
        .auto-style2
        {
            width: 132px;
        }
        .auto-style4 {
            width: 600px;
        }
        .auto-style5 {
            height: 47px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <table style="width:100%;">
        <tr>
            <td class="auto-style4" colspan="2">
                <div>
                 Sucursal:
                <asp:DropDownList ID="dboSucursal" runat="server" AppendDataBoundItems="true" DataTextField="Sucursal" DataValueField="IdSucursal">
                    <asp:ListItem Text="(Todos)" Value="0" Selected="True"></asp:ListItem>
                </asp:DropDownList>

<%--                </div>

                <div>--%>
                    Periodo de Ventas:
                <asp:TextBox ID="txtdFecha" runat="server" Width="100px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Fecha no válida" ControlToValidate="txtdFecha" Operator="DataTypeCheck" Type="Date" ValidationGroup="BuscarCliente"></asp:CompareValidator>
                &nbsp;
                <asp:TextBox ID="txthFecha" runat="server" Width="100px"></asp:TextBox>
                   
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Fecha no válida" ControlToValidate="txthFecha" Operator="DataTypeCheck" Type="Date" ValidationGroup="BuscarCliente"></asp:CompareValidator>
                    Operador: 
                    <asp:DropDownList ID="cboOperador" runat="server" AppendDataBoundItems="true" DataTextField="UserName" DataValueField="UserName">
                        <asp:ListItem Text="(Todos)" Value="--" Selected="True"></asp:ListItem>
                </asp:DropDownList>

                    </div>
            </td>
            <td class="auto-style2">
                <asp:DropDownList ID="cboCiudad" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem>Asuncion,PY</asp:ListItem>
                    <asp:ListItem>Fdo de la Mora,PY</asp:ListItem>
                    <asp:ListItem>Lambare,PY</asp:ListItem>
                    <asp:ListItem>San Lorenzo,PY</asp:ListItem>
                    <asp:ListItem>Mariano Roque Alonso,PY</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td >
                
                &nbsp;</td>
            <td >
                
            </td>

        </tr>
        <tr>
            <td class="auto-style4"><asp:FormView ID="fvCliente" runat="server" DataKeyNames="Id" DefaultMode="ReadOnly" ItemType="DAL.Tel_Direcciones">
                <ItemTemplate>
                    <fieldset>
                        <ul>
                            <li>
                            <b>
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="customerFirstName">Nombre:</asp:Label>
                                </b>
                            <asp:Label ID="customerFirstName" runat="server" Text="<%#  Item.tel_Clientes.Nombres %>" />

                            </li>
                            <li>
                            <b>
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="Direccion">Direccion:</asp:Label>
                                </b>
                            <asp:Label ID="Direccion" runat="server" Text="<%#: Item.Direccion%>" />
                            <asp:Label ID="Label3" runat="server" Text="<%#: Item.NroCasa%>" />
                            <asp:Label ID="Label4" runat="server" Text="<%#: Item.Direccion1%>" />
                            <asp:Label ID="Label5" runat="server" Text="<%#: Item.referencia%>" />

                            </li>

                        </ul>

                        
                    </fieldset>
                </ItemTemplate>
                </asp:FormView>
            </td>
            <td >
              
                <table style="width:100%;">
                    <tr>
                        <td>Latitud:</td>
                        <td>
                            <asp:TextBox ID="txtLat" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLat" CssClass="error" ErrorMessage="*" ValidationGroup="Asignar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Longitud:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtLng" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td class="auto-style5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLng" CssClass="error" ErrorMessage="*" ValidationGroup="Asignar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
              
            </td>
            <td>
                &nbsp;Nombre de Calle:<asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                <asp:EntityDataSource ID="edsSucursal" runat="server" ConnectionString="name=SinapsisEntities" DefaultContainerName="SinapsisEntities" EnableFlattening="False" EntitySetName="tel_Sucursal" Select="it.[Sucursal], it.[IdSucursal]" EntityTypeFilter="tel_Sucursal" Where="it.IdEmpresa=@IdEmpresa">
                    <WhereParameters>
                        <asp:Parameter DefaultValue="1" Name="IdEmpresa" />
                    </WhereParameters>
                </asp:EntityDataSource>
            </td>
        </tr>
        <tr>
            <td ><strong>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Recuperar Cliente" ValidationGroup="BuscarCliente" />
                </strong></td>
            <td>
                <asp:Button ID="btnAsignar" runat="server" OnClick="btnAsignar_Click" Text="Asignar Lat/Lng al cliente actual" ValidationGroup="Asignar" />
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClientClick="codeAddress(); return false;" Text="Buscar en el Mapa" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td >&nbsp;</td>
            <td >
                <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
            <td ></td>
            <td></td>
        </tr>
    </table>
            </ContentTemplate>
                </asp:UpdatePanel>
    <div id="map-canvas" style="width:100%; height:600px;" ></div>
</asp:Content>
