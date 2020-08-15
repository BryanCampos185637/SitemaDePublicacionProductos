using CompratodoUI.DAL;
using CompratodoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.BL
{
    public class TipoUsuarioBL
    {
        TipoUsuarioDAL dal = new TipoUsuarioDAL();
        public List<Paginas> listarPaginasAsignadas(Int64 id)
        {
            return dal.listarPaginasAsignadas(id);
        }
        public int guardar(TipoUsuarios tipoUsuarios, int[] idPaginas)
        {
            return dal.guardar(tipoUsuarios, idPaginas);
        }
        public List<TipoUsuarios> listar()
        {
            return dal.listar();
        }
        public TipoUsuarios obtenerPorId(int id)
        {
            return dal.obtenerPorId(id);
        }
        public bool eliminar(int id)
        {
            return dal.eliminar(id);
        }
    }
}
