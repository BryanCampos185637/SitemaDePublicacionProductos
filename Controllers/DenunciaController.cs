using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompratodoUI.BL;
using CompratodoUI.Models;
using Microsoft.AspNetCore.Http;

namespace CompratodoUI.Controllers
{
    public class DenunciaController : Controller
    {
        DenunciaBL bl = new DenunciaBL();
        public IActionResult Index()
        {
            int idUsuario = 0;//variable que utilizaremos para verificar
            idUsuario = Convert.ToInt32(HttpContext.Session.GetString("usuario"));//capturamos el id del usuario
            if (idUsuario > 0)//si existe el id
            {
                    if (FiltroPaginasController.puedeVerEstaPagina("denuncia", "index", idUsuario))//validamos que el usuario sea administrador
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
        public int guardar(Denuncias denuncias)
        {
            int r = bl.guardarDenuncia(denuncias);
            return r;
        }
        public JsonResult listar()
        {
            return Json(bl.listar());
        }
    }
}
