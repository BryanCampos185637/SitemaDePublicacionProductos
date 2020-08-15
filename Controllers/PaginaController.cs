﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompratodoUI.Models;
using CompratodoUI.BL;
using Microsoft.AspNetCore.Http;

namespace CompratodoUI.Controllers
{
    public class PaginaController : Controller
    {
        PaginaBL bl = new PaginaBL();
        public IActionResult Index()
        {
            int idUsuario = 0;//variable que utilizaremos para verificar
            idUsuario = Convert.ToInt32(HttpContext.Session.GetString("usuario"));//capturamos el id del usuario
            if (idUsuario > 0)//si existe el id
            {
                if (FiltroPaginasController.puedeVerEstaPagina("pagina", "index", idUsuario))//validamos que el usuario sea administrador
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
        public int guardar(Paginas paginas)
        {
            return bl.guardar(paginas);
        }
        public JsonResult obtenerPorId(int id)
        {
            return Json(bl.obtenerPorId(id));
        }
        public bool eliminar(int id)
        {
            return bl.eliminar(id);
        }
        public JsonResult listar()
        {
            return Json(bl.listar());
        }
        public JsonResult generarMenu()
        {
            try
            {
                using (var bd = new BDCatalogoContext())
                {
                    int idVendedor = Convert.ToInt32(HttpContext.Session.GetString("usuario"));
                    var data = bd.Vendedores.Where(p => p.Iidvendedor.Equals(idVendedor)).First();
                    return Json(PaginaBL.menuDinamico(data.Iidtipousuario));
                }
            }
            catch(Exception e)
            {
                return Json(null);
            }
        }
    }
}
