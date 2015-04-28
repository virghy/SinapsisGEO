<%@ Page Title="" Language="C#" MasterPageFile="~/Remote.Master" AutoEventWireup="true" CodeBehind="Faltantes.aspx.cs" Inherits="SinapsisGEO.Remote.Faltantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

     

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<script>
    $(function () {
        $("#tabs").tabs();
    });
</script>
    <h3>Insumos Faltantes</h3>

    <div id="tabs">
<ul>
<li><a href="#tabs-1">Faltantes</a></li>
<li><a href="#tabs-2">Agregar Insumos</a></li>

</ul>
<div id="tabs-1">
    <p>Seleccione los productos e insumos faltantes</p>
    <asp:DataList ID="DataList1" runat="server" DataKeyField="IdFaltante" >
        <ItemTemplate>
           
            <asp:CheckBox ID="chkFalta" runat="server" Checked='<%# Bind("Falta") %>' />
            <%# Eval("tel_Insumos.Descripcion") %>
            <asp:HiddenField ID="IdFaltante" Value='<%# Eval("IdFaltante") %>' runat="server" />
        </ItemTemplate>
    </asp:DataList>
    <asp:Button ID="cmdActualizar" OnClick="cmdActualizar_Click" runat="server" Text="Actualizar" />

</div>
<div id="tabs-2">
    <div>
    Nombre:  <asp:TextBox ID="txtInsumo" MaxLength="200" Width="300px" runat="server"></asp:TextBox>   
        <asp:RequiredFieldValidator ControlToValidate="txtInsumo" ValidationGroup="Agregar" ID="RequiredFieldValidator1" runat="server" CssClass="alert" ErrorMessage="Requerido"></asp:RequiredFieldValidator>
    </div>
    <asp:Button ID="cmdAgregar" runat="server" OnClick="cmdAgregar_Click" Text="Agregar" ValidationGroup="Agregar"  />
   
</div>
 <div class="ui-state-error ui-corner-all" >
        <asp:Label ID="lblError" runat="server" ></asp:Label>
    </div>

    <asp:HyperLink ID="HyperLink1"  runat="server">Volver</asp:HyperLink>
</div>



</asp:Content>
