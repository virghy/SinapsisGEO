<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="SinapsisGEO.Admin.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="form-group">
    <label for="inputEmail3" class="col-sm-2 control-label">Id</label>
    <div class="col-sm-10">
          <asp:TextBox class="form-control" id="inputEmail3" placeholder="Id" runat="server"></asp:TextBox>
    </div>
  </div>
  <div class="form-group">
    <label for="inputPassword3" class="col-sm-2 control-label">Descripcion</label>
    <div class="col-sm-10">
           <asp:TextBox class="form-control" id="inputPassword3" placeholder="Descripcion" runat="server"></asp:TextBox>
    </div>
  </div>
 
  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
      
         <asp:Button class="btn btn-default" ID="cmdEjecutar" runat="server" Text="Sin Trans" OnClick="cmdEjecutar_Click" />
        <asp:Button class="btn btn-default" ID="cmdWithTrans" runat="server" Text="Con Trans" OnClick="cmdWithTrans_Click" />
    </div>
  </div>
       

    </div>
</asp:Content>
