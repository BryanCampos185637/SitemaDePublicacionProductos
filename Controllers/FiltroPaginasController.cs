using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompratodoUI.Models;
using CompratodoUI.DAL;
using System.Net.Mail;

namespace CompratodoUI.Controllers
{
    public class FiltroPaginasController : Controller
    {
        /// <summary>
        /// este metodo funciona como filtro para evitar que los usuarios accedan mediante url
        /// </summary>
        /// <param name="controlador">pasamos el nombre del controlador</param>
        /// <param name="accion">El nombre de la accion</param>
        /// <param name="idUsuario">y el id del usuario logueado para obtener su tipo de usuario</param>
        /// <returns></returns>
        public static bool puedeVerEstaPagina(string controlador, string accion, int idUsuario)
        {
            int existe = 0;
            try
            {
                using(var bd = new BDCatalogoContext())
                {
                    var tipoUsuario = bd.Vendedores.Where(p => p.Iidvendedor == idUsuario).First().Iidtipousuario;//capturamos el tipo de usuario de la cokie
                    existe = (from ptu in bd.PaginaTipoUsuarios
                              join pagina in bd.Paginas on ptu.Iidpagina equals pagina.Iidpagina
                              where pagina.Accion.ToLower() == accion.ToLower() &&
                              pagina.Controlador.ToLower() == controlador.ToLower() &&
                              ptu.Iidtipousuario == tipoUsuario && ptu.Bhabilitado==1
                              select new Paginas { Iidpagina=pagina.Iidpagina }).Count();
                    if (existe > 0)//si el tipo de usuario tiene relacionada esa pagina se retorna un true
                        return true;
                    else//de lo contrario un false
                        return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public int recuperarContraseña(string nombreUsuario)
        {
            string origen = "ch18.009.001@gmail.com";
            string contrasena = "bryan185637";
            string destino = "";
            try
            {
                using (var bd = new BDCatalogoContext())
                {
                    string contraseña = "";
                    var data = bd.Vendedores.Where(p => p.Nombreusuario.Equals(nombreUsuario)).FirstOrDefault();
                    if (data != null)
                    {
                        contraseña = generarCodigo();
                        data.Contraseña = Utilidades.cifrarContraseña(contraseña);//le cambiamos la contraseña
                        bd.SaveChanges();
                        destino = data.Correo;//buscamos su correo
                        //empezamos a redactar el correo
                        string asunto = "Recuperar contraseña";
                        string mensaje = "<p>Hola " + data.Nombre + " " + data.Apellidos + " tu contraseña nueva es " + contraseña + " se te recomienda cambiarla cuando hayas iniciado sesion.</p><br><p>Atentamente:compratodo.somee.com</p>";
                        MailMessage mailMessage = new MailMessage(origen, destino, asunto, mensaje);
                        mailMessage.IsBodyHtml = true;//habilitamos etiquetas html
                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");//el host de gmail por donde se enviara el correo
                        smtpClient.EnableSsl = true;//que vaya sellado
                        smtpClient.UseDefaultCredentials = false;
                        //smtpClient.Host = "smtp.gmail.com";
                        smtpClient.Port = 587;
                        smtpClient.Credentials = new System.Net.NetworkCredential(origen, contrasena);
                        smtpClient.Send(mailMessage);//enviamos
                        smtpClient.Dispose();//que se elimine todo
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                return 0;
            }

        }

        public string generarCodigo()
        {
            string codigoGenerado = "";
            string[] alfabeto = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9","a","b","c",
                "d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
            for(var i = 0; i < 10; i++)
            {
                Random random = new Random();
                int posicion = random.Next(0, alfabeto.Length);
                codigoGenerado += alfabeto[posicion];
            }
            return codigoGenerado;
        }
    }
}
