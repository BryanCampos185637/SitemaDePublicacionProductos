window.onload = function () {
    GenerarMenu();
}
function GenerarMenu() {
    $.get("/pagina/generarMenu", function (data) {
        var html = '';
        html += '<a class="list-group-item list-group-item-action text-light" href="/home/index">Inicio</a>';
        if (data != null && data.length != 0) {
            $.each(data, function (key, item) {
                html += '<a class="list-group-item list-group-item-action text-light" href="/' + item.controlador + '/' + item.accion + '">' + item.mensaje + '</a>'
            })
            html += '<a class="list-group-item list-group-item-action text-light" href="/vendedor/cerrarSesion">Cerrar sesion</a>';
            $("#menuDinamico").html(html);
        }
    })
}