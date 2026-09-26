using examenT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examenT1.Controllers
{
    public class AdministrativoController : Controller
    {
        static List<Administrativo> administrativos = new List<Administrativo>();
        public ActionResult RegistrarAdministrativo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarAdministrativo(Administrativo administrativo)
        {
            administrativos.Add(administrativo);
            ViewBag.Mensaje = "Se guardo de manera correcta";
            return View(administrativo);
        }
    }
}