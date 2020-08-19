var idCategoria = 0;
$(function () {
    document.getElementById("seccionFiltro").style.display = "none";
    pintarMenuCategoria();
    $(window).scroll(function () {//pinta el boton de subir si se a dado scroll
        if ($(this).scrollTop() > 0) {
            document.getElementById("btnSubir").style.display = "block";
        } else {
            document.getElementById("btnSubir").style.display = "none";
        }
    });
});
function pintarMenuCategoria() {
    var html = '';
    $.get("/menu/listarCategorias", function (data) {
        for (var i = 0; i < data.length; i++) {
            html += '<div class="col-sm-6 col-lg-4 col-md-6 mb-3">';
            html += '<div class="card">';
            html += '<div class="card-header">';
            html += '<h3>' + data[i].nombre + '</h3>';
            html += '</div>';
            html += '<div class="card-body">';
            html += '<span>' + data[i].descripcion + '</span>';
            html += '</div>';
            html += '<div class="card-footer">';
            html += '<a class="badge badge-primary" href="#" onclick="pintarCardsSegunIdCategoria(' + data[i].iidcategoria + ')">Ir a ' + data[i].nombre + '</a>';
            html += '</div>';
            html += '</div>';
            html += '</div>';
        }
        document.getElementById("menu").innerHTML = html;
    })
}
function pintarCardsSegunIdCategoria(idCate, nombre = "") {
    document.getElementById("menu").innerHTML = '<span class="text-primary">Cargando...</span>';
    document.getElementById("seccionFiltro").style.display = "block";
    idCategoria = idCate;
    $.get("/menu/PintarProductoSegunCategoria?idCategoria=" + idCategoria + "&nombre=" + nombre, function (data) {
        var html = "";
        var idSesion = document.getElementById("idSesion").value;
        if (data == null || data == "" || data.length <= 0) {
            html += '<div class="col-lg-12">';
            html += '<span class="text-primary">Lo sentimos no hay resultados...</span>';
            html += '</div>';
            document.getElementById("menu").innerHTML = html;
        } else {
            $.each(data, function (key, item) {
                html += '<div class="mb-2 col-sm-12 col-lg-4 col-md-6">';
                html += '<div class="card">';
                html += '<div class="card-header text-center"><h4>' + item.nombre + '</h4></div >';
                html += '<div class="card-body">';
                //html += '<img src="/foto_producto/' + item.foto + '" style="box-shadow:0px 0px 6px; border-radius:4px; height: 315px;" class="card-img mb-1" />';
                html += '<img style="height: 40vh !important; object-fit: cover !important;" src="/foto_producto/' + item.foto + '" class="card-img mb-1 card-catalogo" onclick="maximizar(' + item.id + ')" data-toggle="modal" data-target="#verImagen"/>';
                html += '<span>' + item.descripcion + '</span>';
                html += '</div>';
                html += '<div class="card-footer">';
                html += '<span>Categoria: ' + item.nombrecategoria + '</span></br>';
                html += '<span>Precio: $' + item.precio + '</span></br>';
                html += '<span>Vendedor: ' + item.nombreusuario + '</span></br>';
                html += '<span>Telefono: ' + item.tel + '</span></br>';
                html += '<span>Correo: ' + item.correo + '</span></br>';
                if (idSesion != 0) {
                    if (idSesion == item.idvendedor) {
                        html += '<button id="btnReportar" onclick="eliminarProducto(' + item.id + ')" class="badge badge-primary">eliminar</button> ';
                        html += '<button id="btnReportar" onclick="quitarDeCatalogo(' + item.id + ')" class="badge badge-primary">quitar</button>';
                    } else {
                        html += '<button id="btnReportar" onclick="capturarProducto(' + item.id + ')" class="badge badge-primary" data-toggle="modal" data-target="#modalReporte">denunciar</button>'
                    }
                }
                html += '</div>';
                html += '</div>';
                html += '</div>';
                document.getElementById("menu").innerHTML = html;
            })
        }
    });
}
//hacer scroll
var btnSubir = document.getElementById("btnSubir");
btnSubir.onclick = function () {
    $("body,html").animate({
        scrollTop: "0px"
    });
}

//funcion para filtrar por nombre
var nresultados;
var txtBuscarProducto = document.getElementById("txtBuscarProducto");
txtBuscarProducto.onkeyup = function () {
    var parametroBusqueda = document.getElementById("txtBuscarProducto").value;
    if (parametroBusqueda != "") {//hasta que la palabra contenga 3 letras se ejecutara
        pintarCardsSegunIdCategoria(idCategoria, parametroBusqueda)
    } else {//muestra los datos
        pintarCards(idCategoria);//agrega las cards
    }
}
function limpiarBusqueda() {
    pintarCards(idCategoria);//agrega las cards
    document.getElementById("txtBuscarProducto").value = "";
}