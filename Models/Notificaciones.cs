using System;
using System.Collections.Generic;

namespace CompratodoUI.Models
{
    public partial class Notificaciones
    {
        public long Iidnotificacion { get; set; }
        public long Iiddenuncia { get; set; }
        public int Notificacionleida { get; set; }

        public virtual Denuncias IiddenunciaNavigation { get; set; }
    }
}
