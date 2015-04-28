<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelPedidos.aspx.cs" Inherits="SinapsisGEO.Consultas.PanelPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div id="contenedor">
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div id="barraTitulo">
        <h3 style="color:white;">
        Tiempos de Cola de Espera
            </h3>
    </div>
   <%-- <div style="display:table;">

        </div>
    <asp:Repeater SelectMethod="rpt_GetData" ID="rptCola" ItemType="SinapsisGEO.Sucursal" runat="server">
        <ItemTemplate>
            <%# Item.IdSucursal %>
            <%# Item.Nombre %>
            <%# Item.TiempoCola %>
            <%# Item.CantidadMoviles %>
        </ItemTemplate>
    </asp:Repeater>--%>
<asp:GridView ID="grvCola" SelectMethod="rpt_GetData" ItemType="SinapsisGEO.Sucursal" runat="server" AutoGenerateColumns="False" 
                GridLines="None"  
                CssClass="mGrid"  
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"> 
    <Columns>
         <asp:BoundField DataField="IdSucursal" HeaderText="IdSucursal" SortExpression="IdSucursal" />
         <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
         <asp:BoundField DataField="TiempoCola"  ItemStyle-Font-Bold="true"   HeaderText="Tiempo Cola de Espera" SortExpression="TiempoCola" />
         <asp:BoundField DataField="CantidadMoviles" HeaderText="Moviles" SortExpression="CantidadMoviles" />
         <asp:BoundField DataField="Pedidos" HeaderText="Pedidos" SortExpression="Pedidos" />
         <asp:BoundField DataField="TPC" HeaderText="TPC" SortExpression="TPC" />
         <asp:BoundField DataField="TPP" HeaderText="TPP" SortExpression="TPP" />
         <asp:BoundField DataField="TPV" HeaderText="TPV" SortExpression="TPV" />
         <asp:BoundField DataField="TPT" HeaderText="TPT" SortExpression="TPT" />
         <asp:BoundField DataField="HitRate" DataFormatString="{0:P0}" HeaderText="Hit Rate" SortExpression="HitRate" />

    </Columns>

    </asp:GridView>

     <div class="barraTitulo">
        <h3 style="color:white;">
        Pedidos por Sucursal
            </h3>
    </div>
 
            <asp:Timer ID="Timer1" runat="server" Interval="60000" OnTick="Timer1_Tick" ></asp:Timer>
              <asp:DataList ID="dltSucursal" runat="server" OnItemDataBound="dltSucursal_ItemDataBound" DataKeyField="IdSucursal"  RepeatColumns="2">
            <ItemTemplate>
               <div style="width:100%"  class="Titulos"> : : <%# Eval("Sucursal") %> </div> 
                <asp:GridView ID="grvPedidos" runat="server" AutoGenerateColumns="False" 
                GridLines="None"  
                CssClass="mGrid"  
                PagerStyle-CssClass="pgr"  
                AlternatingRowStyle-CssClass="alt"> 
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="IdPedido" DataNavigateUrlFormatString="Verpedido.aspx?IdPedido={0}"
                            DataTextField="NroPedido" HeaderText="Nro." />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                        <asp:BoundField DataField="Audit_Fecha" HeaderText="Hora" SortExpression="Audit_Fecha" DataFormatString="{0:dd-MMM HH:mm}" HtmlEncode="False" />
                        <asp:BoundField DataField="tCola" HeaderText="T. Cola" ReadOnly="True" SortExpression="tCola" />
<%--                        <asp:BoundField DataField="tPreparacion" HeaderText="T. Prod." ReadOnly="True"
                            SortExpression="tPreparacion" />--%>
                        <asp:TemplateField HeaderText="T. Prod." >
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("tPreparacion")  %>'  CssClass='<%# Convert.ToInt32(Eval("tPreparacion"))>5 ? "error" : "" %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="T. Envio" >
                            <ItemTemplate>
                                <asp:Label ID="Label1" Text='<%# Eval("tEnvio")  %>'  CssClass='<%# Convert.ToInt32(Eval("tEnvio"))>30 ? "error" : "" %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
<%--                        <asp:BoundField DataField="tEnvio" HeaderText="T. Envio" ReadOnly="True" SortExpression="tEnvio" />--%>
                        <asp:BoundField DataField="tTotal" HeaderText="T. Total" ReadOnly="True" SortExpression="tTotal" />
                        <asp:BoundField DataField="Anulado" HeaderText="Anul" ReadOnly="True" SortExpression="Anulado" />
                    </Columns>
                </asp:GridView>
            </ItemTemplate>
            <ItemStyle VerticalAlign="Top" />
        </asp:DataList>
            <p>
                Ultima actualización: <asp:Label runat="server" ID="lblHora" />
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
<div>
    <strong>Indicadores de Estados</strong>
    P: Pendiente | 
    E: En Produccion | 
    V: Viajando | 
    F: Finalizado | 
    N: No transmitido a Jedi | 
    L: Leido en el local
</div>
</div>
</asp:Content>
