using Newtonsoft.Json;
using semana05.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace semana05.Controllers
{
    public class PruebaController : Controller
    {
        static string rutaCarpeta = "~/carpeta";
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Estudiante estudiante)
        {
            //estudiante = Objeto
            //1. Serializar el objeto -> string
            string objetoSerializado = JsonConvert.SerializeObject(estudiante);
            //2. Abrir o acceder al archivo donde vas a trabajar
            FileStream fileStream = new FileStream($"{Server.MapPath(rutaCarpeta)}/prueba.txt",FileMode.Create);
            // ~/carpeta/prueba.txt -> Usando Server.MapPath -> C/Users/root/semana05/carpeta/..
            //3. Escribir en el archivo
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(objetoSerializado);
            //4. Cerrar el modo escritura del archivo
            streamWriter.Close();
            //5. Cerrar el archivo
            fileStream.Close();
            ViewBag.Mensaje = "Estudiante registrado";
            return View(estudiante);
        }

        public ActionResult Details(int id = 0)
        {
            // Leer un archivo
            // 1. Abrir o encontrar el archivo donde esta la información
            FileStream fileStream = new FileStream($"{Server.MapPath(rutaCarpeta)}/lista.txt",FileMode.Open);
            // 2. Leer el archivo -> string
            StreamReader streamReader = new StreamReader(fileStream);
            // 3. Deserializar: string -> Objeto
            List<Estudiante> estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(streamReader.ReadToEnd());
            // 4. Realizar las operaciones
            Estudiante estudianteEncontrado = estudiantes.Find(e => e.id == id);
            // 5. Cerrar el lector de archivos
            streamReader.Close();
            // 6. Cerrar el archivo
            fileStream.Close();
            return View(estudianteEncontrado);
        }

        // CRUD -> Create -> FileStream y StreamWriter - OK
        // Details -> FileStream y StreamReader - OK
        // Update -> FileStream, StreamWriter y StreamReader - Reto -> 9:10 Update
        // Delete -> FileStream, StreamWriter y StreamReader - Profe

        public ActionResult Delete(int id = 0)
        {
            // Leer un archivo
            // 1. Abrir o encontrar el archivo donde esta la información
            FileStream fileStream = new FileStream($"{Server.MapPath(rutaCarpeta)}/lista.txt", FileMode.Open);
            // 2. Leer el archivo -> string
            StreamReader streamReader = new StreamReader(fileStream);
            // 3. Deserializar: string -> Objeto
            List<Estudiante> estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(streamReader.ReadToEnd());
            // 4. Realizar las operaciones
            Estudiante estudianteEncontrado = estudiantes.Find(e => e.id == id);
            // 5. Cerrar el lector de archivos
            streamReader.Close();
            // 6. Cerrar el archivo
            fileStream.Close();
            return View(estudianteEncontrado);
        }

        [HttpPost]
        public ActionResult Delete(Estudiante estudiante)
        {
            // 1. Recuperar el archivo -> FileStream
            FileStream fileStream = new FileStream($"{Server.MapPath(rutaCarpeta)}/lista.txt", FileMode.Open);
            //FileStream fileStream = new FileStream($"{Server.MapPath(rutaCarpeta)}/lista.txt", FileMode.OpenOrCreate); //Read
            // OpenOrCreate -> Pide permisos de lectura y de escritura -> Abre el archivo si existe, si no existe lo crea
            // 2. Abro el objeto de lectura -> StreamReader
            StreamReader streamReader = new StreamReader(fileStream);
            // 3. Recupero la informacion de la lectura en memoria
            string informacion = streamReader.ReadToEnd();
            // 3.1 Deserializo la información
            List<Estudiante> estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(informacion);
            // 4. Realizo mis operaciones
            int index = estudiantes.FindIndex(e => e.id == estudiante.id);
            estudiantes.RemoveAt(index);
            // 5. Cierro el objeto de lectura
            streamReader.Close();
            fileStream.Close();
            fileStream = new FileStream($"{Server.MapPath(rutaCarpeta)}/lista.txt", FileMode.Create);
            // 6. Abro el objeto de escritura -> StreamWriter
            StreamWriter streamWriter = new StreamWriter(fileStream);
            // 7. Realizo mis operaciones -> Sobreescribir
            string estudiantesSerializado = JsonConvert.SerializeObject(estudiantes);
            streamWriter.Write(estudiantesSerializado);
            // 8. Cierro el objeto de escritura
            streamWriter.Close();
            // 9. Cierro el filestream
            fileStream.Close();
            return RedirectToAction("Create");
        }

        // Index -> FileStream, StreamReader - Reto - 10:20
    }
}