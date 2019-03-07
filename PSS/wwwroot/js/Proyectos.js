var cont = 0;
var cont2 = 0;
var cont3 = 0;
var cont4 = 0;

function CargaProyectos() {
    getProvinciasID('../../Provincias/GetProvincias', $('input[name=ProvinciaObra]')[0].value);
    getTipoEstudiosID('../GetTiposEstudio', $('input[name=TipoEstudio]')[0].value);
    getPresupuestosID('../GetPresupuestos', $('input[name=PemPec]')[0].value);
    getFasesPorProyecto('../GetFasesPorProyecto', $('input[name=IdObra]')[0].value);


}


function CompruebaProyectos() {
    $('input[name=TipoEstudio]')[0].value = document.getElementById('SelectTipoEstudio').value;
    $('input[name=ProvinciaObra]')[0].value = document.getElementById('SelectProvinciaObra').value;
    $('input[name=PemPec]')[0].value = document.getElementById('SelectPresupuesto').value;

    var txt;
    var r = confirm("Realmente desea grabar?");
    if (r == true) {
        return true;
    } else {
        return false;
    }

}
function getTipoEstudios(action) {

    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (cont == 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('SelectTipoEstudio').options[i] = new Option(response[i].text, response[i].value);
                }
                cont = 1;
            }
        }
    });
}
function getProvincias(action) {

    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (cont2 == 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('SelectProvinciaObra').options[i] = new Option(response[i].text, response[i].value);
                }
                cont2 = 1;
            }
        }
    });
}

function getProvinciasID(action,ID) {

    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (cont3 == 0) {
                for (var i = 0; i < response.length; i++) {
                    if (response[i].value!=ID) document.getElementById('SelectProvinciaObra').options[i] = new Option(response[i].text, response[i].value,false,false);
                    else document.getElementById('SelectProvinciaObra').options[i] = new Option(response[i].text, response[i].value, false, true);
                }
                cont3 = 1;
            }
        }
    });
}
function getTipoEstudiosID(action,ID) {

    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (cont == 0) {
                for (var i = 0; i < response.length; i++) {
                    if (ID != response[i].value) document.getElementById('SelectTipoEstudio').options[i] = new Option(response[i].text, response[i].value,false,false);
                    else  document.getElementById('SelectTipoEstudio').options[i] = new Option(response[i].text, response[i].value, false, true);
                }
                cont = 1;
            }
        }
    });
}



function getPresupuestosID(action, ID) {

    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (cont4 == 0) {
                for (var i = 0; i < response.length; i++) {
                    if (ID != response[i].value) document.getElementById('SelectPresupuesto').options[i] = new Option(response[i].text, response[i].value, false, false);
                    else document.getElementById('SelectPresupuesto').options[i] = new Option(response[i].text, response[i].value, false, true);
                }
                cont4 = 1;
            }
        }
    });
}
function getPresupuestos(action) {

    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (cont5 == 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('SelectPresupuesto').options[i] = new Option(response[i].text, response[i].value);
                }
                cont5 = 1;
            }
        }
    });
}


function getFasesPorProyecto(action, ID) {

    $.ajax({
        type: "POST",
        url: action,
        data: {ID},
        success: function (response) {
            var tabla = "";
            tabla = "<table>";
            if (response.length == 0) {
                tabla += "<tr><td>NO EXISTEN FASES ASOCIADAS</td></tr></table>";
            }
            else
            {

                for (var i = 0; i < response.length; i++) {
                    tabla += "<tr><td>" + response[i].text + response[i].value + "</td></tr>";
                }
                tabla += "</table>";
            }
            document.getElementById('TFases').innerHTML = tabla;

        }
    });
}


var IdFase;
var Fase;
var IdProyecto;

function crearFase(action) {
    //Obtener los datos ingresados en los inputs respectivos
    IdFase = $('input[name=IdFase]')[0].value;
    Fase = $('input[name=Fase]')[0].value;
    IdProyecto = $('input[name=IdProyecto]')[0].value;
    var Id = 0;
    $.ajax({
        type: "POST",
        url: action,
        data: {
            IdProyecto, IdFase, Fase
        },
        success: function (response) {
            if (response === "OK") {
                getFasesPorProyecto('../GetFasesPorProyecto', $('input[name=IdObra]')[0].value);
            }
            else {
                $('#mensajenuevo').html("No se puede guardar la fase.");
            }
        }
        ,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
            alert(action);
        }  
    });
}
