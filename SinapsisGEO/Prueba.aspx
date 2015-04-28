<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="SinapsisGEO.Prueba" %>

<%@ Register Src="~/Control/PanelCombo.ascx" TagPrefix="uc1" TagName="PanelCombo" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<%--    <script type="text/javascript" src="/Scripts/jquery.easyModal.js" ></script>--%>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js"></script>
<script type="text/javascript" src="http://flaviusmatis.github.io/easyModal.js/hl-all.js"></script>
<script type="text/javascript" src="http://flaviusmatis.github.io/easyModal.js/jquery.easyModal.js"></script>
<script type="text/javascript" src="http://flaviusmatis.github.io/easyModal.js/script.js"></script>
 
    <script type="text/javascript">
     $(function () {
         function checkBoxClicked() {
             //Get the total of selected CheckBoxes
             var n1 = $("#list1 input:checked").length;
             var n2 = $("#list2 input:checked").length;
             
             //Set the value of the txtCheckbox control
             $("#txtCheckbox :input").val(n1 == 0 ? "" : n1);
             $("#MainContent_txtCheckbox2 :input").val(n2 == 0 ? "" : n2);
         }

         //intercept any check box click event inside the #list Div
         $("#list1 :checkbox").click(checkBoxClicked);
         $("#list2 :checkbox").click(checkBoxClicked);


        //Limitamos el nro de elementos que puede seleccionar
         $("#MainContent_chklHobbies, #MainContent_chklHobbies2").click(function (e) {
             if ($('#' + this.id + ' input[type="checkbox"]:checked').length > 2) {
                 e.preventDefault();
             }
         });

     });
//     $(document).ready(
//    function () {
        
//        $('#MainContent_btnRight').click(function () { alert('button clicked'); });

//    }
//);


     $(document).ready(function() {

         //$('input[id$=btnRight]').click(function(){ alert('button clicked'); });

         $('input[id$=btnRight]').click(function(e) {
             var selectedOpts = $('select[id$=lstBox1] option:selected');

             if (selectedOpts.length == 0) {
                 alert("Please select item (s) to move.");
                 e.preventDefault();
             } 

             $('select[id$=lstBox2]').append($(selectedOpts).clone());
             $(selectedOpts).remove();
             e.preventDefault();

         });

         $('input[id$=btnLeft]').click(function(e) {
             var selectedOpts = $('select[id$=lstBox2] option:selected');

             if (selectedOpts.length == 0) {
                 alert("Please select item (s) to move.");
                 e.preventDefault();
             }

             $('select[id$=lstBox1]').append($(selectedOpts).clone());
             $(selectedOpts).remove();
             e.preventDefault();
         });





                 $("[id*=btnSubmit]").bind("click", function () {

                     $("[id*=lstLeft] option").attr("selected", "selected");

                     $("[id*=lstRight] option").attr("selected", "selected");

                 });




     });

    </script>

    <style>

/*Modal Popup*/
.modalBackground {
	background-color:Gray;
	filter:alpha(opacity=70);
	opacity:0.7;
}

.modalPopup {
	background-color:#ffffdd;
	border-width:3px;
	border-style:solid;
	border-color:Gray;
	padding:3px;
	width:400px;
}

.modalPopup p {
    padding: 5px;
}

.sampleStyleA {
	background-color:#FFF;
}

.sampleStyleB {
	background-color:#FFF;
	font-family:monospace;
	font-size:10pt;
	font-weight:bold;
}

.sampleStyleC {
	background-color:#ddffdd;
	font-family:sans-serif;
	font-size:10pt;
	font-style:italic;
}

.sampleStyleD {
	background-color:Blue;
	color:White;
	font-family:Arial;
	font-size:10pt;
}



     div#show {
    width:280px;
    height:200px;
    padding:20px;
    position:absolute;
    left:50%;
    margin-left:-120px;
    top:50%;
    margin-top:-160px;
    background:#40464b;
    border-radius:6px;
}

h1 {
    font-size:14px;
    color:#f2f2f2;
    text-align:center;
    margin:0 0 20px;
    padding:0;
    font-family:Arial;
}

/*input[type="checkbox"] {
    display:none;
}

input[type="checkbox"] + label {
    color:#f2f2f2;
    font-family:Arial, sans-serif;
    font-size:14px;
}

input[type="checkbox"] + label span {
    display:inline-block;
    width:19px;
    height:19px;
    margin:-1px 4px 0 0;
    vertical-align:middle;
    background:url(Images/check_radio_sheet.png) left top no-repeat;
    cursor:pointer;
}

input[type="checkbox"]:checked + label span {
    background:url(Images/check_radio_sheet.png) -19px top no-repeat;
}

input[type="radio"] {
    display:none;
}

input[type="radio"] + label {
    color:#f2f2f2;
    font-family:Arial, sans-serif;
    font-size:14px;
}

input[type="radio"] + label span {
    display:inline-block;
    width:19px;
    height:19px;
    margin:-1px 4px 0 0;
    vertical-align:middle;
    background:url(Images/check_radio_sheet.png) -38px top no-repeat;
    cursor:pointer;
}

input[type="radio"]:checked + label span {
    background:url(Images/check_radio_sheet.png) -57px top no-repeat;
}*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id ="contenedor">
			<div id ="cabecera">Cabecera </div>
			<div id ="barraMenu">

			</div>
			<div id ="izquierda">
                
                <div id="modal1">
                    Modal 1
                </div>
                <div id="modal2" Style="display: none" class="modalPopup">
                    <h3>Seleccione el contenido del combo</h3> 
                    <uc1:PanelCombo runat="server" ID="PanelCombo" />
                </div>

<%--                <p class="spacer">I have included two basic examples, an <a id="open-modal1" href="#">alert panel</a> and a <a id="open-modal2" href="#">sign up form</a>.</p>--%>

                <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                <ajaxToolkit:ModalPopupExtender BackgroundCssClass="modalBackground" ID="MPE" runat="server"
                TargetControlID="LinkButton1"
                PopupControlID="modal2"/>



<div id="list1">
                        <asp:CheckBoxList ID="chklHobbies" runat="server" ValidationGroup="testGroup" RepeatDirection="Vertical"
                            RepeatLayout="Table" RepeatColumns="3">
                            <asp:ListItem Text="Sport" Value="Sport" />
                            <asp:ListItem Text="Fishing" Value="Fishing" />
                            <asp:ListItem Text="Reading Books" Value="ReadingBooks" />
                            <asp:ListItem Text="Swimming" Value="Swimming" />
                            <asp:ListItem Text="Listening To Music" Value="ListiningToMusic" />
                        </asp:CheckBoxList>
                            
                        <asp:TextBox ID="txtCheckbox" runat="server" ValidationGroup="testGroup" />
                        <div style='display:none;'>

                            <asp:RequiredFieldValidator ID="valCheckboxList" Display="None" ErrorMessage="At least one hobby value must be selected 1"
                                runat="server" ControlToValidate="txtCheckbox" ValidationGroup="testGroup" EnableClientScript="true">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    
                <div id="list2">
                        <asp:CheckBoxList ID="chklHobbies2" runat="server" ValidationGroup="testGroup" RepeatDirection="Vertical"
                            RepeatLayout="Table" RepeatColumns="3">
                            <asp:ListItem Text="Sport" Value="Sport" />
                            <asp:ListItem Text="Fishing" Value="Fishing" />
                            <asp:ListItem Text="Reading Books" Value="ReadingBooks" />
                            <asp:ListItem Text="Swimming" Value="Swimming" />
                            <asp:ListItem Text="Listening To Music" Value="ListiningToMusic" />
                        </asp:CheckBoxList>


                        <asp:TextBox ID="txtCheckbox2" runat="server" ValidationGroup="testGroup" />                            
                        <div style='display:none;'>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" ErrorMessage="At least one hobby value must be selected 2"
                                runat="server" ControlToValidate="txtCheckbox2" ValidationGroup="testGroup" EnableClientScript="true">*</asp:RequiredFieldValidator>
                        </div>
                    </div>

                <asp:Button ID="Button1" runat="server" Text="Button" ValidationGroup="testGroup" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="testGroup" />


                <asp:ListBox ID="lstBox1" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Value="1" Text="Valor 1"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Valor 2"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Valor 3"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Valor 4"></asp:ListItem>
                </asp:ListBox>
                <asp:Button ID="btnRight" runat="server" Text="=>" OnClientClick='return(false);' />
                 <asp:Button ID="btnLeft" runat="server" Text="<=" />

                <asp:ListBox ID="lstBox2" AppendDataBoundItems="true" runat="server">
                </asp:ListBox>

			</div>
			<div id ="derecha">Derecha</div>
			<div id ="pie">
			</div>
		</div>

</asp:Content>
