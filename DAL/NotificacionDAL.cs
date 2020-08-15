using CompratodoUI.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompratodoUI.Models;

namespace CompratodoUI.DAL
{
    public class NotificacionDAL
    {
        /// <summary>
        /// Este metodo estara esperando el id del usuario logueado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<NotificacionCLS>listarNofiticaciones(Int64 id)
        {
            List<NotificacionCLS> lista = new List<NotificacionCLS>();
            using (var bd = new BDCatalogoContext())
            {
                lista = (from notificacion in bd.Notificaciones
                         join denuncia in bd.Denuncias on notificacion.Iiddenuncia equals denuncia.Iiddenuncia
                         join producto in bd.Productos on denuncia.Iidproducto equals producto.Iidproducto
                         join vendedor in bd.Vendedores on producto.Iidvendedor equals vendedor.Iidvendedor
                         where vendedor.Iidvendedor == id
                         select new NotificacionCLS
                         {
                             id=notificacion.Iidnotificacion,
                             nombreproducto = producto.Nombre,
                             notificacionleida=notificacion.Notificacionleida
                         }).ToList();
            }
            lista = lista.OrderByDescending(z => z.id).ToList();
            return lista;
        }
        public NotificacionCLS detalleNotificacion(Int64 id)
        {
            using(var bd = new BDCatalogoContext())
            {
                var data = (from notificacion in bd.Notificaciones
                            join denuncia in bd.Denuncias on notificacion.Iiddenuncia equals denuncia.Iiddenuncia
                            join producto in bd.Productos on denuncia.Iidproducto equals producto.Iidproducto
                            join vendedor in bd.Vendedores on producto.Iidvendedor equals vendedor.Iidvendedor
                            where notificacion.Iidnotificacion.Equals(id)
                            select new NotificacionCLS
                            {
                                id = notificacion.Iidnotificacion,
                                nombreproducto = producto.Nombre,
                                nombrevendedor = vendedor.Nombre,
                                descripcion = producto.Descripcion,
                                motivo=denuncia.Motivo,
                                notificacionleida = notificacion.Notificacionleida
                            }).First();
                return data;
            }
        }
        public bool marcarComoLeida(Int64 id)
        {
            try
            {
                using (var bd = new BDCatalogoContext())
                {
                    var data = bd.Notificaciones.Where(p => p.Iidnotificacion.Equals(id)).First();
                    data.Notificacionleida = 1;//uno para mi significa que ya se leyo
                    bd.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
