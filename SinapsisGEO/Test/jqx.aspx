<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="jqx.aspx.cs" Inherits="SinapsisGEO.Test.jqx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <div id='content'>
     <link href="../Content/jqx/jqx.base.css" rel="stylesheet" />
<%--    <script type="text/javascript" src="../../jqwidgets/jqxbuttons.js"></script>

    <script type="text/javascript" src="../../jqwidgets/jqxscrollbar.js"></script>

    <script type="text/javascript" src="../../jqwidgets/jqxlistbox.js"></script>--%>
     <script src="../Scripts/jqx/gettheme.js"></script>

     <script src="../Scripts/jqx/jqx-all.js"></script>
        <script type="text/javascript">

            $(document).ready(function () {

                var theme = getDemoTheme();



                var url = "../GEOService.asmx/GetSucursales";



                // prepare the data

                var source =

                {
                    datatype: "json",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    datafields: [
                        { name: 'IdSucursal' },
                        { name: 'Nombre' }],
                    type: "POST",
                    url: "../GEOService.asmx/GetSucursales",
                    data: "{}"
                };

                $.ajax({
                    type: "POST",
                    url: "../GEOService.asmx/GetSucursales",
                    data: "{}",
                    async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                   source.localdata = data.d;
             //       $("#ddlLanguage").empty().append($("<option></option>").val("[-]").html("Seleccione Sucursal")); 
                    $.each(data.d, function() { 
                    $("#ddlLanguage").append($("<option></option>").val(this['IdSucursal']).html(this['Nombre'])); 
                    }); 
                    $("#ddlLanguage").val(2);

                },
                failure: function (msg) {
                    $('#error').text(msg);
                }
                });


                var dataAdapter = new $.jqx.dataAdapter(source);



                // Create a jqxComboBox

                $("#jqxWidget").jqxDropDownList({
                    theme: theme,
                    selectedIndex: 0, source: dataAdapter, displayMember: "Nombre", valueMember: "IdSucursal", width: 200, height: 25
                });


                $("#jqxgrid").jqxGrid(
                    {
                        source: dataAdapter,
                        theme: theme,
                        filterable: true,
                    columns: [{ text: 'Id', dataField: 'IdSucursal', width: 250 }, { text: 'Nombre', dataField: 'Nombre', width: 150 }]});


                // trigger the select event.

                //$("#jqxWidget").on('select', function (event) {

                //    if (event.args) {

                //        var item = event.args.item;

                //        if (item) {

                //            var valueelement = $("<div></div>");

                //            valueelement.text("Value: " + item.value);

                //            var labelelement = $("<div></div>");

                //            labelelement.text("Label: " + item.label);



                //            $("#selectionlog").children().remove();

                //            $("#selectionlog").append(labelelement);

                //            $("#selectionlog").append(valueelement);

                //        }

                //    }

                //});

            });

        </script>
  
        <script>
         $(document).ready(function () {
             var theme = "";

             var url = "../sampledata/customers.txt";

             // prepare the data
             var source =
             {
                 datatype: "json",
                 datafields: [
                     { name: 'IdSucursal' },
                     { name: 'Nombre' }
                 ],
                 url: url,
                 async: false,
             //contentType: "application/json; charset=utf-8",
             type: "POST",
             url: "../GEOService.asmx/GetSucursales",
             data: "{}"


             };
             var dataAdapter = new $.jqx.dataAdapter(source);

             // Create a jqxDropDownList
             $("#jqxWidget1").jqxDropDownList({
                 selectedIndex: 0, source: dataAdapter, displayMember: "IdSucursal", valueMember: "Nombre", width: 200, height: 25, theme: theme
             });

             // subscribe to the select event.
             $("#jqxWidget1").on('select', function (event) {
                 if (event.args) {
                     var item = event.args.item;
                     if (item) {
                         var valueelement = $("<div></div>");
                         valueelement.text("Value: " + item.value);
                         var labelelement = $("<div></div>");
                         labelelement.text("Label: " + item.label);

                         $("#selectionlog").children().remove();
                         $("#selectionlog").append(labelelement);
                         $("#selectionlog").append(valueelement);
                     }
                 }
             });
         });

     </script>
        <div id='jqxWidget'>
        </div>
        <div id='jqxWidget1'>
        </div>

     <select id="ddlLanguage">
     </select>

      <div id="jqxgrid"></div>
        <div style="font-size: 12px; font-family: Verdana;" id="selectionlog"></div>

    </div>
</asp:Content>
