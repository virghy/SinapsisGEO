<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QPedidos.aspx.cs" Inherits="SinapsisGEO.Consultas.QPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<%--    <script src="../Scripts/jqx/jqx-all.js"></script>--%>

    <link href="../Content/jqx/jqx.base.css" rel="stylesheet" />

    <script type="text/javascript">
//        $(document).ready(function () {
//            var theme = "";
//            // Create a jqxDateTimeInput
//         //   $("#dFecha").jqxDateTimeInput({ width: '250px', height: '25px', theme: theme });
////            $("#hFecha").jqxDateTimeInput({ width: '250px', height: '25px', theme: theme });

//            var url = "../geoservice.asmx/GetPedidos";


//            // prepare the data

//            var source =
//            {
//                datatype: "json",
//                data: "{dFecha:'2013/09/01', hFecha:'2013/09/23' ,Operador:'-', IdSucursal:'0'}",
//                datafields: [
//                    { name: 'NombreCliente', type: 'string' },
//                    { name: 'Direccion', type: 'string' },
//                    { name: 'IdSucursal', type: 'int' },
//                    { name: 'Operador', type: 'string' },
//                    { name: 'Estado', type: 'string' }
//                ],
//                id: 'IdPedido',
//                url: url
//            };

//            //var dataAdapter = new $.jqx.dataAdapter(source);



//            //$("#jqxgrid").jqxGrid(
//            //{
//            //    width: 670,
//            //    source: dataAdapter,
//            //    theme: theme,
//            //    columnsresize: true,
//            //    columns: [
//            //      { text: 'NombreCliente', datafield: 'NombreCliente', width: 250 },
//            //      { text: 'Direccion', datafield: 'Direccion', width: 250 },
//            //      { text: 'IdSucursal', datafield: 'IdSucursal', width: 180 },
//            //      { text: 'Operador', datafield: 'Operador', width: 120 },
//            //      { text: 'Estado', datafield: 'Estado', minwidth: 120 }
//            //    ]
//            //});
//        });

        </script>

    <h2>Consulta de Pedidos</h2>

    <fieldset>
        <legend>
            </legend>

    <ul>
        <li>
            <label for="txtdFecha">Desde Fecha:</label>
            <asp:TextBox ID="txtdFecha" TextMode="Date" runat="server"></asp:TextBox>

        </li>
        <li> 
            <label for="txthFecha">Hasta Fecha :</label>
            <asp:TextBox ID="txthFecha" TextMode="Date" runat="server"></asp:TextBox>

        </li>
        <li>
            <label for="cboOperador">Operador: </label>
            <asp:DropDownList ID="cboOperador" DataTextField="FullName" AppendDataBoundItems="true" DataValueField="UserName" runat="server">
                <asp:ListItem Text="(Todos)" Value="-"/>
            </asp:DropDownList>
        </li>
        <li>
            <label for="cboSucursal">Sucursal: </label>
            <asp:DropDownList ID="cboSucursal" DataTextField="Sucursal" DataValueField="IdSucursal" AppendDataBoundItems="true" runat="server">
                <asp:ListItem Text="(Todos)" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </li>
        <li>
            <asp:Button ID="cmdBuscar" runat="server" OnClick="cmdBuscar_Click" Text="Buscar" />
        </li>
    </ul>
        </fieldset>

      <asp:GridView ID="grdPedidos" SelectMethod="grdPedidos_GetData" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPedido"
        ItemType="DAL.tel_Pedidos"  
                  CssClass="mGrid"  
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:BoundField DataField="IdPedido" HeaderText="IdPedido" ReadOnly="True" SortExpression="IdPedido"
                Visible="False" />
            <asp:HyperLinkField DataNavigateUrlFields="IdPedido" DataNavigateUrlFormatString="verpedido.aspx?IdPedido={0}"
                DataTextField="NroPedido" HeaderText="Nro" />
            <asp:BoundField DataField="Audit_Fecha" HeaderText="Fecha" SortExpression="Audit_Fecha" DataFormatString="{0:dd-MMM HH:mm}" HtmlEncode="False" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
            <asp:TemplateField HeaderText="Cliente" SortExpression="IdCliente">
                <ItemTemplate>
                    <%# Eval("IdCliente") %>-<%# Eval("Nombre") + " " + Eval("Apellido") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
            <asp:BoundField DataField="IdSucursal" HeaderText="IdSucursal" SortExpression="IdSucursal" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
            <asp:BoundField DataField="cuadrante" HeaderText="cuadrante" SortExpression="Cuadrante" />
            <asp:BoundField DataField="TotalGeneral" DataFormatString="{0:N0}" HeaderText="Total General"
                HtmlEncode="False" SortExpression="TotalGeneral" />
            <asp:BoundField DataField="UserName" HeaderText="Usuario" SortExpression="UserName" />
        </Columns>
    </asp:GridView>

</asp:Content>
