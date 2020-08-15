using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.BE
{
    public class DenunciaCLS
    {
        public Int64 id { get; set; }
        public string motivo { get; set; }
        public Int64 idproducto { get; set; }
        public string nombreproducto { get; set; }
        public Int64 idvendedor { get; set; }
        public string nombrevendedor { get; set; }
        public Int64 denuncias { get; set; }
        public int bhabilitadov { get; set; }
        public int bhabilitadop { get; set; }
    }
}
