<%@ Page Title="Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="SinapsisGEO.Pedido" %>
<%@ Register src="Control/PanelCarrito.ascx" tagname="PanelCarrito" tagprefix="uc1" %>
<%@ Register Src="Control/PanelProducto.ascx" TagPrefix="uc2" TagName="PanelProducto" %>
<%@ Register Src="~/Control/PanelAddProducto.ascx" TagPrefix="uc1" TagName="PanelAddProducto" %>
<%@ Register Src="~/Control/PanelPedido.ascx" TagPrefix="uc1" TagName="PanelPedido" %>
<%@ Register Src="~/Control/PanelAviso.ascx" TagPrefix="uc1" TagName="PanelAviso" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
 

  </style>
 

  <%--  <style>
        h1 {
     border: 1px solid #fff;
}
#navegacion li {
     float:left;
     width:30%;
     padding:5px;
     border: 1px solid #fff;
     display:inline;
}

        #principal {
            display:block;
            border:1px solid #fff;
        }

        #panelCarrito {
            display:inline;
            float:right;
            width:150px;
            border:1px solid #fff;
        }
        #panelProductos {
            display:inline;
            float:left;
            border:1px solid #fff;
        }


#corp {
     border:1px solid #fff;
     display:block;
}

    </style>--%>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   

<script type="text/javascript">
    // JavaScript funciton to call inside UpdatePanel
    function jScript() {

        $(function () {

            // Set up the number formatting.
     
            $('#txtProgramarEnvio').timepicker({
                hourMin: 8,
                hourMax: 23
            });

            $('#txtVuelto').number(true, 0,',','.');
 
        });

       
        function SelCelda(idProducto) {
            alert(idProducto);
        };

    }
</script>

          

    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel1" ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <h3>Actualizando...
            <img src="Images/cargando.gif" /></h3>
        </ProgressTemplate>
    </asp:UpdateProgress>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       
        <ContentTemplate>
<script type="text/javascript">
    Sys.Application.add_load(jScript);
            </script>
            <div id="barraMenu">
            <asp:Button Text="Productos" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server"
              OnClick="Tab1_Click" />
          <asp:Button Text="Detalle" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
              OnClick="Tab2_Click" />
          <asp:Button Text="Cliente" BorderStyle="None" ID="Tab3" CssClass="Initial" runat="server"
              OnClick="Tab3_Click" />
            </div>

              <asp:MultiView ID="MainView" runat="server">
                <asp:View ID="View1" runat="server">
                          <uc2:PanelProducto runat="server" id="PanelProducto" />
                </asp:View>
                <asp:View ID="View2" runat="server">
                        <uc1:PanelAddProducto runat="server" ID="PanelAddProducto" />
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <uc1:PanelPedido runat="server" ID="PanelPedido" />
                </asp:View>
              </asp:MultiView>

        </ContentTemplate>
    </asp:UpdatePanel>
           
 



</asp:Content>
