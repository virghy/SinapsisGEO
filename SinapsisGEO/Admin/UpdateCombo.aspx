<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateCombo.aspx.cs" Inherits="SinapsisGEO.Admin.UpdateCombo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <div class="form-inline" >
    <div class="row">
   
  <div class="form-group">
    <label class="sr-only" for="txtProducto">Amount (in dollars)</label>
    <div class="input-group">
      <div class="input-group-addon">Producto:</div>
      <input type="text" runat="server" class="form-control" id="txtProducto" placeholder="Codigo Producto"/>
    
    </div>
  </div>
 
    <asp:Button ID="cmdBuscar" runat="server" OnClick="cmdBuscar_Click" class="btn btn-primary" Text="Buscar" />

    </div>

    </div>
    <div class="row">
        <asp:GridView ID="GridView1" CssClass="table table-condensed" runat="server">

        </asp:GridView>
         <asp:Button ID="cmdUpdate" runat="server" OnClick="cmdUpdate_Click" class="btn btn-primary" Text="Actualizar" />
    </div>
    <div class="row">
        <h3>
                <asp:Label ID="lblError" CssClass="label label-danger" runat="server"></asp:Label>
        </h3>
    </div>

</asp:Content>
