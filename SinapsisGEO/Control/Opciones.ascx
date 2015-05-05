<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Opciones.ascx.cs" Inherits="SinapsisGEO.Control.Opciones" %>


<h3>
    <asp:Label ID="lblIdOpcion" CssClass="normal" runat="server" ></asp:Label><asp:Label ID="lblTitulo" runat="server" ></asp:Label>
    <asp:HiddenField ID="txtCantidad" runat="server" /> 
    <asp:HiddenField ID="txtEsCombo" runat="server" />
</h3>
    <div>
    <asp:CheckBox CssClass="" ID="chkMitad" OnCheckedChanged="chkMitad_CheckedChanged" runat="server" Text="Mitad/Mitad?"/>

    </div>

<hr />

<asp:CheckBoxList ID="chkOpciones" ItemType="DAL.tel_Productos"  RepeatColumns="4" DataTextField="DescripcionCorta" DataValueField="IdProducto"   runat="server"></asp:CheckBoxList>
<div>
<asp:Button ID="cmdAddItems" runat="server" Text="=>" OnClick="cmdAddItems_Click" />
</div>
<div id="dvMitad" style="display:grid;">

<asp:GridView ItemType="DAL.Opciones" AutoGenerateColumns="false" id="grdView" runat="server">

    <Columns>
        <asp:BoundField DataField="IdProducto"></asp:BoundField>
        <asp:BoundField DataField="Descripcion"></asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:TextBox runat="server" ID="txtCantidad" Width="40px" Text='<%# Bind("Cantidad") %>' ></asp:TextBox>

            </ItemTemplate>
        </asp:TemplateField> 
    </Columns>
</asp:GridView>

<asp:ListBox ID="lstOpciones" Height="100px" Width="200px"  DataTextField="DescripcionCorta" ItemType="DAL.tel_Productos" DataValueField="IdProducto"  runat="server"></asp:ListBox>
    <asp:ListBox ID="lstOtraMitad"  Visible="<%# chkMitad.Checked %>"  Width="200px" DataTextField="DescripcionCorta" ItemType="DAL.tel_Productos" DataValueField="IdProducto" Height="100px"  runat="server"></asp:ListBox>
</div>
<asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>


