<%@ Page Title="" Language="C#" MasterPageFile="~/Remote.Master" AutoEventWireup="true" CodeBehind="TiempoServicio.aspx.cs" Inherits="SinapsisGEO.Remote.TiempoServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div>
  <h3>
    <p>
        Sucursal:<asp:Label ID="lblSucursal" runat="server"></asp:Label>
    </p>
    <p>
        Tiempo de Servicio:
        <asp:DropDownList ID="cboTiempo" runat="server">
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>35</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>45</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>55</asp:ListItem>
            <asp:ListItem>60</asp:ListItem>
            <asp:ListItem>70</asp:ListItem>
            <asp:ListItem>80</asp:ListItem>
            <asp:ListItem>90</asp:ListItem>
            <asp:ListItem>100</asp:ListItem>
            <asp:ListItem>110</asp:ListItem>
            <asp:ListItem>120</asp:ListItem>
            <asp:ListItem>150</asp:ListItem>


        </asp:DropDownList>


    </p>
    <p>
        <asp:Button ID="cmdActualizar" OnClick="cmdActualizar_Click" runat="server" Text="Actualizar" />
        <asp:Button ID="cmdCancel" runat="server" Text="Cancelar" OnClick="cmdCancel_Click" />
    </p>
</h3>   
</div>
</asp:Content>
