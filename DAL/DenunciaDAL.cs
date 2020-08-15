using CompratodoUI.BE;
using CompratodoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompratodoUI.DAL
{
    public class DenunciaDAL
    {
        public int guardarDenuncia(Denuncias denuncias)
        {
            try
            {
                using (var bd = new BDCatalogoContext())
                {
                    int ndenuncias = bd.Denuncias.Where(p => p.Iidproducto.Equals(denuncias.Iidproducto)).Count();
                    if (ndenuncias > 0)// si ya hay un registro con el id del producto lo unico que haremos es incrementar el contador
                    {
                        var data = bd.Denuncias.Where(p => p.Iidproducto.Equals(denuncias.Iidproducto)).First();
                        data.Motivo = denuncias.Motivo;
                        data.Ndenuncias = (Int64)data.Ndenuncias + 1;
                        bd.SaveChanges();
                        return 1;
                    }
                    else//si no existe agregamos el registro y le ponemos en valor a ndenuncias
                    {
                        denuncias.Ndenuncias = 1;
                        bd.Denuncias.Add(denuncias);
                        bd.SaveChanges();
                        return 1;
                    }
                }
            }
            catch(Exception e)
            {
                string mensaje = e.Message;
                return 0;
            }
        }
        public List<DenunciaCLS> listaDenuncias()
        {
            using (var bd = new BDCatalogoContext())
            {
                var lista = (from denuncia in bd.Denuncias
                             join producto in bd.Productos
                             on denuncia.Iidproducto equals producto.Iidproducto
                             join vendedor in bd.Vendedores
                             on producto.Iidvendedor equals vendedor.Iidvendedor
                             where producto.Bhabilitado == 1 || producto.Bhabilitado==2
                             select new DenunciaCLS
                             {
                                 id = denuncia.Iiddenuncia,
                                 motivo = denuncia.Motivo,
                                 idproducto = producto.Iidproducto,
                                 idvendedor = vendedor.Iidvendedor,
                                 nombreproducto = producto.Nombre,
                                 nombrevendedor = vendedor.Nombre + " " + vendedor.Apellidos,
                                 denuncias = (Int64)denuncia.Ndenuncias,
                                 bhabilitadop = producto.Bhabilitado,
                                 bhabilitadov = vendedor.Bhabilitado
                             }).ToList();
                lista = lista.OrderByDescending(x=>x.id).ToList();
                return lista;
            }
        }
    }
}
