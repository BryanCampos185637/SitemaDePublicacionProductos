using CompratodoUI.BE;
using CompratodoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace CompratodoUI.DAL
{
    public class ProductoDAL
    {
        int result;
        public bool eliminar(Int64 id)
        {
            using(var bd = new BDCatalogoContext())
            {
                var data = bd.Productos.Where(p => p.Iidproducto.Equals(id)).First();
                data.Bhabilitado = 0;
                result = bd.SaveChanges();
                if (result > 0) return true;
                else return false;
            }
        }
        public int guardar(Productos productos)
        {
            try
            {
                using(var bd = new BDCatalogoContext())
                {
                    if (productos.Iidproducto.Equals(0))//guarda
                    {
                        productos.Estadoventa = 1;
                        productos.Bhabilitado = 1;
                        bd.Productos.Add(productos);
                        bd.SaveChanges();
                        return 1;
                    }
                    else//modifica
                    {
                        var data = bd.Productos.Where(p => p.Iidproducto.Equals(productos.Iidproducto)).First();
                        data.Nombre = productos.Nombre;
                        data.Foto = productos.Foto;
                        data.Descripcion = productos.Descripcion;
                        data.Iidcategoria = productos.Iidcategoria;
                        data.Precio = productos.Precio;
                        data.Iidvendedor = productos.Iidvendedor;
                        bd.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<ProductoCLS> listar(string nombre)
        {
            List<ProductoCLS> lista = new List<ProductoCLS>();
            using (var bd = new BDCatalogoContext())
            {
                if (nombre == "" || nombre == null)
                {
                    lista = (from p in bd.Productos
                             join c in bd.Categorias on p.Iidcategoria equals c.Iidcategoria
                             join v in bd.Vendedores on p.Iidvendedor equals v.Iidvendedor
                             where p.Bhabilitado == 1 && p.Estadoventa == 1 && v.Bhabilitado == 1
                             select new ProductoCLS
                             {
                                 id = p.Iidproducto,
                                 nombre = p.Nombre,
                                 precio = p.Precio,
                                 foto = p.Foto,
                                 nombrecategoria = c.Nombre,
                                 idcategoria = p.Iidcategoria,
                                 descripcion = p.Descripcion == null ? "" : p.Descripcion,
                                 nombreusuario = v.Nombre + " " + v.Apellidos,
                                 tel = v.Telefonocelular == null ? "" : v.Telefonocelular,
                                 correo = v.Correo == null ? "" : v.Correo,
                                 idvendedor = (int)v.Iidvendedor
                             }).ToList();
                }
                else
                {
                    if (nombre.Length >= 3)//solo se va a ejecutar cuando el nombre tenga 3 letras
                    {
                        lista = (from p in bd.Productos
                                 join c in bd.Categorias on p.Iidcategoria equals c.Iidcategoria
                                 join v in bd.Vendedores on p.Iidvendedor equals v.Iidvendedor
                                 where p.Bhabilitado == 1 && p.Estadoventa == 1
                                 && (p.Nombre.Contains(nombre) || c.Nombre.Equals(nombre))
                                 select new ProductoCLS
                                 {
                                     id = p.Iidproducto,
                                     nombre = p.Nombre,
                                     precio = p.Precio,
                                     foto = p.Foto,
                                     nombrecategoria = c.Nombre,
                                     idcategoria = p.Iidcategoria,
                                     descripcion = p.Descripcion == null ? "" : p.Descripcion,
                                     nombreusuario = v.Nombre + " " + v.Apellidos,
                                     tel = v.Telefonocelular == null ? "" : v.Telefonocelular,
                                     correo = v.Correo == null ? "" : v.Correo,
                                     idvendedor = (int)v.Iidvendedor
                                 }).ToList();
                    }
                }
            }
            lista = lista.OrderByDescending(x => x.id).ToList();
            return lista;
        }//lista de catalogo
        public List<ProductoCLS> productosPorVendedor(int id)
        {
            List<ProductoCLS> lista = new List<ProductoCLS>();
            using (var bd = new BDCatalogoContext())
            {
                if (menuDinamico.sesionActiva!=null && menuDinamico.sesionActiva==1)
                {
                    lista = (from p in bd.Productos
                             join c in bd.Categorias on p.Iidcategoria equals c.Iidcategoria
                             join v in bd.Vendedores on p.Iidvendedor equals v.Iidvendedor
                             where p.Bhabilitado == 1
                             select new ProductoCLS
                             {
                                 id = p.Iidproducto,
                                 nombre = p.Nombre,
                                 precio = p.Precio,
                                 foto = p.Foto,
                                 nombrecategoria = c.Nombre,
                                 idcategoria = p.Iidcategoria,
                                 descripcion = p.Descripcion == null ? "" : p.Descripcion,
                                 nombreusuario = v.Nombre + " " + v.Apellidos,
                                 tel = v.Telefonocelular == null ? "" : v.Telefonocelular,
                                 correo = v.Correo == null ? "" : v.Correo,
                                 estadoventa=(int) p.Estadoventa
                             }).ToList();
                }
                else
                {
                    lista = (from p in bd.Productos
                             join c in bd.Categorias on p.Iidcategoria equals c.Iidcategoria
                             join v in bd.Vendedores on p.Iidvendedor equals v.Iidvendedor
                             where p.Bhabilitado == 1 && p.Iidvendedor.Equals(id)
                             select new ProductoCLS
                             {
                                 id = p.Iidproducto,
                                 nombre = p.Nombre,
                                 precio = p.Precio,
                                 foto = p.Foto,
                                 nombrecategoria = c.Nombre,
                                 idcategoria = p.Iidcategoria,
                                 descripcion = p.Descripcion == null ? "" : p.Descripcion,
                                 nombreusuario = v.Nombre + " " + v.Apellidos,
                                 tel = v.Telefonocelular == null ? "" : v.Telefonocelular,
                                 correo = v.Correo == null ? "" : v.Correo,
                                 estadoventa = (int)p.Estadoventa
                             }).ToList();
                }
            }
            //lista = lista.OrderByDescending(z => z.id).ToList();
            return lista;
        }//los productos del usuario que inicio sesion
        public Productos obtenerPorId(int id)
        {
            try
            {
                using(var bd = new BDCatalogoContext())
                {
                    var data = bd.Productos.Where(p => p.Iidproducto.Equals(id)).First();
                    return data;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }//detalles del producto
        public bool cambiarEstado(int id)//para cambiar el estado de venta
        {
            try
            {
                using (var bd = new BDCatalogoContext())
                {
                    Productos data = bd.Productos.Where(x => x.Iidproducto == id).First();
                    if (data.Estadoventa == 1)
                        data.Estadoventa = 0;
                    else
                        data.Estadoventa = 1;
                    bd.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool vetarProducto(Int64 id)
        {
            using (var bd = new BDCatalogoContext())
            {
                int bhabilitadoProducto = 0;//nos servira para saber el estado del producto
                try//lo introducimos a un bloque try por cualquier exepcion que pueda ocurrir
                {
                    using (var transaccion = new TransactionScope())
                    {
                        var data = bd.Productos.Where(p => p.Iidproducto.Equals(id)).First();//obtenemos el producto a vetar                                     
                        if (data.Bhabilitado == 1)//vamos a validar el estado del producto
                            data.Bhabilitado = 2;//para mi dos sera que esta vetado
                        else if (data.Bhabilitado == 2)
                            data.Bhabilitado = 1;
                        bhabilitadoProducto = data.Bhabilitado;//guardamos el valor del bhabilitado para ver si se agregara la notificacion
                        bd.SaveChanges();//confirmamos guardado del estado
                        //a continuacion agregamos la notificacion siempre y cuando el valor del bhabilitado del producto sea 2
                        if (bhabilitadoProducto == 2)
                        {
                            var productoVetado = bd.Denuncias.Where(p => p.Iidproducto.Equals(data.Iidproducto)).First();//obtenemos el registro de la denuncia
                            var nveces = bd.Notificaciones.Where(p => p.Iiddenuncia.Equals(productoVetado.Iiddenuncia)).Count();//veremos si ya existe una notificacion con el id de la denuncia
                            if (nveces == 0) // si no hay ninguna coincidencia procedemos a crear el registros
                            { 
                            Notificaciones notificaciones = new Notificaciones();//hacemos una instancia del modelo
                            notificaciones.Iiddenuncia = productoVetado.Iiddenuncia;//agregamos el id de la denuncia
                            notificaciones.Notificacionleida = 0;//cero para mi significa que no a visto la notificacion
                            bd.Notificaciones.Add(notificaciones);//mandamos a guardar la data
                            bd.SaveChanges();//completamos el guardado
                            }
                        }
                        //si todo esta bien cerramos la transaccion
                        transaccion.Complete();
                        //si llego hasta aqui es porque no hubo error
                        return true;
                    }
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }
    }
}
