<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PruebaCliente.aspx.cs" Inherits="SinapsisGEO.Test.PruebaCliente" %>

<%@ Register Src="~/Control/ClienteEdit.ascx" TagPrefix="uc1" TagName="ClienteEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%--<script src="../Scripts/jquery-ui-1.10.3.min.js"></script>--%>
<%--<script src="../Scripts/jquery-ui-timepicker-addon.js"></script>--%>
    <script src="../Scripts/jquery.number.js"></script>
    <script>
        $(function () {
            $('#rest_example_21').timepicker({
                hourMin: 8,
                hourMax: 16
            });

            $('#time1').datepicker({ 'scrollDefaultNow': true });
            $('#importe').number(true, 0, ',', '.');
            $('#MainContent_TextBox1').number(true, 0, ',', '.');

            $(function () {
                //function log(message) {
                //    $("<div>").text(message).prependTo("#log");
                //    $("#log").scrollTop(0);
                //}

                //$("#birds").autocomplete({
                //    source: "http://localhost:53969/GEOServices.asmx/GetCalles",
                //    minLength: 2,
                //    select: function (event, ui) {
                //        log(ui.item ?
                //          "Selected: " + ui.item.value + " aka " + ui.item.id :
                //          "Nothing selected, input was " + this.value);
                //    }
                //});
                $("#city").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: '<%=ResolveUrl("~/GEOService.asmx/GetCalles") %>',
                            async: false,
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: "{ 'Nombre': '" + request.term + "'}",
                        });
                    },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.split('-')[0],
                                val: item.split('-')[1]
                            }
                        }))
                    },
                    minLength: 2
                });
            });
        });

        $(document).ready(function () {
            $("#<%=txtSearch.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/GEOService.asmx/GetCalles") %>',
                    data: "{ 'Nombre': '" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.split('-')[0],
                                val: item.split('-')[1]
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $("#<%=hfCustomerId.ClientID %>").val(i.item.val);
            },
            minLength: 3
        });
        });

    </script>
    <div  id="rest_example_1" >
    <input name="rest_example_21" type="time" id="rest_example_21" />
    <input name="time1" type="time" id="time1" />
    <input name="importe" id="importe" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
    <div class="ui-widget">
    <label for="city">Birds: </label>
    <input id="city">
    </div>
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
    <asp:HiddenField ID="hfCustomerId" runat="server" />

</asp:Content>
