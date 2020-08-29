using CompratodoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace CompratodoUI.DAL
{
    public class TipoUsuarioDAL
    {
        public int guardar(TipoUsuarios tipoUsuarios, int[] idPaginas)
        {
            try
            {
                using(var bd= new BDCatalogoContext())
                {
                    //utilizamos una transaccion porque afectaremos dos tablas a la vez
                    using(var transaccion = new TransactionScope())
                    {
                        if (tipoUsuarios.Iidtipousuario == 0)//guarda
                        {
                            tipoUsuarios.Bhabilitado = 1;
                            bd.TipoUsuarios.Add(tipoUsuarios);
                            bd.SaveChanges();//confirmamos el guardado de tipo usaurio
                            //a continuacion procedemos a insertar las paginas
                            #region guardar pagina
                            var paginashabilitadas = bd.PaginaTipoUsuarios.Where(x => x.Iidtipousuario.Equals(tipoUsuarios.Iidtipousuario)).ToList();//primero obtenemos las paginas que contengan el id del tipo usuario
                            //con un foreach vamos a recorrer los registros para deshabilitarlos
                            foreach (PaginaTipoUsuarios item in paginashabilitadas)
                            {
                                item.Bhabilitado = 0;//cambiamos a 0 el valor
                                bd.SaveChanges();//confirmamos que se guardara
                            }
                            //ya deshabilitada las paginas vamos a verificar si la pagina ya existe
                            foreach (int pagina in idPaginas)
                            {
                                int existePagina = bd.PaginaTipoUsuarios.Where(p => p.Iidpagina.Equals(pagina) && p.Iidtipousuario.Equals(tipoUsuarios.Iidtipousuario)).Count();
                                if (existePagina == 0)//si no existe procedemos a guardar el registro
                                {
                                    PaginaTipoUsuarios ptu = new PaginaTipoUsuarios();//instancia del modelo
                                    ptu.Iidtipousuario = tipoUsuarios.Iidtipousuario;//almacenamos el valor del id de tipo usuario
                                    ptu.Iidpagina = pagina;//almacenamos el valor del id que viene en el array
                                    ptu.Bhabilitado = 1;//y habilitamos la pagina
                                    bd.PaginaTipoUsuarios.Add(ptu);//preparamos para guardar
                                    bd.SaveChanges();//confirmamos el guardado
                                }
                                else//si el registro existe
                                {
                                    //obtenemos el registro que contiene el id de la pagina y del tipo de usuario
                                    var paginaHabilitar = bd.PaginaTipoUsuarios.Where(p => p.Iidpagina.Equals(pagina) && p.Iidtipousuario.Equals(tipoUsuarios.Iidtipousuario)).First();
                                    paginaHabilitar.Bhabilitado = 1;//ahora habilitamos el registro
                                    bd.SaveChanges();//confirmamos el guardado
                                }
                            }
                            #endregion
                        }
                        else//modifica
                        {
                            var dataTipoUsuario = bd.TipoUsuarios.Where(p => p.Iidtipousuario.Equals(tipoUsuarios.Iidtipousuario)).First();
                            dataTipoUsuario.Nombre = tipoUsuarios.Nombre;
                            dataTipoUsuario.Descripcion = tipoUsuarios.Descripcion;
                            bd.SaveChanges();//confirmamos el guardar de tipo usuario

                            //a continuacion procedemos a insertar las paginas
                            #region guardar pagina
                            var paginashabilitadas = bd.PaginaTipoUsuarios.Where(x => x.Iidtipousuario.Equals(tipoUsuarios.Iidtipousuario)).ToList();//primero obtenemos las paginas que contengan el id del tipo usuario
                            //con un foreach vamos a recorrer los registros para deshabilitarlos
                            foreach (PaginaTipoUsuarios item in paginashabilitadas)
                            {
                                item.Bhabilitado = 0;//cambiamos a 0 el valor
                                bd.SaveChanges();//confirmamos que se guardara
                            }
                            //ya deshabilitada las paginas vamos a verificar si la pagina ya existe
                            foreach (int pagina in idPaginas)
                            {
                                int existePagina = bd.PaginaTipoUsuarios.Where(p => p.Iidpagina.Equals(pagina) && p.Iidtipousuario.Equals(tipoUsuarios.Iidtipousuario)).Count();
                                if (existePagina == 0)//si no existe procedemos a guardar el registro
                                {
                                    PaginaTipoUsuarios ptu = new PaginaTipoUsuarios();//instancia del modelo
                                    ptu.Iidtipousuario = tipoUsuarios.Iidtipousuario;//almacenamos el valor del id de tipo usuario
                                    ptu.Iidpagina = pagina;//almacenamos el valor del id que viene en el array
                                    ptu.Bhabilitado = 1;//y habilitamos la pagina
                                    bd.PaginaTipoUsuarios.Add(ptu);//preparamos para guardar
                                    bd.SaveChanges();//confirmamos el guardado
                                }
                                else//si el registro existe
                                {
                                    //obtenemos el registro que contiene el id de la pagina y del tipo de usuario
                                    var paginaHabilitar = bd.PaginaTipoUsuarios.Where(p => p.Iidpagina.Equals(pagina) && p.Iidtipousuario.Equals(tipoUsuarios.Iidtipousuario)).First();
                                    paginaHabilitar.Bhabilitado = 1;//ahora habilitamos el registro
                                    bd.SaveChanges();//confirmamos el guardado
                                }
                            }
                            #endregion
                        }
                        transaccion.Complete();//aqui se guardan los cambios realizados 
                        return 1;
                    }
                }
            }
            catch(Exception e)
            {
                string m = e.Message;
                return 0;
            }
        }
        public List<TipoUsuarios> listar()
        {
            using(var bd = new BDCatalogoContext())
            {
                var lista = (from tipoUs in bd.TipoUsuarios
                             where tipoUs.Bhabilitado == 1
                             select new TipoUsuarios
                             {
                                 Iidtipousuario = tipoUs.Iidtipousuario,
                                 Nombre = tipoUs.Nombre,
                                 Descripcion = tipoUs.Descripcion
                             }).ToList();
                lista = lista.OrderByDescending(x => x.Iidtipousuario).ToList();
                return lista;
            }
        }
        public TipoUsuarios obtenerPorId(int id)
        {
            using(var bd = new BDCatalogoContext())
            {
                return bd.TipoUsuarios.Where(p => p.Iidtipousuario.Equals(id)).First();
            }
        }
        public bool eliminar(int id)
        {
            try
            {
                using (var bd = new BDCatalogoContext())
                {
                    using(var transaccion = new TransactionScope())
                    {
                        //validamos que el id que viene no sea el 1 ya que este es el admin por ende no deberia poder eliminarse
                        //o que no sea el 2 osea el vendedor
                        if (id > 2)
                        {
                            var data = bd.TipoUsuarios.Where(x => x.Iidtipousuario.Equals(id)).First();
                            data.Bhabilitado = 0;
                            bd.SaveChanges();
                            var paginashabilitadas = bd.PaginaTipoUsuarios.Where(x => x.Iidtipousuario.Equals(id)).ToList();//primero obtenemos las paginas que contengan el id del tipo usuario
                            //con un foreach vamos a recorrer los registros para deshabilitarlos
                            foreach (PaginaTipoUsuarios item in paginashabilitadas)
                            {
                                item.Bhabilitado = 0;//cambiamos a 0 el valor
                                bd.SaveChanges();//confirmamos que se guardara
                            }
                            transaccion.Complete();//afirmamos que se guardara
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public List<Paginas> listarPaginasAsignadas(Int64 id)
        {
            List<Paginas> lista = new List<Paginas>();
            using(var bd = new BDCatalogoContext())
            {
                lista = (from ptu in bd.PaginaTipoUsuarios
                         where ptu.Iidtipousuario==id && ptu.Bhabilitado == 1
                         select new Paginas
                         {
                             Iidpagina = (int)ptu.Iidpagina
                         }).ToList();
            }
            return lista;
        }
    }
}
