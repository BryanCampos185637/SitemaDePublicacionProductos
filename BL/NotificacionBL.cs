using CompratodoUI.BE;
using CompratodoUI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.BL
{
    public class NotificacionBL
    {
        NotificacionDAL dal = new NotificacionDAL();
        public List<NotificacionCLS>listaNotificaciones(Int64 id)
        {
            return dal.listarNofiticaciones(id);
        }
        public NotificacionCLS detalle(Int64 id)
        {
            return dal.detalleNotificacion(id);
        }
        public bool marcarComoLeido(Int64 id)
        {
            return dal.marcarComoLeida(id);
        }
    }
}
