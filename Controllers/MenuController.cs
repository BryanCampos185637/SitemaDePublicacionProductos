using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompratodoUI.BE;
using CompratodoUI.BL;
using CompratodoUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompratodoUI.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            int idUsuario = 0;//variable que utilizaremos para verificar
            idUsuario = Convert.ToInt32(HttpContext.Session.GetString("usuario"));//capturamos el id del usuario
            if (idUsuario > 0)//si existe el id
            {
                if (FiltroPaginasController.puedeVerEstaPagina("menu", "index", idUsuario))//SI ESTA RELACIONADA LA VISTA CON EL TIPO DE USUARIO DAMOS ACCESO
                {
                    ViewBag.id = idUsuario;
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
        [HttpGet]
        public JsonResult listarCategorias()
        {
            CategoriaBL categoriaBL = new CategoriaBL();
            return Json(categoriaBL.listar());
        }
        public JsonResult PintarProductoSegunCategoria(Int64 idCategoria,string nombre)
        {
            ProductoBL productoBL = new ProductoBL();
            return Json(productoBL.PintarProductoSegunCategoria(idCategoria,nombre));
        }
    }
}
