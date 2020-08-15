using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompratodoUI.BL;
using CompratodoUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompratodoUI.Controllers
{
    public class UsuarioController : Controller
    {
        VendedorBL bl= new VendedorBL();
        public IActionResult Index()
        {
            int idUsuario = 0;//variable que utilizaremos para verificar
            idUsuario = Convert.ToInt32(HttpContext.Session.GetString("usuario"));//capturamos el id del usuario
            if (idUsuario > 0)//si existe el id
            {
                if (FiltroPaginasController.puedeVerEstaPagina("usuario", "index", idUsuario))//SI ESTA RELACIONADA LA VISTA CON EL TIPO DE USUARIO DAMOS ACCESO
                {
                    return View();
                }
                else//SI NO TIENE ASIGNADA LA VISTA LO ENVIAMOS A UNA VISTA DE ERROR
                {
                    return Redirect("/home/ErrorPermiso");
                }
            }
            else//si no existe el id obligar login
            {
                return Redirect("/vendedor/index");
            }
        }
        public JsonResult listarUsuarios()
        {
            return Json(bl.listar());
        }
        public JsonResult obtenerPorId(Int64 id)
        {
            return Json(bl.perfil(id));
        }
        public int modificar(Vendedores vendedores)
        {
            return bl.guardar(vendedores);
        }
    }
}
