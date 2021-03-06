﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompratodoUI.Models;
using Microsoft.AspNetCore.Http;
using CompratodoUI.BL;

namespace CompratodoUI.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaBL bl = new CategoriaBL();
        public IActionResult Index()
        {
            int idUsuario = 0;//variable que utilizaremos para verificar
            idUsuario = Convert.ToInt32(HttpContext.Session.GetString("usuario"));//capturamos el id del usuario
            if (idUsuario > 0)//si existe el id
            {
                if (FiltroPaginasController.puedeVerEstaPagina("categoria", "index",idUsuario))//SI ESTA RELACIONADA LA VISTA CON EL TIPO DE USUARIO DAMOS ACCESO
                {
                    return View();
                }
                else//SI NO TIENE ASIGNADA LA VISTA LO ENVIAMOS A UNA VISTA DE ERROR
                {
                    return Redirect("/home/ErrorPermiso");
                }
            }
            else//si no existe el id obligar login
            {
                return Redirect("/vendedor/index");
            }
        }
        [HttpGet]
        public List<Categorias> listar()
        {
            return bl.listar();
        }
        [HttpGet]
        public Categorias obtenerPorId(int id)
        {
            Categorias data = bl.obtenerPorId(id);
            return data;
        }
        public bool eliminar(int id)
        {
            return bl.eliminar(id);
        }
        public int guardar(Categorias categoria)
        {
            categoria.Bhabilitado = 1;
            return bl.guardar(categoria);
        }
    }
}
