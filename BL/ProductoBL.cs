using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompratodoUI.BE;
using CompratodoUI.DAL;
using CompratodoUI.Models;

namespace CompratodoUI.BL
{
    public class ProductoBL
    {
        ProductoDAL dal = new ProductoDAL();
        public bool cambiarEstado(int id)
        {
            return dal.cambiarEstado(id);
        }
        public bool vetarProducto(Int64 id)
        {
            return dal.vetarProducto(id);
        }
        public List<ProductoCLS> listar(string nombre)
        {
            return dal.listar(nombre);
        }
        public Productos obtenerPorId(int id)
        {
            return dal.obtenerPorId(id);
        }
        public int guardar(Productos productos)
        {
            return dal.guardar(productos);
        }
        public List<ProductoCLS> productosPorVendedor(int id)
        {
            return dal.productosPorVendedor(id);
        }
        public bool eliminar(Int64 id)
        {
            return dal.eliminar(id);
        }
    }
}
