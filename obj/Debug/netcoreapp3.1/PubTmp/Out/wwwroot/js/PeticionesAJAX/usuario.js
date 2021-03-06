﻿$(function () {
    listar();
});
function listar() {
    crearTablaUsuario("/usuario/listarUsuarios", ["nombre", "apellidos", "usuario", "correo", "nombretipousuario"],
        "id", ["NOMBRE", "APELLIDO", "USUARIO", "CORREO", "ROL"], document.getElementById("domDinamico"));
    llenarCombo("/tipousuario/listar", document.getElementById("cbxTipoUsuario"), "iidtipousuario", "nombre");
}
function crearTablaUsuario(url, propiedades, llaveprimaria, encabezados, control) {
    var html = '';
    $.get(url, function (data) {
        html += '<table id="tablaDinamica" class="table table-responsive-sm">'
        html += '<thead class="thead-dark">'
        html += '<tr>'
        for (var i = 0; i < encabezados.length; i++) {
            html += '<th>' + encabezados[i] + '</th>'
        }
        html += '<th>OPERACIONES</th>'
        html += '</tr>'
        html += '</thead>'
        html += '<tbody>'
        for (var fila = 0; fila < data.length; fila++) {
            html += '<tr>'
            var dataActual = data[fila];
            for (var columna = 0; columna < propiedades.length; columna++) {
                var propiedadActual = propiedades[columna];
                html += '<td>' + dataActual[propiedadActual] + '</td>'
            }
            html += '<td>'
            html += '<button class="badge badge-primary" onclick="detalle(' + dataActual[llaveprimaria] + ')" data-toggle="modal" data-target="#exampleModal">cambiar rol</button> '
            if (data[fila].bhabilitado == 1) {
                html += '<button class="badge badge-success" onclick="vetar(' + dataActual[llaveprimaria] + ')">vetar</button>'
            } else if (data[fila].bhabilitado == 2) {
                html += '<button class="badge badge-danger" onclick="vetar(' + dataActual[llaveprimaria] + ')">activar</button>'
            }
            html += '</td>'
            html += '</tr>'
        }
        html += '</tbody>'
        html += '</table>'
        control.innerHTML = html;
        $('#tablaDinamica').DataTable({
            pageLength: 8,
            lengthMenu: [8, 15, 20, 25]
        });
    })
}
function vetar(id) {
    $.get("/vendedor/vetarVendedor?id=" + id, function (r) {
        if (r) {
            listar();
        } else {
            document.getElementById("mensajeVacios").innerHTML = '<span class="text-primary">Error:intentalo mas tarde</span>';
        }
    })
}
function detalle(id) {
    $.get("/usuario/obtenerPorId?id=" + id, function (data) {
        $("#txtId").val(data.iidvendedor);
        $("#txtNombre").val(data.nombre);
        $("#txtNombreUsuario").val(data.nombreusuario);
        $("#txtCorreo").val(data.correo);
        $("#cbxTipoUsuario").val(data.iidtipousuario);
        $("#txtApellido").val(data.apellidos);
    })
}
function cambiarRol() {
    var frm = new FormData();
    frm.append("Iidvendedor", $("#txtId").val());
    frm.append("Iidtipousuario", $("#cbxTipoUsuario").val());
    frm.append("Nombre", $("#txtNombre").val());
    frm.append("Apellidos", $("#txtApellido").val());
    frm.append("Correo", $("#txtCorreo").val());
    frm.append("Nombreusuario", $("#txtNombreUsuario").val());
    $.ajax({
        url: "/usuario/modificar",
        type: "POST",
        contentType: false,
        processData: false,
        data: frm,
        success: function (r) {
            if (r > 0) {
                alertify.success("Exito");
                limpiar();
                $("#btnCerrar").click();
                listar();
            } else {
                alertify.error("Error en el sistema");
            }
        }
    })
}