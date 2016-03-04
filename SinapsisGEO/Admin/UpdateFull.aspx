<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AsyncTimeout="5000" Async="true" AutoEventWireup="true" CodeBehind="UpdateFull.aspx.cs" Inherits="SinapsisGEO.Admin.UpdateFull" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <div class="form-inline" >
    <div class="row">
  
    <asp:Button ID="cmdBuscar" runat="server" OnClick="cmdBuscar_Click" class="btn btn-primary" Text="Cargar" />

     <asp:RadioButtonList CssClass="radio-inline"  runat="server" ID="rdOpcion">
         <asp:ListItem Text="Productos"  Value="P" Selected="True"></asp:ListItem>
         <asp:ListItem Text="Insumos" Value="I"></asp:ListItem>
     </asp:RadioButtonList>

    </div>

    </div>
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">Producto Remoto</div>
            <div class="panel-body">
        
              <asp:GridView ID="GridView1" CssClass="table table-condensed" runat="server">

              </asp:GridView>
         </div>
  <%--      </div>

                <div class="panel panel-primary">--%>
                     <div class="panel-heading">Producto Local</div>
            <div class="panel-body">
        <asp:GridView ID="GridView2" CssClass="table table-condensed" runat="server">

        </asp:GridView>
                       </div>
        </div>
         <asp:Button ID="cmdUpdate" runat="server" OnClick="cmdUpdate_Click" class="btn btn-primary" Text="Actualizar" />
        
    </div>
    <div class="row">
        <h3>
                <asp:Label ID="lblError" CssClass="label label-danger" runat="server"></asp:Label>
            <span id="TaskMessage" runat="server"/>
      
        </h3>
    </div>

</asp:Content>
