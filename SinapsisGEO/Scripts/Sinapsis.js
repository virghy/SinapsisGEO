

function SumarAdicionales() {
    Adicional = 0;
    _Items = ""

    for (i = 0; i < document.forms[0].elements.length; i++) {
        elm = document.forms[0].elements[i];
        if (elm.type == 'checkbox' || elm.type == 'radio') {
            if (elm.checked == true) {
                _Items += elm.value.substr(0, elm.value.lastIndexOf(":")) + ",";
                Adicional += parseInt(elm.value.substr(elm.value.lastIndexOf(":") + 1), 10);

            }

        }
    }
    
    obj = $get('MainContent_lblAdicional');
    //obj = $get('lblPrecio');
    //obj.innerText = Adicional;
    obj.innerHTML = Adicional;
    obj = $get('MainContent_lblItems');
    obj.innerHTML = _Items;
    Pr = $get('MainContent_lblPrecio');
    obj = $get('MainContent_lblImporte');

    obj.innerHTML = (parseInt(Pr.innerHTML, 10) + Adicional) * parseInt($get("MainContent_cboCantidad").value);

}




//$("[id*=1] input:checkbox").change(
//    function ()
//    {
//        var maxSelection = 3;
//        if ($("[id*=CheckBoxList1] input:checkbox:checked").length > maxSelection)
//        {
//            $(this).prop("checked", false);
//            alert("Please select a maximum of " + maxSelection + " items.");
//        }
//    })
