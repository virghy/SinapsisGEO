
$(function () {

    var name = $("#name"),

      apellido = $("#apellido"),

      empresa = $("#empresa"),

      ruc = $("#ruc"),

      obs = $("#empresa"),

      allFields = $([]).add(name).add(apellido).add(empresa).add(ruc).add(obs),

      tips = $(".validateTips"),
      idCliente = 0;



    function getCliente() {
        //            clearOverlays();

        $.ajax({

            type: "POST",

            url: "../GEOService.asmx/GetCliente",

            data: "{IdCliente: " + $('#<%= TextBox1.ClientID %>').val() + " }",

            contentType: "application/json; charset=utf-8",

            dataType: "json",

            success: function (response) {

                var cl = response.d;
                //alert(cl.Nombre);
                $('#name').val(cl.Nombre);
                $('#apellido').val(cl.Apellido);
                $('#empresa').val(cl.Empresa);
                $('#ruc').val(cl.RUC);
                $('#obs').val(cl.Obs);
                idCliente = cl.IdCliente;

                //        $('#output').empty();



                //$.each(cars, function (index, car) {

                //    SetMarker(car.Data1, car.Lat, car.Lng);

                //});

            },

            failure: function (msg) {

                $('#error').text(msg);

            }

        });

    }

    function updateCliente() {
        //            clearOverlays();

        var cliente = new Object();
        var resultado = -1;
        cliente.IdCliente = idCliente;
        cliente.Nombre = $('#name').val();
        cliente.Apellido = $('#apellido').val();
        cliente.Empresa = $('#empresa').val();
        cliente.RUC = $('#ruc').val();
        cliente.Obs = $('#obs').val();

        var customerString = JSON.stringify(cliente);

        $.ajax({
            type: "POST",
            url: "../GEOService.asmx/ClienteUpdate",
            data: "{cliente: " + customerString + " }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (response) {
                var cl = response.d;
                resultado = cl;
                $("#dialog-form").dialog("close");
            },

            failure: function (msg) {

                $('#error').text(msg);

            }

        });
        return resultado;

    }

    function updateTips(t) {

        tips

          .text(t)

          .addClass("ui-state-highlight");

        setTimeout(function () {

            tips.removeClass("ui-state-highlight", 1500);

        }, 500);

    }



    function checkLength(o, n, min, max) {

        if (o.val().length > max || o.val().length < min) {

            o.addClass("ui-state-error");

            updateTips("La longitud " + n + " debe estar entre " +

              min + " y " + max + ".");

            return false;

        } else {

            return true;

        }

    }



    function checkRegexp(o, regexp, n) {

        if (!(regexp.test(o.val()))) {

            o.addClass("ui-state-error");

            updateTips(n);

            return false;

        } else {

            return true;

        }

    }



    $("#dialog-form").dialog({

        autoOpen: false,

        height: 400,

        width: 450,

        modal: true,

        buttons: {

            "Aceptar": function () {

                var bValid = true;

                allFields.removeClass("ui-state-error");



                bValid = bValid && checkLength(name, "Nombre", 3, 50);

                bValid = bValid && checkLength(apellido, "Apellido", 1, 50);

                bValid = bValid && checkLength(empresa, "Empresa", 0, 50);



                //  bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z_])+$/i, "Username may consist of a-z, 0-9, underscores, begin with a letter.");

                // From jquery.validate.js (by joern), contributed by Scott Gonzalez: http://projects.scottsplayground.com/email_address_validation/

                //   bValid = bValid && checkRegexp(email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "eg. ui@jquery.com");

                //   bValid = bValid && checkRegexp(password, /^([0-9a-zA-Z])+$/, "Password field only allow : a-z 0-9");



                if (bValid) {

                    if (updateCliente() == 0) {
                        $(this).dialog("close");
                    }



                }

            },

            Cancel: function () {

                $(this).dialog("close");

            }

        },

        close: function () {

            allFields.val("").removeClass("ui-state-error");

        }

    });



    $('#<%= cmdEditar.ClientID %>')

      .button()

      .click(function () {

          $("#dialog-form").dialog("open");
          getCliente();
          return (false);

      });

    $("#create-user")

      .button()

      .click(function () {

          $("#dialog-form").dialog("open");
          //              getCliente();
          return (false);

      });


});
