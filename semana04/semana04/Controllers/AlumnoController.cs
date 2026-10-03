using Newtonsoft.Json;
using semana04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace semana04.Controllers
{
    public class AlumnoController : Controller
    {
        static Alumno alumno = new Alumno(1, "Miguel", "Berrio", "Engineer Software");
        static string jAlumno = @"{'id':1, 'name':'Miguel', 
            'lastname':'Berrio', 'profession': 'Engineer Software'}";

        static string jlistAlumnos = @"[{'id':1, 'name':'Miguel', 
            'lastname':'Berrio', 'profession': 'Engineer Software'}, {'id':2, 'name':'Miguel', 
            'lastname':'Berrio', 'profession': 'Engineer Software'}]";

        public ActionResult Index()
        {
            try
            {
                List<Alumno> listIntermedia = JsonConvert.DeserializeObject<List<Alumno>>(jlistAlumnos);
                return View(listIntermedia);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }

        public ActionResult DeserializacionAlumno(int id = 0)
        {
            string mensaje = string.Empty;
            if (id == 0) return View();
            try
            {
                Alumno alumnoLocal = JsonConvert.DeserializeObject<Alumno>(jAlumno); //Riesgo de error;
                return View(alumnoLocal);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            ViewBag.mensaje = mensaje;
            return View();
        }

        public ActionResult SerializacionAlumno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SerializacionAlumno(Alumno alumno)
        {
            string mensaje = string.Empty;
            try
            {
                jAlumno = JsonConvert.SerializeObject(alumno); //Riesgo de error;
                mensaje = "Serializado de manera correcta";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            ViewBag.mensaje = mensaje;
            return View(alumno);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            try
            {
                // 1. Recuperar el string jlistAlumnos y Deserealizarlo -> List<Alumno> temporal
                List<Alumno> temporal = JsonConvert.DeserializeObject<List<Alumno>>(jlistAlumnos);
                // 2. Agregar mi alumnoNuevo a la List<Alumno> deserealizada previamente
                temporal.Add(alumno);
                // 3. Serializar la lista y sobreescribir sobre jlistAlumnos;
                jlistAlumnos = JsonConvert.SerializeObject(temporal);
                ViewBag.Mensaje = "Guardado de manera exitosa";
                return View(alumno);
            }
            catch (JsonException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }

        // Reto 10 min -> Hacer el ActionResult de Details

        public ActionResult Edit(int id)
        {
            // 1. Deserializar el string jlistAlumno -> List<Alumno> temporal
            List<Alumno> temporal = JsonConvert.DeserializeObject<List<Alumno>>(jlistAlumnos);
            // 2. Buscar el objeto en la lista
            Alumno alumnoEncontrado = temporal.Find(a => a.id == id);
            return View(alumnoEncontrado);
        }

        [HttpPost]
        public ActionResult Edit(Alumno alumno)
        {
            // 1. Deserializar el string jlistAlumno -> List<Alumno> temporal
            List<Alumno> temporal = JsonConvert.DeserializeObject<List<Alumno>>(jlistAlumnos);
            // 2. Buscar en temporal el elemento por el id
            int index = temporal.FindIndex(a => a.id == alumno.id);
            // 3. Editar el elemento de dicha posicion por el nuevo alumno
            temporal[index] = alumno;
            // 4. Serializar de List<Alumno> -> string jlistAlumno
            jlistAlumnos = JsonConvert.SerializeObject(temporal);
            ViewBag.Mensaje = "Alumno actualizado";
            return View(alumno);
        }

        // Reto - Realizar el ActionResult Delete
    }
}