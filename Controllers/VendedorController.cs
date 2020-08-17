using Microsoft.AspNetCore.Mvc;
using CompratodoUI.BL;
using CompratodoUI.Models;
using Microsoft.AspNetCore.Http;
using CompratodoUI.BE;
using System.Linq;
using System.Collections.Generic;
using System;
using CompratodoUI.DAL;

namespace CompratodoUI.Controllers
{
    public class VendedorController : Controller
    {
        VendedorBL bl = new VendedorBL();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }
        public bool vetarVendedor(Int64 id)
        {
            return bl.vetarVendedor(id);
        }
        public JsonResult perfil(Int64 id)
        {
            Vendedores data = null;
            if (id != 0)
                data = bl.perfil(id);
            else
                data = bl.perfil(Convert.ToInt32(HttpContext.Session.GetString("usuario")));
           return Json(data);
        }
        public int guardar(Vendedores vendedores)
        {
            var vendedorNoexists = bl.listar().Count();//verificamos que no exista ningun usuario
            if (vendedorNoexists == 0)// si esta a cero la tabla el primer registro sera administradi
            {
                vendedores.Iidtipousuario = 1;
            }else if (vendedores.Iidtipousuario == 0)//si ya existe se le asigna el tipo usuario vendedor
            {
                vendedores.Iidtipousuario = 2;
            }
            vendedores.Bhabilitado = 1;
            var respuesta = bl.guardar(vendedores);
            return respuesta;
        }
        public string login(string usuario, string contraseña)
        {
            Vendedores data = bl.login(usuario, contraseña);//capturamos la data
            if (data != null)//verificamos que no este null
            {
                if (data.Bhabilitado == 1)//verificamos que el usuario no este eliminado 
                {
                    HttpContext.Session.SetString("usuario", data.Iidvendedor.ToString());//creo una cookie
                    return "ok";
                }
                else if(data.Bhabilitado == 2)// si el bhabilitado es igual a 2 significa que lo vetaron del sistema por ende no podra acceder
                {
                    return "vetado";
                }
                else// si esta en 0 es porque eliminaron su perfil 
                {
                    return "eliminado";
                }
            }
            else//no hubieron coincidencias con los parametros
            {
                return "error";
            }
        }
        public ActionResult cerrarSesion()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("usuario");
            return Redirect("/home/index");
        }
        public int modificarPerfil(Vendedores vendedores,string contraseñaActual)
        {
            var data = bl.perfil(vendedores.Iidvendedor);//obtenemos la data para validar contraseñas
            string contraseñaRegistrada = data.Contraseña;//capturamos la contraseña que esta en la base de datos
            if (Utilidades.cifrarContraseña(contraseñaActual) == contraseñaRegistrada)//si las contraseñas concuerdan se procede a modificar
            {
                return bl.guardar(vendedores);
            }
            else
            {
                return -1;//si la contraseña no es igual no se puede modificar y retornamos un -1
            }
        }
    }
}
