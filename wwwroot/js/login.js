var contador = 0;
var btnEntrar = document.getElementById("btnEntrar");
btnEntrar.onclick = function () {
    if (validarVacios()) {
        document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>Cargando...</span>";
        var frm = new FormData();
        frm.append("usuario", $("#txtUser").val());
        frm.append("contraseña", $("#txtPass").val());
        $.ajax({
            url: "/Vendedor/login",
            type: "POST",
            contentType: false,
            processData: false,
            data: frm,
            success: function (r) {
                if (r == "ok") {
                    location.href = "/producto/opcionesVendedor";
                } else if (r == "vetado") {
                    document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>¡Vaya!</span><br><span class='text-primary'>Has sido vetado por infringir las políticas de la página.</span>";
                } else if (r == "eliminado") {
                    document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>¡Vaya!</span><br><span class='text-primary'>Esta cuenta ha sido eliminada</span>";
                } else {
                    document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>Usuario o contraseña incorrectos...</span>";
                    contador++;
                    if (contador == 4) {
                        document.getElementById("mensajeVacios").innerHTML = "<a href='#' class='text-primary' onclick='recuperar()'>Click aqui para recuperar contraseña</a>";
                        contador = 0;
                    }
                }
            }
        })
    }
}
var btnRegresar = document.getElementById("btnRegresar");
btnRegresar.onclick = function () {
    location.href = "/home/Index"
}
function recuperar() {
    document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>Cargando...</span>";
    $.get("/FiltroPaginas/recuperarContraseña?nombreUsuario=" + $("#txtUser").val(), function (data) {
        if (data > 0) {
            document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>Se envió un correo a tu cuenta gmail.</span>";
        }
        else {
            document.getElementById("mensajeVacios").innerHTML = "<span class='text-primary'>Error! no se pudo procesar la petición intente más tarde</span>";
        }
    })
}