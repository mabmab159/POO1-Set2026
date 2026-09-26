using semana03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace semana03.Controllers
{
    public class EmpleadoController : Controller
    {
        //CRUD Completo - Manejar colecciones
        static List<Empleado> empleados = new List<Empleado>()
        {
            new Empleado(1, "Miguel", "E2", 0, "Indefinido")
        };
        public ActionResult Index()
        {
            return View(empleados);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            empleados.Add(empleado);
            ViewBag.Mensaje = "Empleado creado";
            return View(empleado);
        }

        public ActionResult Details(int id)
        {
            //Buscar en mi arreglo el empleado con el id -> Mostrarlo en la vista
            Empleado empleadoEncontrado = empleados.Find(e => e.idEmpleado == id);
            return View(empleadoEncontrado);
        }

        public ActionResult Edit(int id)
        {
            Empleado empleadoEncontrado = empleados.Find(e => e.idEmpleado == id);
            return View(empleadoEncontrado);
        }

        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {
            int index = empleados.FindIndex(e => e.idEmpleado == empleado.idEmpleado);
            if(index == -1)
            {
                //No encontro el elemento
                ViewBag.Mensaje = "Elemento no encontrado";
            }
            empleados[index] = empleado;
            ViewBag.Mensaje = "Elemento actualizado";
            return View(empleado);
        }
    }
}