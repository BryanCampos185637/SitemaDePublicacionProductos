function validarVacios() {
    /*funcion para validas que en los formularios
     el usuario no deje espacios vacios
     */
    document.getElementById("mensajeVacios").innerHTML = "";//vaciamos lo que tenga el tag
    var rpt = true; var inputs = document.getElementsByClassName("requerido");//capturmos todos los inputs que contrngan la clase requerido
    for (var i = 0; i < inputs.length; i++) {
    /*validamos que el value no este vacio y si lo esta pasamos la variable a false y le cambiamos el contorno a rojo*/
        var valorInputActual = inputs[i].value;
        //usamos trim para quitar los espacios vacios ya que una pinche tester me hizo ver que estaba mal
        if (valorInputActual.trim() == "") { inputs[i].style.borderColor = "red"; rpt = false; }
        else { inputs[i].style.borderColor = "#ccc"; }//si no esta vacio ponemos el color al estado inicial
    }
    if (rpt) { document.getElementById("mensajeVacios").innerHTML = "" }//si la respuesta es true entonces limpiamos el tag
    else { document.getElementById("mensajeVacios").innerHTML = "<span class='text-danger'>Todos los campos son requeridos...</span>"; }//si esta false pintamos un mensaje
    return rpt;
}

function capturarDatos(frm) {
    //captura la informacionde los inputs que contiene la clase data
    var dataVista = document.getElementsByClassName("data");//recoje todos los que tengan la clase data
    for (var i = 0; i < dataVista.length; i++) {//itera todos los inputs
        frm.append(dataVista[i].name, dataVista[i].value.trim());// y forma el arreglo
    }
}

function colorDefault() {
    //vuelve los inputs a su color original
    var inputs = document.getElementsByClassName("form-control");//capturamos todos los campos que tienen la clase requerido
    for (var i = 0; i < inputs.length; i++) {
        inputs[i].style.borderColor = "#ccc";//modificamos el color del input
    }
}

function llenarCombo(ruta, control, value, option) {
/*esta funcion nos ayuda a llenar select
pide la ruta de la accion,el id del select,
el nombre de la propiedad que ira en el value,
y la propiedad que ira en el option
*/
    $.get(ruta, function (data) {
        html = "";
        html += '<option value="">--seleccione una opcion--</option>';
        for (var i = 0; i < data.length; i++) {
            var objeto = data[i];
            html += '<option value="' + objeto[value] + '">' + objeto[option] + '</option>';
        }
        control.innerHTML = html;
    })
}

function EnviarInformacion(ruta, frm, esModal) {
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
                }
                limpiar();
                alertify.success("Registro agregado");
                document.getElementById("btnCerrarModal").click();
            } else if (respuesta == -1) {
                document.getElementById("mensajeVacios").innerHTML = "<span class='text-danger'>Este registro ya existe en la base de datos...</span>";
            } else {
                alertify.error("Error en el sistema");
            }
        }
    })
}

function limpiar() {
    colorDefault();
    //limpia los valores de los inputs
    var inputs = document.getElementsByClassName("form-control");//capturamos los inputs que tiene la calse form-control
    for (var i = 0; i < inputs.length; i++) {
        inputs[i].value = "";//iteramos y ponemos el value en vacio
    }
    var foto = document.getElementsByClassName("foto");//capturamos los inputs que tiene la clase foto
    for (var i = 0; i < foto.length; i++) {
        foto[i].src = "";//iteramos y ponemos el src en vacio
    }
    document.getElementById("mensajeVacios").innerHTML = "";//vaciamos lo que tenga el tag
}

function eliminarData(ruta) {
    //eliminar registros esta funcion recibe como parametro la ruta de la accion
    $.get(ruta, function (r) {
        if (r) {
            alertify.success("Registro eliminado");
            listar();
        } else {
            alertify.error("Ocurrio un error ");
        }
    })
}

function validarContraseña(inputContraseña, mensaje) {
    //vamos a validar que la contraseña sea segura utilizando expresiones regulares
    var respuesta = true;
    var mayusculas = new RegExp("^(?=.*[A-Z])");
    var caracteresEspeciales = new RegExp("^(?=.*[!@#$&*])");
    var numeros = new RegExp("^(?=.*[0-9])");
    var minisculas = new RegExp("^(?=.*[a-z])");
    //var tamañoCadena = new RegExp("^(?=.*{5,})");
    var contraseñaEvaluar = inputContraseña.value;
    if (!(mayusculas.test(contraseñaEvaluar) && caracteresEspeciales.test(contraseñaEvaluar) && numeros.test(contraseñaEvaluar)
        && minisculas.test(contraseñaEvaluar))) {
        mensaje.innerHTML = '<span class="text-danger">Contraseña insegura: debe contener mayusculas, minusculas, numeros y caracteres especiales[C@ntras3ña20]</span>';
        respuesta = false;
    }
    return respuesta;
}

function generarSugerencias(nombre, apellido) {
//generador de sugerencias para nombre de usuario
    var nrandom = Math.random() * 1000;
    var mensaje = "";
    mensaje += "<span class='text-danger'>El usuario " + $("#txtUsuario").val() + " ya esta en uso.</span><br>";
    if (nrandom < 300) {
        mensaje += "<span class='text-danger'>Prueba con " + $("#txtUsuario").val() + Math.floor(nrandom) + "</span>";
    } else if (nrandom > 300 && nrandom < 500) {
        mensaje += "<span class='text-danger'>Prueba con " + nombre.replace(" ", "_") + Math.floor(nrandom) + "</span>";
    } else if (nrandom > 500 && nrandom < 750)
    {
        mensaje += "<span class='text-danger'>Prueba con " + apellido.replace(" ", "@") + Math.floor(nrandom) + "</span>";
    }
    else if (nrandom > 750) {
        mensaje += "<span class='text-danger'>Prueba con " + apellido.replace(" ", ".") + "@" + nombre.replace(" ","."); + "</span>";
    }
    document.getElementById("mensajeVacios").innerHTML = mensaje;
}

function crearTabla(url, propiedades, llaveprimaria, encabezados, control) {
/*funcion generica para dibujar tablas con paginado
url:ruta del controlador;
propiedades:array con el nombre de las propiedades del modelo;
llaveprimaria: propiedad del modelo que representa la llave primaria;
encabezados:encabexados que iran en thead;
control:tag donde se agregara la tabla
*/
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
            html += '<button class="badge badge-primary" onclick="detalle(' + dataActual[llaveprimaria] + ')" data-toggle="modal" data-target="#exampleModal">detalles</button> '
            html += '<button class="badge badge-primary" onclick="eliminar(' + dataActual[llaveprimaria] + ')">eliminar</button>'
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