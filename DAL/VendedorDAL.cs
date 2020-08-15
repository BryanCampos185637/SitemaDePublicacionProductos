using CompratodoUI.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompratodoUI.Models;
namespace CompratodoUI.DAL
{
    public class VendedorDAL
    {
        BDCatalogoContext bd;
        int result = 0;
        public int guardar(Vendedores vendedorCLS)
        {
            try
            {
                using(bd= new BDCatalogoContext())
                {
                    int nveces = 0;
                    int nvecescorreo = 0;
                    nveces = bd.Vendedores.Where(p => p.Nombreusuario.Equals(vendedorCLS.Nombreusuario) && p.Bhabilitado==1 && p.Iidvendedor!=vendedorCLS.Iidvendedor).Count();
                    nvecescorreo= bd.Vendedores.Where(p => p.Correo.Equals(vendedorCLS.Correo) && p.Bhabilitado == 1 && p.Iidvendedor != vendedorCLS.Iidvendedor).Count();
                    if (nveces == 0)// si no hay ningun nombre usuario parecido en la bd procedemos a validar el correo
                    {
                        if (nvecescorreo == 0)//si no hay otro correo igual procedemos a guardar el registro
                        {
                            if (vendedorCLS.Iidvendedor == 0)
                            {
                                vendedorCLS.Contraseña = Utilidades.cifrarContraseña(vendedorCLS.Contraseña);//ciframos la contraseña en sha256
                                bd.Vendedores.Add(vendedorCLS);
                                result = bd.SaveChanges();
                            }
                            else
                            {
                                Vendedores data = bd.Vendedores.Where(p => p.Iidvendedor.Equals(vendedorCLS.Iidvendedor)).First();
                                data.Nombre = vendedorCLS.Nombre;
                                data.Apellidos = vendedorCLS.Apellidos;
                                if (vendedorCLS.Contraseña != "" && vendedorCLS.Contraseña != null)
                                {
                                    data.Contraseña = Utilidades.cifrarContraseña(vendedorCLS.Contraseña);//ciframos la contraseña en sha256
                                }
                                if (vendedorCLS.Telefonocelular != null) { data.Telefonocelular = vendedorCLS.Telefonocelular; }
                                if (vendedorCLS.Iidtipousuario > 0) { data.Iidtipousuario = vendedorCLS.Iidtipousuario; }
                                bd.SaveChanges();
                                return 1;
                            }
                        }
                        else
                        {
                            return -2;
                        }//fin validacion correo
                    }
                    else
                    {
                        return -1;
                    }//fin validacion nombre usuario
                }
            }
            catch(Exception e)
            {
                string m = e.Message;
                result = 0;
            }
            return result;
        }
        public Vendedores obtenerPorId(Int64 id)
        {
            using(bd = new BDCatalogoContext())
            {
                var data = bd.Vendedores.Where(x => x.Iidvendedor.Equals(id)).First();
                return data;
            }
        }
        public bool vetarVendedor(Int64 id)
        {
            try
            {
                using (bd = new BDCatalogoContext())
                {
                    var data = bd.Vendedores.Where(p => p.Iidvendedor.Equals(id)).First();
                    if (data.Bhabilitado == 1)
                        data.Bhabilitado = 2;//para mi dos sera que esta vetado
                    else if (data.Bhabilitado == 2)
                        data.Bhabilitado = 1;
                    result = bd.SaveChanges();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public Vendedores login(string usuario, string contraseña)
        {
            try
            {
                using (bd = new BDCatalogoContext())
                {
                    var data = bd.Vendedores.Where(x => x.Nombreusuario.Equals(usuario)).FirstOrDefault();
                    if (data != null)
                    {//validamos que el usuario coincida o exista
                        if (data.Contraseña.Equals(contraseña = Utilidades.cifrarContraseña(contraseña)))
                        {//si existe validamos que las contraseñas concuerden
                            return data;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public List<VendedorCLS> listar()
        {
            List<VendedorCLS> lista = new List<VendedorCLS>();
            using(var bd = new BDCatalogoContext())
            {
                lista = (from vendedor in bd.Vendedores
                         join tipousuario in bd.TipoUsuarios on vendedor.Iidtipousuario equals tipousuario.Iidtipousuario
                         where vendedor.Bhabilitado !=0
                         select new VendedorCLS
                         {
                             id=(int)vendedor.Iidvendedor,
                             nombre=vendedor.Nombre,
                             apellidos=vendedor.Apellidos,
                             nombretipousuario=vendedor.Nombreusuario,
                             tipousuario=vendedor.Iidtipousuario,
                             correo=vendedor.Correo,
                             bhabilitado=vendedor.Bhabilitado
                         }).ToList();
            }
            lista = lista.OrderByDescending(x => x.id).ToList();
            return lista;
        }
    }
}
