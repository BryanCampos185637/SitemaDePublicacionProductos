using System;
using System.Linq;
using CompratodoUI.BL;
using Microsoft.AspNetCore.Mvc;
using CompratodoUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Runtime.InteropServices;

namespace CompratodoUI.Controllers
{
    public class ProductoController : Controller
    {
        ProductoBL bL = new ProductoBL();
        #region vistas
        public IActionResult Index()
        {
            int valor = 0;
            valor = Convert.ToInt32(HttpContext.Session.GetString("usuario"));//capturamos el id del usuario
            if (valor > 0)
            {
                ViewBag.id = valor;
                return View();
            }
            else
            {
                ViewBag.id = 0;
                return View();
            }
        }
        public IActionResult opcionesVendedor()
        {
            /*
            en esta vista solo se podra acceder si ya iniciaste sesion
        */
            int idUsuario = 0;//variable que utilizaremos para verificar
            idUsuario = Convert.ToInt32(HttpContext.Session.GetString("usuario"));//capturamos el id del usuario
            if (idUsuario > 0)//si existe el id
            {
                if (FiltroPaginasController.puedeVerEstaPagina("producto", "opcionesVendedor", idUsuario))//validamos que el usuario sea administrador
                {
                    VendedorBL vendedorBL = new VendedorBL();
                    var data = vendedorBL.perfil(idUsuario);
                    ViewBag.nombre = data.Nombre + " " + data.Apellidos;
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
        #endregion
        public bool vetarProducto(Int64 id)
        {
            return bL.vetarProducto(id);
        }
        public bool cambiarEstado(int id)
        {
            return bL.cambiarEstado(id);
        }
        public JsonResult listar(string nombre)
        {
            return Json(bL.listar(nombre));
        }
        public JsonResult listarCategorias()
        {
            CategoriaBL categoriaBL = new CategoriaBL();
            var lista = categoriaBL.listar();
            return Json(lista);
        }
        public JsonResult obtenerPorId(int id)
        {
            return Json(bL.obtenerPorId(id));
        }
        public JsonResult productosPorVendedor()
        {
            string idVendedor = HttpContext.Session.GetString("usuario");
            return Json(bL.productosPorVendedor(Convert.ToInt32(idVendedor)));
        }

        #region guardar
        [Obsolete]
        private readonly IHostingEnvironment _env;

        [Obsolete]
        public ProductoController(IHostingEnvironment hosting)
        {
            _env = hosting;
        }
        public int guardar(Productos productos,IFormFile archivo)
        {
            try
            {
                if (archivo != null)//solo si es diferente de null
                {
                    productos.Foto = guardarImagenEnDirectorio(archivo);
                }
                int respuesta = 0;
                productos.Iidvendedor = Convert.ToInt32(HttpContext.Session.GetString("usuario"));//capturamos el id de la sesion
                return respuesta = bL.guardar(productos);
            }
            catch(Exception e)
            {
                return 0;
            }
            
        }

        public string guardarImagenEnDirectorio(IFormFile foto)
        {
            try
            {
                var nombreunico = foto.FileName;//sacamos el nombre de la foto
                var ruta = Path.Combine(_env.WebRootPath, "foto_producto");//obtenemos la ruta de la carpeta destino
                if (!Directory.Exists(ruta)) { Directory.CreateDirectory(ruta); }//si no existe la carpeta la creamos
                var filePath = Path.Combine(ruta, nombreunico);//armamos una ruta
                foto.CopyTo(new FileStream(filePath, FileMode.Create));//guardamos la foto
                return nombreunico;//retornamos el nombre
            }
            catch(Exception e)
            {
                return "";
            }
        }
        #endregion

        public bool eliminar(Int64 id)
        {
            var respuesta = bL.eliminar(id);
            return respuesta;
        }
    }
}
