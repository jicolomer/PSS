$(document).ready(function () {
    $("#tblContacts").hide();
});

$("#txtBuscar").keyup(function () {
    var Prefix = $('input[name=txtBuscar]')[0].value;
    if (Prefix.length>=3) getPaciente();
});


function irAPaciente(id) {
    var url = "Pacientes?id=" + id; // Establecer URL de la acción        
    window.open(url,"_self");
}

function getPaciente() {

    var Prefix = $('input[name=txtBuscar]')[0].value;
    $.ajax({
        type: "POST",
        url: "Pacientes/Buscar",
        data: { Prefix },
        success: function (response) {
            var row = "";
            $.each(response, function (index, item) {
                //row += "<tr onclick=window.open('Pacientes/" + item.numerohc + "');>";
                row += "<tr onclick=irAPaciente('" + item.numerohc + "');>";
                row += "<td><input type='checkbox' id='" + item.numerohc + "' name='chooseRecipient' class='my_chkBox' /></td >";
                row += "<td>" + item.numerohc + "</td>";
                row += "<td>" + item.apellido1 + " " + item.apellido2 + ", " + item.nombre + "</td>";
                row += "</tr > ";
            });
            $("#contacts").html(row);   
            $("#tblContacts").show();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error: " + errorThrown);
            alert(action);
        }

    });

}



// Write your JavaScript code.
$('#modalEditar').on('shown.bs.modal', function () {
    $('#myInput').focus();
});

function getUsuario(id,action) {
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            mostrarUsuario(response);
        }

    });
}
var items;
var j = 0;
var j2= 0;
//Variables globales por cada propiedad del usuario
var id;
var userName;
var email;
var phoneNumber;
var role;
var selectRole;

//Otras variables donde almacenaremos los datos del registro, pero estos datos no serán modificados
var accessFailedCount;
var concurrencyStamp;
var emailConfirmed;
var lockoutEnabled;
var lockoutEnd;
var normalizedUserName;
var normalizedEmail;
var passwordHash;
var phoneNumberConfirmed;
var securityStamp;
var twoFactorEnabled;

function mostrarUsuario(response) {
    items = response;
    j = 0;
    for (var i = 0; i < 3; i++) {
        var x = document.getElementById('Select');
        var x2 = document.getElementById('SelectEmpresas');
        x.remove(i);
        x2.remove(i);
    }

    $.each(items, function (index, val) {
        $('input[name=Id]').val(val.id);
        $('input[name=UserName]').val(val.userName);
        $('input[name=Email]').val(val.email);
        $('input[name=PhoneNumber]').val(val.phoneNumber);
        document.getElementById('Select').options[0] = new Option(val.role, val.roleId);
        document.getElementById('SelectEmpresas').options[0] = new Option(val.empresa, val.empresaId);

        //Mostrar los detalles del usuario
        $("#dEmail").text(val.email);
        $("#dUserName").text(val.userName);
        $("#dPhoneNumber").text(val.phoneNumber);
        $("#dRole").text(val.role);
        $("#dEmpresa").text(val.empresa);

        //Mostrar los datos del usuario que deseo eliminar
        $("#eUsuario").text(val.email);
        $('input[name=EIdUsuario]').val(val.id);

    });
}

function getRoles(action) {
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (j==0){
                for (var i = 0; i < response.length; i++){
                    document.getElementById('Select').options[i] = new Option(response[i].text, response[i].value);
                    document.getElementById('SelectNuevo').options[i] = new Option(response[i].text, response[i].value);
                }
                j = 1;
            }
        }
    });
}

function editarUsuario(action) {
    //Obtenemos los datos del input respectivo del formulario
    id = $('input[name=Id]')[0].value;
    email = $('input[name=Email]')[0].value;
    phoneNumber = $('input[name=PhoneNumber]')[0].value;
    role = document.getElementById('Select');
    selectRole = role.options[role.selectedIndex].text;
    empresa = document.getElementById('SelectEmpresas');
    selectEmpresa = empresa.value;

    $.each(items, function (index, val) {
        accessFailedCount = val.accessFailedCount;
        concurrencyStamp = val.concurrencyStamp;
        emailConfirmed = val.emailConfirmed;
        lockoutEnabled = val.lockoutEnabled;
        lockoutEnd = val.lockoutEnd;
        userName = val.userName;
        normalizedUserName = val.normalizedUserName;
        normalizedEmail = val.normalizedEmail;
        passwordHash = val.passwordHash;
        phoneNumberConfirmed = val.phoneNumberConfirmed;
        securityStamp = val.securityStamp;
        twoFactorEnabled = val.twoFactorEnabled;
    });
    $.ajax({
        type: "POST",
        url: action,
        data: {
            id, userName, email, phoneNumber, accessFailedCount,
            concurrencyStamp, emailConfirmed, lockoutEnabled, lockoutEnd,
            normalizedEmail, normalizedUserName, passwordHash, phoneNumberConfirmed,
            securityStamp, twoFactorEnabled,selectRole, selectEmpresa
        },
        success: function (response) {
            if (response == "Save") {
                window.location.href = "Usuarios";
            }
            else {
                alert("No se puede editar los datos del usuario");
            }
        }
    });


}

function ocultarDetalleUsuario() {
    $("#modalDetalle").modal("hide");
}

function eliminarUsuario(action) {
    var id = $('input[name=EIdUsuario]')[0].value;
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            if (response === "Delete") {
                window.location.href = "Usuarios";
            }
            else {
                alert("No se puede eliminar el registro");
            }
        }
    });
}

function crearUsuario(action) {
    //Obtener los datos ingresados en los inputs respectivos
    email = $('input[name=EmailNuevo]')[0].value;
    phoneNumber = $('input[name=PhoneNumberNuevo]')[0].value;
    passwordHash = $('input[name=PasswordHashNuevo]')[0].value;
    role = document.getElementById('SelectNuevo');
    selectRole = role.options[role.selectedIndex].text;
    empresa = document.getElementById('SelectEmpresasNuevo');
    selectEmpresa = empresa.value;

    //Vamos a validar ahora que los datos del usuario no estén vacíos
    if (email == "") {
        $('#EmailNuevo').focus();
        alert("Ingrese el email del usuario");
    }
    else {
        if (passwordHash=="") {
            $('#PasswordHashNuevo').focus();
            alert("Ingrese el password del usuario");
        }
        else {
            $.ajax({
                type: "POST",
                url: action,
                data: {
                    email, phoneNumber, passwordHash, selectRole, selectEmpresa
                },
                success: function (response) {
                    if (response === "Save") {
                        window.location.href = "Usuarios";
                    }
                    else {
                        $('#mensajenuevo').html("No se puede guardar el usuario. <br/>Seleccione un rol. <br/> Ingrese un email correcto. <br/> El password debe tener de 6-100 caracteres, al menos un caracter especial, una letra mayúscula y un número");
                    }
                }
            });
        }
    }

}

function getEmpresas(action) {
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (j2 == 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('SelectEmpresas').options[i] = new Option(response[i].text, response[i].value);
                    document.getElementById('SelectEmpresasNuevo').options[i] = new Option(response[i].text, response[i].value);
                }
                j2 = 1;
            }
        }
    });
}
