var cont = 0;
var cont2 = 0;
var cont3 = 0;
var cont4 = 0;
var cont5 = 0;
var cont6 = 0;
var cont7 = 0;

function CargaProyectos() {
    getProvinciasID('../../Provincias/GetProvincias', $('input[name=ProvinciaObra]')[0].value);
    getTipoEstudiosID('../GetTiposEstudio', $('input[name=TipoEstudio]')[0].value);
    getPresupuestosID('../GetPresupuestos', $('input[name=PemPec]')[0].value);
    getFasesPorProyecto('../GetFasesPorProyecto', $('input[name=IdObra]')[0].value);
    getTipoObraID('../getTipoObra', $('input[name=TipoObra]')[0].value);
    //getTipoProyecto('../getTipoProyecto', $('input[name=TipoProyecto]')[0].value);


}
function CompruebaProyectos() {
    $('input[name=TipoEstudio]')[0].value = document.getElementById('SelectTipoEstudio').value;
    $('input[name=ProvinciaObra]')[0].value = document.getElementById('SelectProvinciaObra').value;
    $('input[name=PemPec]')[0].value = document.getElementById('SelectPresupuesto').value;
    $('input[name=TipoObra]')[0].value = document.getElementById('SelectTipoObra').value;

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
function getTipoObra(action) {


    if (cont6 != 0) {
        return;
    }
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            for (var i = 0; i < response.length; i++) {
                document.getElementById('SelectTipoObra').options[i] = new Option(response[i].text, response[i].value);
            }
            cont6 = 1;
        }
    });
}
function getTipoObraID(action, ID) {


    if (cont7 != 0) {
        return;
    }

    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            for (var i = 0; i < response.length; i++) {
                if (ID != response[i].value) document.getElementById('SelectTipoObra').options[i] = new Option(response[i].text, response[i].value, false, false);
                else document.getElementById('SelectTipoObra').options[i] = new Option(response[i].text, response[i].value, false, true);
            }
            cont7 = 1;
        }
    });
}
function getFasesPorProyecto(action, ID) {

    $.ajax({
        type: "POST",
        url: action,
        data: { ID },
        success: function (response) {
            var tabla = "";
            tabla = "<table border='0' class='table' width='100%'>";
            if (response.length == 0) {
                tabla += "<tr><td>NO EXISTEN FASES ASOCIADAS</td></tr>";
                tabla += "<tr><td><a class='btn btn-primary' data-toggle='modal' data-target='#modalAgregar'>Agregar</a></td> ";
                tabla += "</table>";
            }
            else
            {

                for (var i = 0; i < response.length; i++) {
                    var str = response[i].text;
                    var res = str.split("||");
                    tabla += "<tr><td>" + res[0] + "</td><td>" + res[1] + "</td><td>" + response[i].value + "</td>";
                    tabla += "<td><a class='btn btn-success' data-toggle='modal' data-target='#modalEditar' onclick=getFase('" + response[i].value + "','../../Fases/GetFase')>Editar</a></td><td> | </td>";
                    tabla += "<td><a class='btn btn-danger' data-toggle='modal' data-target='#modalEliminar' onclick=getFase('" + response[i].value + "','../../Fases/GetFase')>Eliminar</a></td><td> | </td>";
                    tabla += "<td><a class='btn btn-warning' data-toggle='modal' data-target='#modalAreas' onclick=getActividadesPorFase('../../Actividades/getActividadesPorFase','" + response[i].value + "','" + res[0] + "')> &nbsp;Áreas&nbsp;&nbsp; </a></td >";
                    tabla += "</tr > ";
                }
                tabla += "</tr></tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td><a class='btn btn-primary' data-toggle='modal' data-target='#modalAgregar'>Agregar</a></td> ";
                tabla += "</table>";
            }
            document.getElementById('TFases').innerHTML = "FASES:<br><br>" + tabla;

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
            alert(action);
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
                $('#modalAgregar').modal('hide');
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

    $('input[name=IdFase]')[0].value="";
    $('input[name=Fase]')[0].value="";

}
function actualizarFase(action) {
    //Obtener los datos ingresados en los inputs respectivos
    IdFase = $('input[name=EIdFase]')[0].value;
    Fase = $('input[name=EFase]')[0].value;
    IdProyecto = $('input[name=EIdProyecto]')[0].value;
    var Id = $('input[name=EId]')[0].value;
    $.ajax({
        type: "POST",
        url: action,
        data: {
            Id, IdProyecto, IdFase, Fase
        },
        success: function (response) {
            if (response === "OK") {
                getFasesPorProyecto('../GetFasesPorProyecto', IdProyecto);
                $('#modalEditar').modal('hide');
            }
            else {
                $('#Emensajenuevo').html("No se puede guardar la fase.");
            }
        }
        ,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
            alert(action);
        }
    });

    $('input[name=EIdFase]')[0].value = "";
    $('input[name=EFase]')[0].value = "";
    $('input[name=EIdProyecto]')[0].value = "";
    $('input[name=EId]')[0].value = "";

}
function mostrarFase(response) {
    items = response;
    cont5 = 0;

    $.each(items, function (index, val) {
        $('input[name=EIdFase]').val(val.idFase);
        $('input[name=EFase]').val(val.fase);
        $('input[name=EIdProyecto]').val(val.idProyecto);
        $('input[name=EId]').val(val.id);
        $('input[name=EId2]').val(val.id);

        //Mostrar los detalles del usuario
        $("#EIdFase").text(val.idFase);
        $("#EFase").text(val.fase);
        $("#EIdProyecto").text(val.idProyecto);
        $("#EId").text(val.id);
        $("#EId2").text(val.id);

    });
}
function getFase(id, action) {
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            mostrarFase(response);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
            alert(action);
        }  

    });
}

function getActividadesPorFase(action, ID, nombre) {
    $.ajax({
        type: "POST",
        url: action,
        data: { ID },
        success: function (response) {
            var tabla = "";
            tabla = "<table border='0' class='table' width='100%'>";
            if (response.length == 0) {
                tabla += "<tr><td>NO EXISTEN ACTIVIDADES ASOCIADAS</td></tr>";
                tabla += "<tr><td><a class='btn btn-primary' data-toggle='modal' onclick=marcaFase('" + ID + "'); data-target='#modalAgregarActividad'>Agregar</a></td> ";
                tabla += "</table>";
            }
            else {

                for (var i = 0; i < response.length; i++) {
                    var str = response[i].text;
                    tabla += "<tr><td title='" + response[i].descripcion + "'>" + response[i].actividad + "</td><td>" + response[i].idActividad + "</td><td>" + response[i].id + "</td>";
                    tabla += "<td><a class='btn btn-success' data-toggle='modal' data-target='#modalEditarActividad' onclick=getActividad('" + response[i].id + "','../../Actividades/GetActividad')>Editar</a></td><td> | </td>";
                    tabla += "<td><a class='btn btn-danger' data-toggle='modal' data-target='#modalEliminarActividad' onclick=alert('1');getActividad('" + response[i].id + "','../../Actividades/GetActividad');alert('2');>Eliminar</a></td>";
                    tabla += "</tr > ";
                }
                tabla += "</tr></tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td><a class='btn btn-primary' data-toggle='modal' onclick=marcaFase('" + ID + "'); data-target='#modalAgregarActividad'>Agregar</a></td> ";
                tabla += "</table>";
            }
            document.getElementById('TActividades').innerHTML = "ACTIVIDADES DE LA FASE: " + nombre + "<br><br>" + tabla;

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
            alert(action);
        }
    });
}
function marcaFase(id)
{
    $('input[name=AIdFase]')[0].value=id; 
    alert($('input[name=AIdFase]')[0].value);

}
function crearActividad(action) {

    var IdActividad;
    var Actividad;
    var Descripcion;
    var IdFase;

    //Obtener los datos ingresados en los inputs respectivos
    IdFase = $('input[name=AIdFase]')[0].value;
    IdActividad = $('input[name=AIdActividad]')[0].value;
    Actividad = $('input[name=AActividad]')[0].value;
    Descripcion = $('input[name=ADescripcion]')[0].value;
    var Id = 0;
    $.ajax({
        type: "GET",
        url: action,
        data: {
            IdFase, IdActividad, Actividad, Descripcion
        },
        success: function (response) {
            if (response === "OK") {
                getActividadesPorFase('../GetActividadesPorFase', IdFase);
                $('#modalAgregarActividad').modal('hide');
            }
            else {
                $('#mensajenuevoActividad').html("No se puede guardar la actividad."+ response);
            }
        }
        ,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
            alert(action);
        }
    });

    $('input[name=AIdFase]')[0].value = "";
    $('input[name=AIdActividad]')[0].value = "";
    $('input[name=AActividad]')[0].value = "";
    $('input[name=ADescripcion]')[0].value = "";

}
function actualizarActividad(action) {
    var IdActividad;
    var Actividad;
    var Descripcion;
    var Id;

    //Obtener los datos ingresados en los inputs respectivos
    Id = $('input[name=EAId]')[0].value;
    IdActividad = $('input[name=EAIdActividad]')[0].value;
    Actividad = $('input[name=EAActividad]')[0].value;
    Descripcion = $('input[name=EADescripcion]')[0].value;

    $.ajax({
        type: "POST",
        url: action,
        data: {
            Id, IdActividad, Actividad, Descripcion
        },
        success: function (response) {
            if (response === "OK") {
                getFasesPorProyecto('../GetActividadesPorFase', IdFase);
                $('#modalEditarActividad').modal('hide');
            }
            else {
                $('#EmensajenuevoActividad').html("No se puede guardar la fase.");
            }
        }
        ,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
            alert(action);
        }
    });

    $('input[name=EAIdDescripcion]')[0].value = "";
    $('input[name=EAIdActividad]')[0].value = "";
    $('input[name=EAActividad]')[0].value = "";
    $('input[name=EAId]')[0].value = "";

}
function mostrarActividad(response) {
    items = response;
    cont5 = 0;

    $.each(items, function (index, val) {
        $('input[name=EAIdFase]').val(val.idFase);
        $('input[name=EAActividad]').val(val.Actividad);
        $('input[name=EAIdActividad]').val(val.IdActividad);
        $('input[name=EAId]').val(val.id);
        $('input[name=EADescripcion]').val(val.Descripcion);

        //Mostrar los detalles del usuario
        $("#EAIdActividad").text(val.IdActividad);
        $("#EAActividad").text(val.Actividad);
        $("#EADescripcion").text(val.Descripcion);
        $("#EAIdFase").text(val.idFase);
        $("#EAId").text(val.id);

        $('input[name=EAId2]').val(val.id);
        $('input[name=EId2]').val(val.id);
        $('input[name=ENombreFase2]').val(val.fase);
        $("#DAIdFase").text(val.idFase);
        
    });
}
function getActividad(id, action) {
    alert(id);
    alert(action);
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            mostrarActividad(response);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
            alert(action);
        }

    });
}


function eliminarActividad(action) {

    var ID = $('input[name=EAId2]')[0].value;
    var nombreFase = $('input[name=ENombreFase2]')[0].value;
    var idFase = $("#DAIdFase")[0].value;

    $.ajax({
        type: "GET",
        url: action,
        data: { ID } ,
        success: function (response) {
            if (response === "OK") {
                $('#modalAgregarActividad').modal('hide');
                getActividadesPorFase('../GetActividadesPorFase',idFase, nombreFase);
            }
            else {
                alert("No se puede eliminar el registro. Err: " + response);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
        }
    });
}
function eliminarFase(action) {
    var ID = $('input[name=EId]')[0].value;
    alert(ID);
    $.ajax({
        type: "GET",
        url: action,
        data: { ID } ,
        success: function (response) {
            if (response === "OK") {
                getFasesPorProyecto('../GetFasesPorProyecto', $('input[name=IdObra]')[0].value);
                $('#modalEliminar').modal('hide');
            }
            else {
                alert("No se puede eliminar el registro. Err: " + response);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
        }
    });
}
//~