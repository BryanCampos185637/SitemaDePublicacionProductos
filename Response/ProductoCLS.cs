using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.BE
{
    public class ProductoCLS
    {
        public long id { get; set; }
        public int idcategoria { get; set; }
        public int idvendedor { get; set; }
        public string nombre { get; set; }
        public int bhabilitado { get; set; }
        public string foto { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
        public string nombrecategoria { get; set; }
        public string nombreusuario { get; set; }
        public string correo { get; set; }
        public string tel { get; set; }
        public int estadoventa { get; set; }
    }
}
