using System;
using System.Collections.Generic;

namespace CompratodoUI.Models
{
    public partial class Productos
    {
        public Productos()
        {
            Denuncias = new HashSet<Denuncias>();
        }

        public long Iidproducto { get; set; }
        public int Iidcategoria { get; set; }
        public string Nombre { get; set; }
        public int Bhabilitado { get; set; }
        public string Foto { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public long Iidvendedor { get; set; }
        public int Estadoventa { get; set; }

        public virtual Categorias IidcategoriaNavigation { get; set; }
        public virtual Vendedores IidvendedorNavigation { get; set; }
        public virtual ICollection<Denuncias> Denuncias { get; set; }
    }
}
