using System;
using System.Collections.Generic;

namespace CompratodoUI.Models
{
    public partial class Denuncias
    {
        public Denuncias()
        {
            Notificaciones = new HashSet<Notificaciones>();
        }

        public long Iiddenuncia { get; set; }
        public string Motivo { get; set; }
        public long Ndenuncias { get; set; }
        public long Iidproducto { get; set; }

        public virtual Productos IidproductoNavigation { get; set; }
        public virtual ICollection<Notificaciones> Notificaciones { get; set; }
    }
}
