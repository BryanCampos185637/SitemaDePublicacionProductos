$(function () {
    listar();
})
function abrirModal() {
    colorDefault();
    limpiar();
    listarPaginas();
}
function listar() {
    crearTabla("/tipousuario/listar", ["nombre", "descripcion"], "iidtipousuario",
        ["NOMBRE", "DESCRIPCION"], document.getElementById("domDinamico"));
}
function detalle(id) {
    abrirModal();
    $.get("/tipousuario/obtenerPorId?id=" + id, function (data) {
        $("#iidtipousuario").val(data.iidtipousuario);
        $("#nombre").val(data.nombre);
        $("#descripcion").val(data.descripcion);
        listarPaginas();
    })
}
function enviar() {
    if (validarVacios()) {
        var frm = new FormData();
        capturarDatos(frm);
        //capturamos los check manualmente
        var checkes = document.getElementsByClassName("paginasCheck");//obtenemos todos los check que contenga la clase paginasCheck
        for (var i = 0; i < checkes.length; i++) {//los vamos a recorrer usando for
            if (checkes[i].checked == true) {// si el input esta marcado
                var idpagina = checkes[i].value;//almacenamos el valor del heck
                frm.append("idPaginas[]", idpagina.replace("check", ""));//reemplazamos check y solo enviamos el id
            }
        }
        EnviarInformacion("/tipousuario/guardar", frm, false);
    }
}
function eliminar(id) {
    switch (id) {
        case 1:
            alertify.error("El rol administrador no se puede eliminar.");
            break;
        case 2:
            alertify.error("El rol vendedor no se puede eliminar.");
            break;
        default:
            alertify.confirm("¿Seguro deseas eliminar el registro?", function (r) {
                if (r) {
                    eliminarData("/tipousuario/eliminar?id=" + id);
                }
            });
            break;
    }
}
function listarPaginas() {
    $.get("/pagina/listar", function (data) {
        var html = '';
        html += '<table>';
        for (var i = 0; i < data.length; i++) {
            html += '<tr>';
            html += '<td><label>' + data[i].mensaje + '</label></td>';
            html += '<td>';
            html += '<input type="checkbox" class="paginasCheck" id="chk' + data[i].iidpagina + '" value="check' + data[i].iidpagina + '"/>';
            html += '</td>';
            html += '</tr>';
        }
        html += '</table>';
        $("#listadoPaginas").html(html);//pintamos el contenido
        var idUsuario = document.getElementById("iidtipousuario").value;//capturamos el id del usuario para marcar las paginas que tiene asignadas
        if (idUsuario > 0) {//validamos que sea mayor a 0
            marcarPaginasSeleccionadas(idUsuario);
        }
    });
}
function marcarPaginasSeleccionadas(id) {
    $.get("/tipousuario/listarPaginasAsignadas?id=" + id, function (data) {
        for (var i = 0; i < data.length; i++) {
            var idgenerado = 'chk' + data[i].iidpagina;
            document.getElementById(idgenerado).checked = true;//si encuentra un id igual lo marcamos
        }
    });
}