using semana01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace semana01.Controllers
{
    //: extends o implements
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Alumno alumno = new Alumno();
            alumno.nombre = "Miguel";
            alumno.apellido = "Berrio";
            alumno.id = 1;
            alumno.email = "pmberrio@cibertec.edu.pe";
            string nombreCompleto = alumno.nombreCompleto();
            ViewBag.nombreCompleto = nombreCompleto;
            return View();
        } // Home/Index

        public ActionResult About() // Home/About
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() // Home/Contact
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Son las vistas o logica de los endpoints o rutas //Homa/Hola
        public ActionResult Hola()
        {
            return View();
        }
    }
}