<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Opciones.ascx.cs" Inherits="SinapsisGEO.Control.Opciones" %>


<h3>
    <asp:Label ID="lblIdOpcion" CssClass="normal" runat="server" ></asp:Label><asp:Label ID="lblTitulo" runat="server" ></asp:Label>
    <asp:HiddenField ID="txtCantidad" runat="server" /> 
    <asp:HiddenField ID="txtEsCombo" runat="server" />
</h3>
    <div>
    <asp:CheckBox ID="chkMitad" OnCheckedChanged="chkMitad_CheckedChanged" runat="server" Text="Mitad/Mitad?"/>
    </div>

<hr />

<asp:CheckBoxList ID="chkOpciones" ItemType="DAL.tel_Productos"  RepeatColumns="4" DataTextField="DescripcionCorta" DataValueField="IdProducto"   runat="server"></asp:CheckBoxList>
<div>
<asp:Button ID="cmdAddItems" runat="server" Text="=>" OnClick="cmdAddItems_Click" />
</div>
<div style="display:grid;">
<asp:ListBox ID="lstOpciones" Height="100px" Width="200px"  DataTextField="DescripcionCorta" ItemType="DAL.tel_Productos" DataValueField="IdProducto"  runat="server"></asp:ListBox>
    <asp:ListBox ID="lstOtraMitad"  Visible="<%# chkMitad.Checked %>"  Width="200px" DataTextField="DescripcionCorta" ItemType="DAL.tel_Productos" DataValueField="IdProducto" Height="100px"  runat="server"></asp:ListBox>
</div>
<asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>



