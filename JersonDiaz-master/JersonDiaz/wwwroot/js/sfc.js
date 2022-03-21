
$(document).ready(function () {
    $('.ms-Tooltip').tooltip();
});

jQuery(document).ready(function () {
    $(".oculto").hide();
    $(".inf").click(function () {
        var nodo = $(this).attr("href");

        if ($(nodo).is(":visible")) {
            $(nodo).hide();
            return false;
        } else {
            $(".oculto").hide("slow");
            $(nodo).fadeToggle("fast");
            return false;
        }
    });
});

//$(function () {
//    $.datepicker.setDefaults($.datepicker.regional["ni"]);
//    $(".datepicker").datepicker({
//        dateFormat: 'dd-mm-yy',
//        firstDay: 1,
//        monthNames: ['Enero', 'Febreo', 'Marzo','Abril', 'Mayo', 'Junio','Julio', 'Agosto', 'Septiembre','Octubre', 'Noviembre', 'Diciembre'],
//        dayNamesMin: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'],
//        changeYear: true
//    });
//});

$(function () {
    $('.datepicker').datepicker({
        format: 'dd-mm-yyyy',
        language: 'ni',
        autoclose: 'true'
    });
});

$(window).load(function () {
    $('.loader').fadeOut('slow');
});

$(document).ready(function () {
    //FORMATO DE MASCARAS
    $('.num-cedula').mask('000-000000-0000A', { placeholder: '000-000000-0000A' });
    $('.num-inss').mask('0000000000', { placeholder: '0000000000' }); //placeholder
    $('.x-fecha').mask('00-00-0000', { placeholder: 'DD-MM-YYYY' });
    $('.x-monto').mask("#,###,###.##", { reverse: true });
    $('.num-tel').mask('0000-0000', { placeholder: '0000-0000' }); //placeholder
    $('.cuenta-conta').mask('000000000', { placeholder: '000000000' }); //placeholder
    $('.codigo-mes').mask('000000', { placeholder: '000000' }); //placeholder
    $('.num-entero').mask("#########", { reverse: true });
    $('.entero').mask("#########", { reverse: true });
    $('.num-entero_x').mask("############", { placeholder: '000000000000' });

});

function ShowSelectedMASK() {

    /* Para obtener el valor */
    var cod = document.getElementById("IDENTIFICA").value;
    //alert(cod);
       
    if (cod == 1)
    {
       
        var t1 = parseFloat(document.getElementById("NOM_CLIENTE").value = "");
        var t1 = parseFloat(document.getElementById("IDENTIFICACION").value = "");
        //var t1 = parseFloat(document.getElementById("TEL_GESTOR").value = "");
        

        $('#IDENTIFICACION').mask('000-000000-0000A', { placeholder: '000-000000-0000A' });


        //alert(cod);
    }
   else
    if (cod == 2)
    {
        var t1 = parseFloat(document.getElementById("NOM_CLIENTE").value = "");
        var t1 = parseFloat(document.getElementById("IDENTIFICACION").value = "");
        //var t1 = parseFloat(document.getElementById("TEL_GESTOR").value = "");
        
        $('#IDENTIFICACION').mask('0000000000', { placeholder: '0000000000' });
   
       //alert(cod);
    }
    else
        if (cod == 3) {

            var t1 = parseFloat(document.getElementById("NOM_CLIENTE").value = "");
            var t1 = parseFloat(document.getElementById("IDENTIFICACION").value = "");
            //var t1 = parseFloat(document.getElementById("TEL_GESTOR").value = "");
         

            $('#IDENTIFICACION').mask('A00000000', { placeholder: 'A00000000' });
        //alert(cod);
    }

};

