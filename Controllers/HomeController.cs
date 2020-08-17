using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CompratodoUI.Models;
using CompratodoUI.BL;
using Microsoft.AspNetCore.Http;

namespace CompratodoUI.Controllers
{
    public class HomeController : Controller
    {
        Int64 usuarioid = 0;
        /// <summary>
        /// solo prueba para agregar 499 registros
        /// </summary>
        public void guardar500registros()
        {
            BL.ProductoBL producto = new ProductoBL();
            Productos productos = new Productos();
            using(var bd = new BDCatalogoContext()) 
            {
                int idcategoria = 1;
                for (int i = 0; i < 500; i++)
                {
                    productos.Iidproducto = 0;
                    productos.Bhabilitado = 1;
                    productos.Nombre = "prueba " + i;
                    productos.Iidvendedor = 1;
                    productos.Iidcategoria = idcategoria;
                    productos.Precio = (decimal)0.89*i;
                    productos.Foto = "1651-earplugs-1920x1200-music-wallpaper.jpg";
                    productos.Descripcion = "lo qye sea " + i;
                    productos.Estadoventa = 1;
                    producto.guardar(productos);
                    idcategoria++;
                    if (idcategoria == 5)
                        idcategoria = 1;
                }
                
            }
            
        }
        public IActionResult Index()
        {
            //guardar500registros();
            usuarioid = Convert.ToInt32(HttpContext.Session.GetString("usuario"));
            ViewBag.id = usuarioid;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ErrorPermiso()
        {
            return View();
        }
    }
}
