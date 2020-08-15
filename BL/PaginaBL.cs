using CompratodoUI.DAL;
using CompratodoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.BL
{
    public class PaginaBL
    {
        PaginaDAL dal = new PaginaDAL();
        public int guardar(Paginas paginas)
        {
            return dal.guardar(paginas);
        }
        public static List<Paginas> menuDinamico(int idUsuario)
        {
            return PaginaDAL.menuDinamico(idUsuario);
        }
        public bool eliminar(int id)
        {
            return dal.eliminar(id);
        }
        public Paginas obtenerPorId(int id)
        {
            return dal.obtenerPorId(id);
        }
        public List<Paginas> listar()
        {
            return dal.listar();
        }
    }
}
