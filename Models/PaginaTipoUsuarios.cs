using System;
using System.Collections.Generic;

namespace CompratodoUI.Models
{
    public partial class PaginaTipoUsuarios
    {
        public int Iidpaginatipousuario { get; set; }
        public int Iidpagina { get; set; }
        public int Iidtipousuario { get; set; }
        public int Bhabilitado { get; set; }

        public virtual Paginas IidpaginaNavigation { get; set; }
        public virtual TipoUsuarios IidtipousuarioNavigation { get; set; }
    }
}
