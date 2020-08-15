using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CompratodoUI.Models;
using CompratodoUI.BL;
using Microsoft.AspNetCore.Http;

namespace CompratodoUI.Controllers
{
    public class HomeController : Controller
    {
        Int64 usuarioid = 0;
        public IActionResult Index()
        {
            usuarioid = Convert.ToInt32(HttpContext.Session.GetString("usuario"));
            ViewBag.id = usuarioid;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ErrorPermiso()
        {
            return View();
        }
        public JsonResult loging(string user, string contra)
        {
            int result = 0;
            VendedorBL bl = new VendedorBL();
            var data = bl.login(user, contra);
            if (data != null)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            return Json(result);
        }
    }
}
