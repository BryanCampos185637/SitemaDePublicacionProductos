using System;
using System.Collections.Generic;

namespace CompratodoUI.Models
{
    public partial class Categorias
    {
        public Categorias()
        {
            Productos = new HashSet<Productos>();
        }

        public int Iidcategoria { get; set; }
        public string Nombre { get; set; }
        public int Bhabilitado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
