using CompratodoUI.DAL;
using CompratodoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.BL
{
    public class CategoriaBL
    {
        //BL= Bussines Logic
        CategoriaDAL dal = new CategoriaDAL();
        public List<Categorias> listar()
        {
            return dal.listar();
        }
        public Categorias obtenerPorId(int id)
        {
            return dal.obtenerPorId(id);
        }
        public bool eliminar(int id)
        {
            return dal.eliminar(id);
        }
        public int guardar(Categorias categoria)
        {
            return dal.guardar(categoria);
        }
    }
}
