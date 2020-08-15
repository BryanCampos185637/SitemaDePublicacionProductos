using System;
using System.Collections.Generic;

namespace CompratodoUI.Models
{
    public partial class Paginas
    {
        public Paginas()
        {
            PaginaTipoUsuarios = new HashSet<PaginaTipoUsuarios>();
        }

        public int Iidpagina { get; set; }
        public string Mensaje { get; set; }
        public string Accion { get; set; }
        public string Controlador { get; set; }
        public int Bhabilitado { get; set; }

        public virtual ICollection<PaginaTipoUsuarios> PaginaTipoUsuarios { get; set; }
    }
}
