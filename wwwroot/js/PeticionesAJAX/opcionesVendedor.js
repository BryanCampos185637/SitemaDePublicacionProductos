//al cargar la pagina se ejecutara el contador
$(function () {
    contadorNotificaciones();
});
//pintar la tabla
function pintarTabla(url, cabecera, propiedades, llavePrimaria, estadoVenta = "") {
    $.get(url, function (data) {
        var html = "";//con esta pintaremos la tabla
        //inicio tabla
        html += '<table class="table table-dark table-responsive-sm" id="paginar">';
        /*cabecera de la tabla*/
        html += '<thead class="">';
        //pintamos las cabeceras utilizando un for
        html += '<tr>';
        for (var i = 0; i < cabecera.length; i++) {
            html += '<th>' + cabecera[i] + '</th>';
        }
        html += '<th>OPERACIONES</th>';
        html += '</tr>';
        html += '</thead>';
        /*cuerpo de la tabla*/
        html += '<tbody>';
        //pintaremos el cuerpo utilizando dos for
        for (var f = 0; f < data.length; f++) {
            html += '<tr>';
            for (var c = 0; c < propiedades.length; c++) {
                var propiedadActual = propiedades[c];
                var objeto = data[f];
                html += '<td>';
                html += objeto[propiedadActual];
                html += '</td>';
            }
            //la botonera con las cuales podremos editar y eliminar registros
            html += '<td>';
            html += '<button class="badge badge-primary" onclick="editar(' + objeto[llavePrimaria] + ')" data-toggle="modal" data-target="#exampleModal">editar</button> ';
            html += '<button class="badge badge-primary" onclick="eliminar(' + objeto[llavePrimaria] + ')">eliminar</button> ';
            if (estadoVenta != "") {
                if (objeto[estadoVenta] == 1) {
                    html += '<button class="badge badge-success" onclick="cambiarEstado(' + objeto[llavePrimaria] + "," + 1 + ')">en venta</button>';
                } else {
                    html += '<button class="badge badge-danger" onclick="cambiarEstado(' + objeto[llavePrimaria] + "," + 0 + ')">vendido</button>';
                }
            }
            html += '</td>';
            html += '</tr>';
        }
        html += '</tbody>';
        html += '</table>';
        //fin tabla
        //pintamos la tabla
        document.getElementById("domDinamico").innerHTML = html;
        //agregamos el paginado
        $('#paginar').DataTable({
            pageLength: 8,
            lengthMenu: [8, 15, 20, 25]
        });
    });
}
//valida los vacios de la version modal
function validarVaciosModal() {
    document.getElementById("mensajeVaciosModal").innerHTML = "";
    var rpt = true; var inputs = document.getElementsByClassName("requeridoModal");
    for (var i = 0; i < inputs.length; i++) {
        var valorInputActual = inputs[i].value;
        if (valorInputActual.trim() == "") { inputs[i].style.borderColor = "red"; rpt = false; }
        else { inputs[i].style.borderColor = "#ccc"; }
    }
    if (rpt) { document.getElementById("mensajeVaciosModal").innerHTML = "" }
    else { document.getElementById("mensajeVaciosModal").innerHTML = "<span class='text-primary'>Todos los campos son requeridos...</span>"; }
    return rpt;
}
//pintar formulario de registro 
function pintarFormulario() {
    var html = "";
    html += ' <div class="card">'
    html += '    <div class="card-body">'
    html += '<div id="mensajeVacios"></div>'
    html += '        <input type="hidden" id="txtId" class="form-control data" name="Iidproducto" />'
    html += '        <div class="row">'
    html += '            <div class="col-lg-4 col-md-5 col-sm-12">'
    html += '                <div class="form-group">'
    html += '                    <label>Imagen:</label>'
    html += '                    <img src="" class="card-img mb-1 foto" id="foto" style="box-shadow:0px 0px 6px; border-radius:4px; max-height:400px !important;" />'
    html += '                    <input type="file" class="form-control-file" id="fileFoto" onchange="preview()" accept="image/*" />'
    html += '                    <input type="hidden" class="form-control" id="metaDataFoto" />'
    html += '                 </div>'
    html += '            </div>'
    html += '            <div class="col-lg-8 col-md-7 col-sm-12">'
    html += '                <div class="form-group">'
    html += '                    <label>Nombre:</label>'
    html += '                    <input type="text" id="txtNombre" class="form-control requerido data" autocomplete="off" name="Nombre" placeholder="Ingrese el nombre del producto" />'
    html += '                </div>'
    html += '                <div class="form-group">'
    html += '                    <label>Categoria:</label>'
    html += '                    <select id="cbxCategoria" class="form-control requerido data" name="Iidcategoria"></select>'
    html += '                </div>'
    html += '                <div class="form-group">'
    html += '                    <label>Descripcion:</label>'
    html += '                    <textarea id="txtDescripcion" style="resize:none" placeholder="Ingrese una breve descripcion del producto" autocomplete="off" class="form-control requerido data" maxlength="200" name="Descripcion"></textarea>'
    html += '                </div>'
    html += '                <div class="form-group">'
    html += '                    <label>Precio:</label>'
    html += '                    <input type="number" id="txtPrecio" placeholder="Ingrese el precio del producto" autocomplete="off" class="form-control requerido data" min="0" name="Precio" />'
    html += '                </div>'
    html += '                <input type="button" class="btn btn-primary" id="btnEnviar" onclick="enviar(true)" value="Guardar" />'
    html += '            </div>'
    html += '        </div>'
    html += '    </div>'
    html += '</div>'
    document.getElementById("domDinamico").innerHTML = html;//pintamos el formulario en el tag
    llenarCombo("/producto/listarCategorias", document.getElementById("cbxCategoria"), "iidcategoria", "nombre");//llamamos la funcion que llena el select
}
/*nos servira para capturar los datos del modal
 * esta fncion recibe 1parametro
 * el formData*/
function capturarDatosModal(frm) {
    var dataModal = document.getElementsByClassName("dataModal");//capturmos todos inputs que contengan la clase dataModal
    for (var i = 0; i < dataModal.length; i++) {
        frm.append(dataModal[i].name, dataModal[i].value.trim());
    }
}
//la funcion que llama al eliminar este recibe como parametro el id del registro
function eliminar(id) {
    alertify.confirm("Estas seguro de eliminar este registro?", function (e) {//mostramos una alerta
        if (e) {
            eliminarData("/producto/eliminar?id=" + id);//le pasamos la ruta de la accion
        }
    })
}
//funcion que llama a la funcion de pintar tabla
function listar() {
    pintarTabla("/producto/productosPorVendedor", ["ID", "NOMBRE", "PRECIO", "CATEGORIA"], ["id", "nombre", "precio", "nombrecategoria"], "id", "estadoventa");
}
//funcion que cambiara el estado de venta
function cambiarEstado(id, estado) {
    var mensaje = "";
    if (estado == 1) { mensaje = "¿Quieres quitar este producto del catálogo de ventas?" }//SI EL ESTADO DE LA VENTA ES UNO
    else { mensaje = "¿Quieres agregar este producto al catálogo de ventas?" }//SI EL ESTADO DE LA VENTA ES CERO
    alertify.confirm(mensaje, function (e) {//ABRIMOS UNA MODAL DE CONFIRMACION
        if (e) {//SI PRECIONO OK
            $.get("/producto/cambiarEstado?id=" + id, function (r) {
                if (r) {// si la respuesta es un true pintamos de nuevo la tabla
                    listar();
                }
            });
        }
    })
}
//funcion que activan los tres button de la vista opcionesVendedor
function abrirOpcion(opcion) {
    document.getElementById("domDinamico").innerHTML = "<span>Cargando...</span>";
    switch (opcion) {
        case 1:
            //si es uno pintamos el formulario
            pintarFormulario();
            break;
        case 2:
            //si es dos pintamos la tabla productos
            pintarTabla("/producto/productosPorVendedor", ["ID", "NOMBRE", "PRECIO", "CATEGORIA"], ["id", "nombre", "precio", "nombrecategoria"], "id", "estadoventa");
            llenarCombo("/producto/listarCategorias", document.getElementById("cbxCategoriaModal"), "iidcategoria", "nombre");
            break;
        case 3:
            // si es 3 pintamos las notificaciones
            pintarNotificaciones();
            break;
        case 4:
            //si es 4 pintamos el formulario para que pueda editar su informacion
            pintatPerfil();
            break;
    }
}
//funcion que nos servirar para pintar la lista de notificaciones
function pintarNotificaciones() {
    document.getElementById("domDinamico").innerHTML = '<span>Cargando notificaciones...</span>';
    var html = '';
    $.get("/notificacion/listarNotificaciones", function (data) {
        //vamos a validar si hay notificaciones
        if (data.length > 0) {//si es mayor a 0 entonces pintamos las notificaciones
            html+='<ul class="list-group">'
            html += '<li class="list-group-item"><h3>Notificaciones</h3></li>'
            $.each(data, function (key, item) {
                html += '<li class="list-group-item">'
                if (item.notificacionleida == 0) {
                    html += '<span>Se a eliminado tu producto ' + item.nombreproducto + ' porque infringe las politicas de compratodo.com <a href="#" class="badge badge-primary" onclick="detalleNotificacion(' + item.id + ')" data-toggle="modal" data-target="#modalNotificacion">ver detalles</a></span>'
                } else {
                    html += '<span>Se a eliminado tu producto ' + item.nombreproducto + ' porque infringe las politicas de compratodo.com <a href="#" class="badge badge-success" onclick="detalleNotificacion(' + item.id + ')" data-toggle="modal" data-target="#modalNotificacion">leido</a></span>'
                }
                html += '</li>'
            })
            html +='</ul>'
            document.getElementById("domDinamico").innerHTML = html;//pintamos el formulario en el tag
        } else{
            //si no hay entonces mostramos un mensaje
            document.getElementById("domDinamico").innerHTML = '<span>No hay notificaciones...</span>';
        }
    });
}
//preview de la foto del formulario de agregar
function preview() {
    var archivo = document.getElementById("fileFoto").files[0];//tomo la foto que seleccione
    var reader = new FileReader();
    reader.onload = function () {
        document.getElementById("foto").src = reader.result;
        document.getElementById("metaDataFoto").value = reader.result;
    }
    reader.readAsDataURL(archivo);
}
//preview de la foto modal modificar
var metadatafoto;
var fileFotoModal = document.getElementById("fileFotoModal");
fileFotoModal.onchange = function () {
    var archivo2 = document.getElementById("fileFotoModal").files[0];//tomo la foto que seleccione
    var reader = new FileReader();
    reader.onload = function () {
        document.getElementById("fotoModal").src = reader.result;
        document.getElementById("metaDataFotoModal").value = reader.result;
        metadatafoto = reader.result;
    }
    reader.readAsDataURL(archivo2);
}
//funcion que llama la data del registro
function editar(id) {
    $.get("/producto/obtenerPorId?id=" + id, function (data) {
        $("#txtIdModal").val(data.iidproducto);
        $("#txtNombreModal").val(data.nombre);
        $("#txtDescripcionModal").val(data.descripcion);
        $("#txtPrecioModal").val(data.precio);
        $("#cbxCategoriaModal").val(data.iidcategoria);
        document.getElementById("metaDataFotoModal").value = data.foto;
        document.getElementById("fotoModal").src = "/foto_producto/" + data.foto;
    })
    colorDefault();
}
/*funcion que envia la data al controlador recibe un bool para saber si se esta enviando desde
 * el formulario de agregar o el modal de editar*/
function enviar(isView) {
    if (isView) {// si es true es porque viene de la vista de agregar
        if (validarVacios()) {
            if (($("#txtPrecio").val() * 1) <= 0) {//validamos que el precio no este en valor de 0
                document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>El precio no es valido...</span>";
                document.getElementById("txtPrecio").style.borderColor = "red";
                hacerScrollHaciaArriba();
            } else {//si el precio es mayor a 0
                var foto = document.getElementById("metaDataFoto").value;//capturamos el valor que esta en el input oculto este contiene la metadata de la foto
                if (foto == "" || foto == null) {//si es null o vacio enviamos un mensaje para que agregue una foto
                    document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>Tienes que agregar una foto del producto...</span>";
                    hacerScrollHaciaArriba();
                } else {//si ya hay una foto procedemos
                    var frm = new FormData();//hacemos una instancia del formData
                    capturarDatos(frm);//hacemos uso de la funcion que captura datos de aquellos tag que contengan la clase 'data'
                    frm.append("Foto", document.getElementById("foto").src);//almacenamos la metadata de la foto
                    var fotoinput = ($("#fileFoto"))[0].files[0];//foto del file 
                    frm.append("archivo", fotoinput);
                    EnviarInfo("/producto/guardar", frm, true);//y enviamos la data con la funcion generica
                }
            }
        }
    } else {//si viene del modal aplica la misma data del agregar
        if (validarVaciosModal()) {
            if (($("#txtPrecioModal").val() * 1) <= 0) {
                document.getElementById("mensajeVaciosModal").innerHTML = "<span class='text-primary'>El precio no es valido...</span>";
                document.getElementById("txtPrecioModal").style.borderColor = "red";
                hacerScrollHaciaArriba();
            } else {
                var foto = document.getElementById("metaDataFotoModal").value;
                if (foto == "" || foto == null) {
                    document.getElementById("mensajeVaciosModal").innerHTML = "<span class='text-primary'>Tienes que agregar una foto del producto...</span>";
                    hacerScrollHaciaArriba();
                } else {
                    var frm = new FormData();
                    capturarDatosModal(frm);
                    frm.append("Foto", $("#metaDataFotoModal").val());
                    var fotoinput = ($("#fileFotoModal"))[0].files[0];//foto del file 
                    frm.append("archivo", fotoinput);
                    EnviarInfo("/producto/guardar", frm, false);
                }
            }
        }
    }
}
//funcion que nos sirve para mostrarle al usuario si tiene notificaciones nuevas
function contadorNotificaciones(){
    $.get("/notificacion/numeroNotificacionesNuevas", function (r) {
        if (r > 0) {
            if (r == 1) {
                var mensaje = r + " notificación nueva";
                $("#btnNotificaciones").val(mensaje);
            }//para mostrar mensajes
            else {
                var mensaje = r + " notificaciones nuevas";
                $("#btnNotificaciones").val(mensaje);
            }
        } else {
            $("#btnNotificaciones").val("Notificaciones");
        }
    })
}
//ESTO NOS TRAE LOS DETALLES DE LA NOTIFICACION
function detalleNotificacion(id) {
    var html = "";
    $.get("/notificacion/detalle?id=" + id, function (data) {
        html += '<h3>Hola ' + data.nombrevendedor + '</h3>';
        html += '<hr />';
        html += '<span>Se elimino el producto ' + data.nombreproducto + ' con la descripción ' + data.descripcion + ' por el siguiente motivo: <strong>' + data.motivo + '.</strong>';
        html += ' Te advertimos que si continúas infringiendo las políticas nos veremos en la penosa decisión de bloquear tu cuenta.';
        html += '</span>';
        html += '<br />';
        html += '<span>Atentamente: Compratodo.com</span>';
        //document.getElementById("mensajeNotificacion").innerHTML = html;
        document.getElementById("mensajeNotificacion").innerHTML = html;//pintamos el formulario en el tag
        //elecutamos la funcion mensaje leido
        mensajeLeido(data.id);
    });
}
//function marca como leido el mensaje
function mensajeLeido(id) {
    $.get("/notificacion/marcarComoLeido?id=" + id, function (r) {
        if (r) {
            pintarNotificaciones();//para que cambie el estado del boton
            contadorNotificaciones();//llamamos para que se haga de nuevo el conteo de notificacioes
        }
    })
}
//funcion para pintar el perfil del usuario
function pintatPerfil(id = 0) {
    document.getElementById("domDinamico").innerHTML = "<span>Cargando...</span>";
    var html = '<div class="col-lg-12">';
    html += '<div class="card formulario">';
    html += '<div class="card-body">';
    html += '<h3 id="tituloEdicion">Perfil</h3>';
    html += '<div id="mensajeVacios"><span class="text-primary">Para confirmar cambios debes ingresar tu contraseña actual.</span></div>';
    html += '<div class="row">';
    html += '<div class="col-lg-6">';
    html += '<div class="form-group">';
    html += '<input type="hidden" class="data"  name="Iidvendedor" id="iidvendedor">';
    html += '<label>Nombres[editar]:</label>';
    html += '<input type="text" autocomplete="off" placeholder="Ingrese sus nombres" id="txtNombre" class="form-control requerido data" name="Nombre" />';
    html += '</div>';
    html += '<div class="form-group">';
    html += '<label>Apellidos[editar]:</label>';
    html += '<input type="text" autocomplete="off" placeholder="Ingrese sus apellidos"  id="txtApellido" class="form-control requerido data" name="Apellidos" />';
    html += '</div>';
    html += '<div class="form-group">';
    html += '<label>Correo gmail:</label>';
    html += '<input type="email" placeholder="Ingrese un correo" readonly  class="form-control requerido data" name="Correo" id="correoGmail" required />';
    html += '</div>';
    html += '</div>';
    html += '<div class="col-lg-6">';
    html += '<div class="form-group">';
    html += '<label>Telefono celular[editar]:</label>';
    html += '<input type="number" autocomplete="off" id="txtTel" placeholder="Ingrese su telefono celular" maxlength="8" class="form-control requerido data" name="Telefonocelular" />';
    html += '</div>';
    html += '<div class="form-group">';
    html += '<label>Contraseña nueva[editar]:</label>';
    html += '<input type="password" placeholder="Ingrese contraseña nueva" class="form-control data" name="Contraseña" />';
    html += '</div>';
    html += '<div class="form-group">';
    html += '<label>Confirmar cambios:</label>';
    html += '<input type="password" placeholder="Ingrese contraseña actual para confirmar cambios" id="txtContra" class="form-control requerido"  />';
    html += '</div>';
    html += '</div>';
    html += '<div class="col-lg-12">';
    html += '<input type="button" onclick="modificarPerfil()" value="Modificar" class="btn btn-primary" id="btnRegistrar" />';
    html += '</div>';
    html += '</div>';
    html += '</div>';
    html += '</div>';
    html += '</div>';
    document.getElementById("domDinamico").innerHTML = html;//pintamos el formulario en el tag
    //una vez pintado el formulario le añadimos la respectiva informacion
    $.get("/vendedor/perfil?id=" + id, function (data) {
        $("#tituloEdicion").html("Perfil de " + data.nombreusuario);
        $("#iidvendedor").val(data.iidvendedor);
        $("#txtNombre").val(data.nombre);
        $("#txtApellido").val(data.apellidos);
        $("#correoGmail").val(data.correo);
        $("#txtTel").val(data.telefonocelular);
    });
}
//funcion para modificar perfil
function modificarPerfil() {
    if (validarVacios()) {
        if (verificarCorreo()) {
            document.getElementById("correoGmail").style.borderColor = "#ccc";
            document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>Cargando...</span>"
            var txtContra = document.getElementById("txtContra").value;
            var txtTel = document.getElementById("txtTel").value;
            if (txtContra.length >= 5) {//validamps el tamaño de la contra
                document.getElementById("txtContra").style.borderColor = "#ccc";
                if (txtTel.length == 8) {//validamos telefono
                    document.getElementById("txtTel").style.borderColor = "#ccc";
                    var frm = new FormData();
                    capturarDatos(frm);
                    frm.append("contraseñaActual", $("#txtContra").val());
                    $.ajax({
                        url: "/Vendedor/modificarPerfil",
                        type: "POST",
                        contentType: false,
                        processData: false,
                        data: frm,
                        success: function (r) {
                            if (r > 0) {
                                pintatPerfil($("#iidvendedor").val());
                                alertify.success("Perfil modificado");
                            }
                            else if (r == -1) {
                                document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>Contraseña incorrecta...</span>";
                                hacerScrollHaciaArriba();
                            } else {
                                document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>Error en el sistema intente más tarde...</span>";
                                hacerScrollHaciaArriba();
                            }
                        }
                    })
                } else {
                    document.getElementById("txtTel").style.borderColor = "red";
                    document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>El teléfono debe contener 8 dígitos [00000000].</span>";
                    hacerScrollHaciaArriba();
                }
            } else {
                document.getElementById("txtContra").style.borderColor = "red";
                document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>La contraseña debe contener al menos 5 caracteres.</span>";
                hacerScrollHaciaArriba();
            }
        } else {
            document.getElementById("correoGmail").style.borderColor = "red";
            document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>El correo tiene que ser de Gmail.</span>";
            hacerScrollHaciaArriba();
        }
    }
}
//verificamos que el correo sea gmail
function verificarCorreo() {
    var correo = document.getElementById("correoGmail").value;//capturamos la info del input
    var terminacion = "@gmail.com";//el formato que vamos a verificar que contenga
    var index = correo.indexOf(terminacion);//usamos indexof para que nos devuelva las coordenadas
    if (index > 0) {//si existe ese formato 
        return true;
    } else {//si no existe
        return false;
    }
}
//enviar informacion al controlador
function EnviarInfo(ruta, frm, esModal) {
    /* envia la data al controlador
    * esta fncion recibe 3 parametros la ruta de la accion,
    * la data que se captura de la vista y
    * si la funcion se llama en la modal o la vista de agregar
    */
    $.ajax({
        url: ruta,
        type: "POST",
        processData: false,
        contentType: false,
        data: frm,
        success: function (respuesta) {
            if (respuesta > 0) {
                if (esModal == false) {
                    listar();
                } else {
                    pintarFormulario();
                    document.getElementById("btnCerrarModal").click();
                }
                alertify.success("Exito");
                limpiar();
            } else if (respuesta == -1) {
                document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>Este registro ya existe en la base de datos...</span>";
                hacerScrollHaciaArriba();
            } else {
                alertify.error("Error en el sistema");
                hacerScrollHaciaArriba();
            }
        }
    })
}