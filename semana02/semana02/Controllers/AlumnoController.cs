
using semana02.Models.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace semana02.Controllers
{
    public class AlumnoController : Controller
    {
        static List<Alumno> alumnos = new List<Alumno>();
        // GET: Alumno
        public ActionResult Index1()
        {
            Alumno alumno = new Alumno("123", "Informatica", "Tecnologica");
            return View(alumno); //A la vista estamos enviando un objeto de tipo Alumno (alumno)
        }

        public ActionResult Index2()
        {
            Alumno alumno = new Alumno("123", "Informatica", "Tecnologica");
            return View(alumno); //A la vista estamos enviando un objeto de tipo Alumno (alumno)
        }

        public ActionResult Create()
        {
            return View(new Alumno());
        }

        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {

            if (alumno.validarCampos())
            {
                alumnos.Add(alumno);
                ViewBag.mensaje = "El Alumno se guardo de manera exitosa";
                return View(alumno);
            }
            ViewBag.mensaje = "No se paso la validación";
            return View(alumno);
        }

        public ActionResult Index()
        {
            return View(alumnos);
        }
    }
}