using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompratodoUI.Models;
using CompratodoUI.DAL;
using CompratodoUI.BE;

namespace CompratodoUI.BL
{
    public class VendedorBL
    {
        VendedorDAL dal = new VendedorDAL();
        public int guardar(Vendedores vendedores)
        {
            return dal.guardar(vendedores);
        }
        public Vendedores perfil(Int64 id)
        {
            return dal.obtenerPorId(id);
        }
        public bool vetarVendedor(Int64 id)
        {
            return dal.vetarVendedor(id);
        }
        public Vendedores login(string usuario, string contraseña)
        {
            return dal.login(usuario, contraseña);
        }
        public List<VendedorCLS> listar()
        {
            return dal.listar();
        }
    }
}
