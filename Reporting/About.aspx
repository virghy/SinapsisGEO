<%@ Page Title="Acerca de" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Reporting.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Administrador de Reportes.</h2>
    </hgroup>

    <article>
        <p>        
            Desarrollado por Futura Software.
        </p>

        <p>        
            www.futura.com.py
        </p>

        <p>        

        </p>
    </article>

    <aside>
        <h3>Asistencia Tecnica</h3>
        <p>        
            Para solicitar asistencia tecnica...
        </p>
        <ul>
            <li><a runat="server" href="~/">Inicio</a></li>
            <li><a runat="server" href="~/About.aspx">Acerca de</a></li>
        </ul>
    </aside>
</asp:Content>