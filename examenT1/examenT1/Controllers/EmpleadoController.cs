using examenT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examenT1.Controllers
{
    public class EmpleadoController : Controller
    {
        static List<Empleado> empleados = new List<Empleado>()
        {
            new Empleado("1", "Miguel", "E1", 2, "Indefinido"),
            new Empleado("1", "Miguel", "E1", 2, "Indefinido"),
            new Empleado("1", "Miguel", "E1", 2, "Indefinido"),
            new Empleado("1", "Miguel", "E1", 2, "Indefinido")
        };
        public ActionResult RegistrarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarEmpleado(Empleado empleado)
        {
            empleados.Add(empleado);
            ViewBag.mensaje = "Empleado";
            return View(empleado);
        }

        public ActionResult Planilla()
        {
            return View(empleados);
        }
    }
}