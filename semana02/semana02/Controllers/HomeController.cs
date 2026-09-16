using semana02.Models.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace semana02.Controllers
{
    public class HomeController : Controller
    {
        static Persona personaGeneral = new Persona();
        public ActionResult Index()
        {
            /*
            Persona persona = new Persona();
            persona.id = 1;
            persona.nombres = "Miguel A.";
            persona.apellidos = "Berrio H.";
            persona.nombreCompleto(); // Miguel A. Berrio H.
            Persona2 persona2 = (Persona2) persona;
            persona2.nombreCompleto(); // Berrio H., Miguel A*/
            return View(new Persona());
        }

        [HttpPost]  //Get -> Mostrar una vista
        //Post -> Enviar datos dentro del cuerpo y no necesariamente mostrar vistas
        public ActionResult Index(Persona persona)
        {
            personaGeneral = persona;
            return View();
        }

        [HttpGet]
        public ActionResult guardarPersona()
        {
            ViewBag.valorGuardado = personaGeneral.nombreCompleto();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}