﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWS.aspx.cs" Inherits="SinapsisWS.TestWS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Test" OnClick="Button1_Click" />
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
