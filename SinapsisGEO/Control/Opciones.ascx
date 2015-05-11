<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Opciones.ascx.cs" Inherits="SinapsisGEO.Control.Opciones" %>
<header>
    <script type="text/javascript">
       
        $(document).ready(function () {
            alert("Prueba");
             $("#<%=grdView.ClientID%> tr:has(td)").each(function () {
                alert($(this).html());
            });
        });


    </script>

</header>

<div class="panel panel-info">
  <div class="panel-heading">
    <h2 class="panel-title">
 
        <asp:Label ID="lblCantidad" CssClass="badge" runat="server" />
       
        <asp:Label ID="lblIdOpcion" CssClass="normal" runat="server" />
         -
        <asp:Label ID="lblTitulo" runat="server" ></asp:Label></h2>
      </div>
  </div>
<%--  <div class="panel-body">
  </div>--%>
    <asp:GridView ItemType="DAL.Opciones" AutoGenerateColumns="false" id="grdView" runat="server"
                CssClass="table table-striped table-condensed " ShowHeader="false"
         OnRowDataBound="grdView_RowDataBound"  >

    <Columns>
        <asp:BoundField DataField="IdProducto"></asp:BoundField>
        <asp:BoundField DataField="Descripcion"></asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:DropDownList i CssClass="dropdown-toggle" runat="server" ID="cboCantidad"></asp:DropDownList>
              <%--  <asp:TextBox runat="server" ID="txtCantidad" Width="40px" Text='<%# Bind("Cantidad") %>' ></asp:TextBox>--%>
     <%--     <asp:Label runat="server" class="badge" ID="lblCantidad" Text='<%# Eval("Cantidad") %>'></asp:Label>
    
                <div class="btn-group">
                  <button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                    <%# Eval("Cantidad") %> <span class="caret"></span>
                  </button>
                  <ul class="dropdown-menu" role="menu">
                    <li><a href='javascript:SelCelda(<%# Eval("IdProducto") %>);'>1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">0</a></li>
                    <li class="divider"></li>
                    <li><a href="#">Mitad</a></li>
                    

                  </ul>
                </div>--%>
            </ItemTemplate>
        </asp:TemplateField> 
    </Columns>
</asp:GridView>
     <asp:Label id="lblSelected" runat="server"></asp:Label>
</div>

<h3>
    
    <asp:HiddenField ID="txtCantidad" runat="server" /> 
    <asp:HiddenField ID="txtEsCombo" runat="server" />
</h3>
    <div>
    <asp:CheckBox Visible="false" CssClass="" ID="chkMitad" OnCheckedChanged="chkMitad_CheckedChanged" runat="server" Text="Mitad/Mitad?"/>

    </div>



<asp:CheckBoxList  ID="chkOpciones" ItemType="DAL.tel_Productos"  RepeatColumns="4" DataTextField="DescripcionCorta" DataValueField="IdProducto"   runat="server"></asp:CheckBoxList>
<div>
<asp:Button ID="cmdAddItems" runat="server" Text="=>" OnClick="cmdAddItems_Click" />
</div>
<div id="dvMitad" style="display:grid;">



<asp:ListBox Visible="false" ID="lstOpciones" Height="100px" Width="200px"  DataTextField="DescripcionCorta" ItemType="DAL.tel_Productos" DataValueField="IdProducto"  runat="server"></asp:ListBox>
    <asp:ListBox ID="lstOtraMitad"  Visible="<%# chkMitad.Checked %>"  Width="200px" DataTextField="DescripcionCorta" ItemType="DAL.tel_Productos" DataValueField="IdProducto" Height="100px"  runat="server"></asp:ListBox>
</div>
<asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
