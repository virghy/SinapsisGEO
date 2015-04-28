<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Reporting._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
   
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="header">
<h4>
Empresa: <asp:DropDownList ID="cboEmpresa" runat="server" OnSelectedIndexChanged="cboEmpresa_SelectedIndexChanged" 
        DataTextField="Empresa" DataValueField="IdEmpresa" Width="200px" 
        AutoPostBack="True">

    </asp:DropDownList>
</h4>
        
</div>

        <asp:DataList ID="DataList1" runat="server" DataKeyField="IdReporte"     
          RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="4" ForeColor="#333333">
          <ItemTemplate>
          <strong>
              <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# (Eval("Tipo").ToString()=="R" ? "Viewer1.aspx?value=" : "Mapa.aspx?value=") + Eval("Archivo") + "&titulo=" + Eval("Nombre") +"&Id=" + Eval("IdReporte") %>'
                  Text='<%# Eval("Nombre") %>'></asp:HyperLink>&nbsp;
                    
              </strong>

              
            <%--  <asp:Label ID="Label1" Font-Bold="true" ForeColor="green" runat="server" Text='<%# Eval("Nuevo") %>'></asp:Label>--%>
              <br />
             <asp:Image ID="Image1" ImageUrl='<%# Eval("Tipo").ToString()=="R" ? "Images/reporte.png" : "Images/tierra.png"%>' runat="server" />
              <asp:Label ID="DescripcionLabel" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label><br />
              Id <%# Eval("IdReporte") %>
          </ItemTemplate>
                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Width="300px" />
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
      </asp:DataList>    
 
</asp:Content>
