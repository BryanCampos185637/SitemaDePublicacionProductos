using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CompratodoUI.DAL
{
    public class Utilidades
    {
        public static string cifrarContraseña(string clave)
        {
            string contraseñaCifrada = "";
            try
            {
                SHA256Managed sha = new SHA256Managed();//instancia
                byte[] dataNoCifrada = Encoding.Default.GetBytes(clave);//convertimos a arreglo de byte la contraseña
                byte[] dataCifrada = sha.ComputeHash(dataNoCifrada);//pasamos el array de byte para cifrar
                contraseñaCifrada = BitConverter.ToString(dataCifrada);//convertimos a texto
                contraseñaCifrada = contraseñaCifrada.Replace("-", "");//reemplazamos los - por vacios
                return contraseñaCifrada;//retornamos la contraseña en una cadena hexadecimal
            }
            catch (Exception e) 
            { 
                return ""; 
            }
        }
    }
}
