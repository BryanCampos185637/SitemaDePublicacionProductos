using CompratodoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.DAL
{
    public class PaginaDAL
    {
        public int guardar(Paginas paginas)
        {
            try
            {
                using(var bd = new BDCatalogoContext())
                {
                    int nveces = bd.Paginas.Where(p => p.Accion.Equals(paginas.Accion) && p.Controlador.Equals(paginas.Controlador)
                    && p.Bhabilitado==1 && p.Iidpagina!=paginas.Iidpagina).Count();
                    if (nveces == 0)
                    {
                        if (paginas.Iidpagina == 0)
                        {
                            paginas.Bhabilitado = 1;
                            bd.Paginas.Add(paginas);
                            bd.SaveChanges();
                            return 1;
                        }
                        else
                        {
                            var data = bd.Paginas.Where(p => p.Iidpagina.Equals(paginas.Iidpagina)).First();
                            data.Mensaje = paginas.Mensaje;
                            data.Accion = paginas.Accion;
                            data.Controlador = paginas.Controlador;
                            bd.SaveChanges();
                            return 1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch(Exception e)
            {
                return 0;
            }
        }
        public bool eliminar(int id)
        {
            try
            {
                using (var bd = new BDCatalogoContext())
                {
                    var data = bd.Paginas.Where(p => p.Iidpagina.Equals(id)).First();
                    data.Bhabilitado = 0;
                    bd.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public Paginas obtenerPorId(int id)
        {
            using (var bd = new BDCatalogoContext())
            {
                var data = bd.Paginas.Where(p => p.Iidpagina.Equals(id)).First();
                return data;
            }
        }
        public List<Paginas> listar()
        {
            using (var bd = new BDCatalogoContext())
            {
                List<Paginas> lista = (from pagina in bd.Paginas
                                       where pagina.Bhabilitado == 1
                                       select new Paginas
                                       {
                                           Iidpagina=pagina.Iidpagina,
                                           Mensaje = pagina.Mensaje,
                                           Accion = pagina.Accion,
                                           Controlador = pagina.Controlador
                                       }).ToList();
                lista = lista.OrderByDescending(x => x.Iidpagina).ToList();
                return lista;
            }
        }
        public static List<Paginas> menuDinamico(int idUsuario)
        {
            using (var bd = new BDCatalogoContext())
            {
                List<Paginas> lista = (from ptu in bd.PaginaTipoUsuarios
                                       join pagina in bd.Paginas on ptu.Iidpagina equals pagina.Iidpagina
                                       where ptu.Bhabilitado == 1 && ptu.Iidtipousuario == idUsuario && pagina.Bhabilitado == 1
                                       select new Paginas
                                       {
                                           Mensaje = pagina.Mensaje,
                                           Accion = pagina.Accion,
                                           Controlador = pagina.Controlador
                                       }).ToList();
                return lista;
            }
        }
    }
}
