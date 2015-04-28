<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewer1.aspx.cs" Inherits="Reporting.Viewer1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="float:right;" >
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
        </div>
        <div class="H3" >
                            <asp:Label ID="lbltitulo" runat="server" Font-Bold="False" Font-Size="Large"></asp:Label></td>
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" Width="100%">
             <ServerReport ReportServerUrl="http://192.168.101.4/reportserver" />
        </rsweb:ReportViewer  >

    </div>
    </form>
</body>
</html>
