var btnSubir = document.getElementById("btnSubir");
btnSubir.onclick = function () {
    $("body,html").animate({
        scrollTop: "0px"
    });
}

$(function () {
    pintarCards("/producto/listar");//agrega las cards

    $(window).scroll(function () {//pinta el boton de subir si se a dado scroll
        if ($(this).scrollTop() > 0) {
            document.getElementById("btnSubir").style.display = "block";
        } else {
            document.getElementById("btnSubir").style.display = "none";
        }
    });
})

//funcion para filtrar por nombre
var nresultados;
var txtBuscarProducto = document.getElementById("txtBuscarProducto");
txtBuscarProducto.onkeyup = function () {
    var parametroBusqueda = document.getElementById("txtBuscarProducto").value;
    pintarCards("/producto/listar?nombre=" + parametroBusqueda);
}

//pinta las cards
function pintarCards(ruta) {
    $.get(ruta, function (data) {
        var html = "";
        var idSesion = document.getElementById("idSesion").value;
        if (data == null || data == "" || data.length <= 0) {
            html += '<div class="col-lg-12">';
            html += '<span class="text-danger">Lo sentimos no hay resultados...</span>';
            html += '</div>';
            document.getElementById("cartas").innerHTML = html;
        } else {
            $.each(data, function (key, item) {
                html += '<div class="mb-2 col-sm-12 col-lg-4 col-md-6">';
                html += '<div class="card">';
                html += '<div class="card-header text-center"><h4>' + item.nombre + '</h4></div >';
                html += '<div class="card-body">';
                html += '<img src="' + item.foto + '" style="box-shadow:0px 0px 6px; border-radius:4px; height: 315px;" class="card-img mb-1" />';
                html += '<span>' + item.descripcion + '</span>';
                html += '</div>';
                html += '<div class="card-footer">';
                html += '<span>Categoria: ' + item.nombrecategoria + '</span></br>';
                html += '<span>Precio: $' + item.precio + '</span></br>';
                html += '<span>Vendedor: ' + item.nombreusuario + '</span></br>';
                html += '<span>Telefono: ' + item.tel + '</span></br>';
                html += '<span>Correo: ' + item.correo + '</span> ';
                if (idSesion != 0) {
                    if (idSesion == item.idvendedor) {
                        html += '<button id="btnReportar" onclick="eliminarProducto(' + item.id + ')" class="badge badge-danger">eliminar</button>'
                        } else {
                        html += '<button id="btnReportar" onclick="capturarProducto(' + item.id + ')" class="badge badge-primary" data-toggle="modal" data-target="#modalReporte">denunciar</button>'
                    }
                }
                html += '</div>';
                html += '</div>';
                html += '</div>';
                document.getElementById("cartas").innerHTML = html;
            })
        }
    });
}
//limpia las busquedas y lo que esta escrito en el input de filtro
function limpiarBusqueda() {
    pintarCards("/producto/listar");
    document.getElementById("txtBuscarProducto").value = "";
}

//funcion para gregar una denunca
function denunciarPublicacion() {
    var motivo = document.getElementById("cbxMotivo").value;//capturamos el texto del motivo
    var tagMensaje = document.getElementById("mensajeError");//capturamos el tag donde se escriben mensajes de notificacion
    var contenidoDenuncia = document.getElementById("contenidoDenuncia");//tag para modificar el contenido del modal
    if (motivo == "") {//si no a escojido ninguna opcion se pinta el siguiente mensaje
        tagMensaje.innerHTML = "<span class='text-danger'>Selecciona un motivo por favor.</span>";
    } else {//una vez escojido el motivo
        var frm = new FormData();//procedemos a capturar la informacion
        frm.append("Motivo", motivo);
        frm.append("Iidproducto", document.getElementById("idPublicacion").value);
        contenidoDenuncia.innerHTML = "<span class='text-primary'>Cargando...</span>";
        $.ajax({//se hace la peticion al controlador
            url: "/Denuncia/guardar",
            type: "POST",
            processData: false,
            contentType: false,
            data: frm,
            success: function (r) {
                if (r > 0) {//si el resultado es positivo se le notifica el usuario
                    contenidoDenuncia.innerHTML = "<span class='text-primary'>Gracias por enviar la denuncia, revisaremos tu reporte y tomaremos una decision.</span>";
                    document.getElementById("btnEnviarReporte").style.display = "none";
                    document.getElementById("btnCerrarModal").value = "Cerrar";
                } else {//si la peticion develve un error se le pide al usuario que lo intente mas tarde
                    contenidoDenuncia.innerHTML = "<span class='text-danger'>Error, disculpa los inconvenientes intentalo mas tarde.</span>";
                    document.getElementById("btnEnviarReporte").style.display = "none";
                    document.getElementById("btnCerrarModal").value = "Cerrar";
                }
            }
        })
    }
}

//captura el id del producto y pintamos el formulario
function capturarProducto(id) {
    var html = "";
    html+='<div class="text-center">';
    html+='<span>Ayudanos a entender cual es el motivo de tu denuncia. ¿Como lo describirias?</span>'
    html +='</div>'
    html +='<input type="hidden" id="idPublicacion" />'
    html +='<select id="cbxMotivo" class="form-control">'
    html +='<option value="">--selecciona un motivo--</option>'
    html +='<option value="Engañoso o fraude">Engañoso o fraude</option>'
    html +='<option value="Contenido sexual inapropiado">Contenido sexual inapropiado</option>'
    html +='<option value="Ofensivo">Ofensivo</option>'
    html +='<option value="Contenido prohibido">Contenido prohibido</option>'
    html +='</select>'
    html += '<div id="mensajeError"></div>';
    document.getElementById("contenidoDenuncia").innerHTML = html;
    document.getElementById("idPublicacion").value = id;//añadimos el id de la publicacion en el input oculto
    //habilitamos los botones
    document.getElementById("btnEnviarReporte").style.display = "block";
    document.getElementById("btnCerrarModal").value = "Cancelar";
}
function eliminarProducto(id) {
    alertify.confirm("¿Quieres eliminar tu producto?", function (e) {
        if (e) {
            $.get("/producto/eliminar?id=" + id, function (r) {
                if (r) {
                    limpiarBusqueda();
                }
            })
        }
    })
}