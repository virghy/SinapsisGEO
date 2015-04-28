<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelFaltante.ascx.cs" Inherits="SinapsisGEO.Control.PanelFaltante" %>
<div class="barraTitulo">
        <strong>Faltantes </strong>
      </div>

        <div style="display: table;" class="mGrid">
<asp:Repeater ID="rptSucursales" ItemType="DAL.tel_Faltantes" runat="server">
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