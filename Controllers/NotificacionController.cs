using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompratodoUI.BL;
using Microsoft.AspNetCore.Http;
using CompratodoUI.BE;

namespace CompratodoUI.Controllers
{
    public class NotificacionController : Controller
    {
        NotificacionBL bl = new NotificacionBL();
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
        public bool marcarComoLeido(Int64 id)
        {
            return bl.marcarComoLeido(id);
        }
        public JsonResult detalle(Int64 id)
        {
            return Json(bl.detalle(id));
        }

        public JsonResult listarNotificaciones()
        {
            return Json(bl.listaNotificaciones(Convert.ToInt64(HttpContext.Session.GetString("usuario"))));
        }
        //nos sirve para saber la cantidad de notificaciones
        public Int64 numeroNotificacionesNuevas()
        {
            Int64 notificacionesNoLeidas = 0;
            List<NotificacionCLS> lista = bl.listaNotificaciones(Convert.ToInt64(HttpContext.Session.GetString("usuario")));
            foreach(var item in lista)
            {
                if (item.notificacionleida == 0)// si la notificacion no esta leida entonces 
                {
                    notificacionesNoLeidas++;//incrementamos a 1 la variable
                }
            }
            return notificacionesNoLeidas;
        }
    }
}
