using CompratodoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.DAL
{
    public class CategoriaDAL
    {
        //DAL= Data Acces Logic
        int result = 0;
        public List<Categorias> listar()
        {
            using (var bd = new BDCatalogoContext())
            {
                var lista = bd.Categorias.Where(p => p.Bhabilitado == 1).ToList();
                lista = lista.OrderByDescending(x => x.Iidcategoria).ToList();
                return lista;
            }
        }
        public Categorias obtenerPorId(int id)
        {
            using(var bd = new BDCatalogoContext())
            {
                var data = bd.Categorias.Where(p => p.Iidcategoria.Equals(id)).FirstOrDefault();
                return data;
            }
        }
        public bool eliminar(int id)
        {
            using(var bd = new BDCatalogoContext())
            {
                Categorias data = bd.Categorias.Where(p => p.Iidcategoria.Equals(id)).FirstOrDefault();
                data.Bhabilitado = 0;
                result = bd.SaveChanges();
                if (result > 0) return true;
                else return false;
            }
        }
        public int guardar(Categorias categoria)
        {
            int nveces = 0;
            using(var bd = new BDCatalogoContext())
            {
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
                        data.Descripcion = categoria.Descripcion;
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
}
