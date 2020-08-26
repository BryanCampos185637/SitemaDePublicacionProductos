using CompratodoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.BE
{
    public class menuDinamico
    {
        public static int? sesionActiva { get; set; }
        public static List<Paginas> menu { get; set; }
    }
}
