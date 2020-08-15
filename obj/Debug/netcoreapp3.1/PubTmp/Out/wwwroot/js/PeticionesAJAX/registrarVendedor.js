$("#frmRegistro").submit(function (event) {
    event.preventDefault();
    Enviar();
})
/*var btnRegistrar = document.getElementById("btnRegistrar");
btnRegistrar.onclick = */
function Enviar() {
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
                    frm.append("Iidtipousuario", 2);
                    $.ajax({
                        url: "/Vendedor/guardar",
                        type: "POST",
                        contentType: false,
                        processData: false,
                        data: frm,
                        success: function (r) {
                            if (r > 0) {
                                location.href = "/vendedor/index";
                            }
                            else if (r == -1) {
                                document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>El nombre usuario ya está en uso...</span>";
                                hacerScrollHaciaArriba();
                            } else if (r == -2) {
                                document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>El correo que ingresaste ya está asociado a otra cuenta...</span>";
                                hacerScrollHaciaArriba();
                            }
                            else {
                                document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>Error en el sistema intente mas tarde...</span>";
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

function verificarCorreo() {
    var correo = document.getElementById("correoGmail").value;
    var terminacion = "@gmail.com";
    var index = correo.indexOf(terminacion);
    if (index > 0) {
        return true;
    } else {
        return false;
    }
}