
$(function () {
    listar();
})
function listar() {
    pintarTabla(document.getElementById("tablaDenuncias"), ["denuncias", "motivo", "nombreproducto", "nombrevendedor"],
        ["VECES DENUNCIADO", "MOTIVO", "PRODUCTO", "VENDEDOR"], "id", "idproducto", "idvendedor", "/denuncia/listar");
}
function pintarTabla(control, propiedades, cabecera, primaria, idproducto, idvendedor, ruta) {
    $.get(ruta, function (data) {
        var html = "";
        html += '<table id="tabla" class="table table-dark table-responsive-sm">';
        //cabecera
        html += '<thead class="thead-dark">';
        html += '<tr>';
        for (var i = 0; i < cabecera.length; i++) {
            html += '<th>' + cabecera[i] + '</th>';
        }
        html += '<th class="text-center">OPERACIONES</th>';
        html += '</tr>';
        html += '</thead>';
        html += '<tbody>';
        for (var d = 0; d < data.length; d++) {
            html += '<tr>';
            for (var p = 0; p < propiedades.length; p++) {
                var dataActual = data[d];
                var propiedadActual = propiedades[p];
                html += '<td>';
                html += dataActual[propiedadActual];
                html += '</td>';
            }
            html += '<td>';
            html += '<a href="#" class="badge badge-primary" onclick="obtenerInformacion(true,' + dataActual[idproducto] + ')" data-toggle="modal" data-target="#exampleModal">ver producto</a> ';
            html += '<a href="#" class="badge badge-primary" onclick="obtenerInformacion(false,' + dataActual[idvendedor] + ')" data-toggle="modal" data-target="#exampleModal">ver vendedor</a> ';
            if (data[d].bhabilitadop == 1) {
                html += '<a href="#" class="badge badge-success" onclick="vetar(true,' + dataActual[idproducto] + ')">vetar producto</a> ';
            } else if (data[d].bhabilitadop==2){
                html += '<a href="#" class="badge badge-danger" onclick="vetar(true,' + dataActual[idproducto] + ')">activar producto</a> ';
            }
            if (data[d].bhabilitadov == 1) {
                html += '<a href="#" class="badge badge-success" onclick="vetar(false,' + dataActual[idvendedor] + ')">vetar vendedor</a>';
            } else if (data[d].bhabilitadov == 2) {
                html += '<a href="#" class="badge badge-danger" onclick="vetar(false,' + dataActual[idvendedor] + ')">activar vendedor</a>';
            } else {
                html += '<span href="#" class="badge badge-primary">vendedor eliminado</span>';
            }
            html += '</td>';
            html += '</tr>';
        }
        html += '</tbody>';
        html += '</table>';
        //pintamos la tabla
        control.innerHTML = html;
        //agregamos el paginado
        $('#tabla').DataTable({
            pageLength: 8,
            lengthMenu: [8, 15, 20, 25]
        });
    });
}
function obtenerInformacion(esProducto = true, id) {
    var html="";
    if (esProducto) {//si se quiere ver el producto 
        $.get("/Producto/obtenerPorId?id=" + id, function (data) {
            //creamos el formulario para visualizar el producto
            html += '<!--contenido-->'
            html += '<div class="modal-body">';
            html +='<div class="row">'
            html +='<div class="col-lg-4">'
            html +='<div id="mensajeVacios"></div>'
            html +='<div class="form-group">'
            html +='<label>Imagen:</label>'
            html +='<img src="'+data.foto+'" class="card-img mb-1 foto" id="fotoModal" style="box-shadow:0px 0px 6px; border-radius:4px; max-height:355px !important;" />'
            html +='</div>'
            html +='</div>'
            html +='<div class="col-lg-8">'
            html +='<div class="form-group">'
            html +='<label>Nombre:</label>'
            html +='<input type="text" readonly id="txtNombreModal" value="'+data.nombre+'" class="form-control requeridoModal dataModal" autocomplete="off" name="NOMBRE" placeholder="Ingrese el nombre del producto" />'
            html +='</div>'
            html +='<div class="form-group">'
            html +='<label>Descripcion:</label>'
            html += '<input type="text" readonly value="' + data.descripcion +'" class="form-control"/>'
            html +='</div>'
            html +='<div class="form-group">'
            html +='<label>Precio:</label>'
            html +='<input type="number" readonly value="'+data.precio+'" id="txtPrecioModal" placeholder="Ingrese el precio del producto" autocomplete="off" class="form-control requeridoModal dataModal" min="0" name="PRECIO" />'
            html +='</div>'
            html +='</div>'
            html +='</div>'
            html +='</div>'
            html +='<!--footer-->'
            html +='<div class="modal-footer">'
            html += '<button type="button" class="btn btn-danger" data-dismiss="modal" id="btnCerrarModal">Cerrar</button>'
            if (data.bhabilitado == 1) {
                html += '<input type="button" class="btn btn-success" id="btnEnviar" onclick="vetar(true,' + data.iidproducto + ')" value="Vetar producto" />'
            } else if (data.bhabilitado == 2){
                html += '<input type="button" class="btn btn-danger" id="btnEnviar" onclick="vetar(true,' + data.iidproducto + ')" value="Activar producto" />'
            }
            
            html += '</div>'
            //pintamos el contenido
            document.getElementById("contenimoModalDinamico").innerHTML = html;
        })
    } else {//si quiere ver el vendedor
        $.get("/vendedor/perfil?id=" + id, function (data) {
                //creamos el formulario para visualizar el vendedor
                html += '<!--contenido-->'
                html += '<div class="modal-body">';
                html += '<div class="row">'
                html += '<div class="col-lg-12">'
                html += '<div id="mensajeVacios"></div>'
                html += '<div class="form-group">'
                html += '<label>Nombre usuario:</label>'
                html += '<input type="text" readonly value="' + data.nombreusuario + '" class="form-control requeridoModal dataModal" autocomplete="off" name="NOMBRE" placeholder="Ingrese el nombre del producto" />'
                html += '</div>'
                html += '<div class="form-group">'
                html += '<label>Nombre:</label>'
                html += '<input type="text" readonly value="' + data.nombre + '" class="form-control requeridoModal dataModal" autocomplete="off" name="NOMBRE" placeholder="Ingrese el nombre del producto" />'
                html += '</div>'
                html += '<div class="form-group">'
                html += '<label>Apellidos:</label>'
                html += '<input type="text" readonly value="' + data.apellidos + '" class="form-control"/>'
                html += '</div>'
                html += '<div class="form-group">'
                html += '<label>Telefono:</label>'
                html += '<input type="number" readonly value="' + data.telefonocelular + '" id="txtPrecioModal" autocomplete="off" class="form-control requeridoModal dataModal" min="0" name="PRECIO" />'
                html += '</div>'
                html += '</div>'
                html += '</div>'
                html += '</div>'
                html += '<!--footer-->'
                html += '<div class="modal-footer">'
                html += '<button type="button" class="btn btn-danger" data-dismiss="modal" id="btnCerrarModal">Cerrar</button>'
                if (data.bhabilitado == 1) {
                    html += '<input type="button" class="btn btn-success" id="btnEnviar" onclick="vetar(false,' + data.iidvendedor + ')" value="Vetar vendedor" />'
                } else if (data.bhabilitado == 2) {
                    html += '<input type="button" class="btn btn-danger" id="btnEnviar" onclick="vetar(false,' + data.iidvendedor + ')" value="Activar vendedor" />'
                }
                html += '</div>'
                //pintamos el contenido
                document.getElementById("contenimoModalDinamico").innerHTML = html;
        });
    }
}
//funcion para vetar producto o vendedor
function vetar(itsProducto, id) {
    alertify.confirm("Estas seguro de proseguir con la accion?", function (e) {
        if (e) {
            if (itsProducto) {// si es un producto
                $.get("/producto/vetarProducto?id=" + id, function (r) {
                    if (r) {
                        listar();
                    } else {
                        document.getElementById("mensajeVacios").innerHTML = '<span class="text-danger">Error:intentalo mas tarde</span>';
                    }
                })
            } else {
                $.get("/vendedor/vetarVendedor?id=" + id, function (r) {
                    if (r) {
                        listar();
                    } else {
                        document.getElementById("mensajeVacios").innerHTML = '<span class="text-danger">Error:intentalo mas tarde</span>';
                    }
                })
            }
        }
    });
    document.getElementById("btnCerrarModal").click();
}