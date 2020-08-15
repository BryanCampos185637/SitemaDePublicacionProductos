using System;
using System.Collections.Generic;

namespace CompratodoUI.Models
{
    public partial class TipoUsuarios
    {
        public TipoUsuarios()
        {
            PaginaTipoUsuarios = new HashSet<PaginaTipoUsuarios>();
            Vendedores = new HashSet<Vendedores>();
        }

        public int Iidtipousuario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Bhabilitado { get; set; }

        public virtual ICollection<PaginaTipoUsuarios> PaginaTipoUsuarios { get; set; }
        public virtual ICollection<Vendedores> Vendedores { get; set; }
    }
}
