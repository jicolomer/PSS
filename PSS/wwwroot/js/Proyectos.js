function CompruebaProyectos() {
    $('input[name=TipoEstudio]')[0].value = document.getElementById('SelectTipoEstudio').value;

    alert($('input[name=TipoEstudio]')[0].value);
    var txt;
    var r = confirm("Desea grabar?");
    if (r == true) {
        return true;
    } else {
        return false;
    }

}
function getTipoEstudios(action) {

    if (document.getElementById('SelectTipoEstudio')[0].text == "PSS") return;
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (j == 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('SelectTipoEstudio').options[i] = new Option(response[i].text, response[i].value);
                }
                j = 1;
            }
        }
    });
}
