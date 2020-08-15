using CompratodoUI.BE;
using CompratodoUI.DAL;
using CompratodoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.BL
{
    public class DenunciaBL
    {
        DenunciaDAL dal = new DenunciaDAL();
        public int guardarDenuncia(Denuncias denuncias)
        {
            return dal.guardarDenuncia(denuncias);
        }
        public List<DenunciaCLS> listar()
        {
            return dal.listaDenuncias();
        }
    }
}
