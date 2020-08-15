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
    public class TipoUsuarioController : Controller
    {
        TipoUsuarioBL bl = new TipoUsuarioBL();
        public JsonResult listarPaginasAsignadas(Int64 id)
        {
            var lista = bl.listarPaginasAsignadas(id);
            return Json(lista);
        }
        public IActionResult Index()
        {
            int idUsuario = 0;//variable que utilizaremos para verificar
            idUsuario = Convert.ToInt32(HttpContext.Session.GetString("usuario"));//capturamos el id del usuario
            if (idUsuario > 0)//si existe el id
            {
                if (FiltroPaginasController.puedeVerEstaPagina("tipousuario", "index", idUsuario))//validamos que el usuario sea administrador
                {
                    return View();
                }
                else//si es otro usuario que no sea admin
                {
                    return Redirect("/home/ErrorPermiso");
                }
            }
            else//si no existe el id obligar login
            {
                return Redirect("/vendedor/index");
            }
        }
        public JsonResult listar()
        {
            return Json(bl.listar());
        }
        public int guardar(TipoUsuarios tipoUsuarios, int[] idPaginas)
        {
            return bl.guardar(tipoUsuarios, idPaginas);
        }
        public JsonResult obtenerPorId(int id)
        {
            return Json(bl.obtenerPorId(id));
        }
        public bool eliminar(int id)
        {
            return bl.eliminar(id);
        }
    }
}
