<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCombo.ascx.cs" Inherits="SinapsisGEO.Control.PanelCombo" %>
<ul>
<asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound" SelectMethod="GetCombos" runat="server" ItemType="DAL.tel_Combos">
    <ItemTemplate>
        <li>
        <%#: Item.Descripcion %>
        <%#: Item.Cantidad.Value.ToString("N2") %>
            <br />
        <asp:ListBox ID="lstComboDet" SelectionMode='<%# (Item.Cantidad>1 ? ListSelectionMode.Multiple  : ListSelectionMode.Single) %>' ItemType="DAL.tel_CombosDet" Width="300px" DataTextField="Descripcion" DataValueField="IdProducto" runat="server"></asp:ListBox>
        </li>
       
    </ItemTemplate>
    <FooterTemplate>

    </FooterTemplate>
</asp:Repeater>
</ul>
