<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelAviso.ascx.cs" Inherits="SinapsisGEO.Control.PanelAviso" %>

  


            <asp:Repeater ID="rptSucursales" ItemType="DAL.tel_Sucursal" runat="server">
                <ItemTemplate>
                <div class="barraTitulo">
                        <strong><%# Item.IdSucursal %> - <%# Item.Sucursal %> </strong>
                      </div>
                      Tiempo de Servicio: <strong> <%# Item.TiempoServicio %> </strong>
                </ItemTemplate>
            </asp:Repeater>


<div class="barraTitulo">
        <strong>Faltantes </strong>
      </div>

        <div style="display: table;" class="mGrid">
<asp:Repeater ID="rptFaltantes" ItemType="DAL.tel_Faltantes" runat="server">
    <ItemTemplate>

            <div style="display: table-row;" class="tr" >
                <div style="display: table-cell;" class="td"><%# Item.tel_Insumos.Descripcion %> </div>
            </div>

    </ItemTemplate>
    <AlternatingItemTemplate>
            <div style="display: table-row;" class="alt" >
                <div style="display: table-cell;" class="td"><%# Item.tel_Insumos.Descripcion %> </div>
            </div>

    </AlternatingItemTemplate>

</asp:Repeater>
        </div>  