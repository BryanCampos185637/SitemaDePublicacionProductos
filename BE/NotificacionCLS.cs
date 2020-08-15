using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.BE
{
    public class NotificacionCLS
    {
        public Int64 id { get; set; }
        public string motivo { get; set; }
        public string descripcion { get; set; }
        public string nombreproducto { get; set; }
        public string nombrevendedor { get; set; }
        public int notificacionleida { get; set; }
    }
}
