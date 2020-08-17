using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompratodoUI.Models;
using Microsoft.AspNetCore.Http;

namespace CompratodoUI.Controllers
{
    public class CategoriaController : Controller
    {
        BDCatalogoContext bd = new BDCatalogoContext();
        public IActionResult Index()
        {
            int idUsuario = 0;//variable que utilizaremos para verificar
            idUsuario = Convert.ToInt32(HttpContext.Session.GetString("usuario"));//capturamos el id del usuario
            if (idUsuario > 0)//si existe el id
            {
                if (FiltroPaginasController.puedeVerEstaPagina("categoria", "index",idUsuario))//SI ESTA RELACIONADA LA VISTA CON EL TIPO DE USUARIO DAMOS ACCESO
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
        [HttpGet]
        public List<Categorias> listar()
        {
            using(var bd1 = new BDCatalogoContext())
            {
                var lista = bd1.Categorias.Where(p => p.Bhabilitado == 1).ToList();
                lista = lista.OrderByDescending(x => x.Iidcategoria).ToList();
                return lista;
            }
        }
        [HttpGet]
        public Categorias obtenerPorId(int id)
        {
            Categorias data = bd.Categorias.Where(p => p.Iidcategoria.Equals(id)).FirstOrDefault();
            return data;
        }
        int result = 0;
        public bool eliminar(int id)
        {
            Categorias data = bd.Categorias.Where(p => p.Iidcategoria.Equals(id)).FirstOrDefault();
            data.Bhabilitado = 0;
            result = bd.SaveChanges();
            if (result > 0) return true;
            else return false;
        }
        int nveces = 0;
        public int guardar(Categorias categoria)
        {
            categoria.Bhabilitado = 1;
            nveces = bd.Categorias.Where(p => p.Iidcategoria != categoria.Iidcategoria && p.Nombre.Equals(categoria.Nombre) && p.Bhabilitado == 1).Count();
            if (nveces <= 0)
            {
                if (categoria.Iidcategoria == 0)
                {
                    bd.Categorias.Add(categoria);
                    bd.SaveChanges();
                    result = 1;
                }
                else
                {
                    Categorias data = bd.Categorias.Where(p => p.Iidcategoria.Equals(categoria.Iidcategoria)).FirstOrDefault();
                    data.Nombre = categoria.Nombre;
                    bd.SaveChanges();
                    result = 1;
                }
            }
            else
            {
                result = -1;
            }
            return result;
        }
    }
}
