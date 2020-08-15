using System;
using System.Collections.Generic;

namespace CompratodoUI.Models
{
    public partial class Vendedores
    {
        public Vendedores()
        {
            Productos = new HashSet<Productos>();
        }

        public long Iidvendedor { get; set; }
        public int Iidtipousuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefonocelular { get; set; }
        public string Nombreusuario { get; set; }
        public string Contraseña { get; set; }
        public int Bhabilitado { get; set; }

        public virtual TipoUsuarios IidtipousuarioNavigation { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
