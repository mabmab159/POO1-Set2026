using semana06.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace semana06.Controllers
{
    public class AlumnoController : Controller
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;

        IEnumerable<Alumno> listarAlumnos()
        {
            List<Alumno> listaAlumnos = new List<Alumno>();
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion); //Indicacion la conexion a SQL
            sqlConnection.Open(); //Aperturando la conexion a SQL

            SqlCommand sqlCommand = new SqlCommand("select * from alumno a;", sqlConnection); //Crear el query o comando de ejecución
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(); // Ejecutando el query
            while (sqlDataReader.Read())
            { //Empiezas a recorrer el contenido hasta el final
                listaAlumnos.Add(new Alumno(
                    sqlDataReader.GetInt32(0),
                    sqlDataReader.GetString(1),
                    sqlDataReader.GetString(2),
                    sqlDataReader.GetString(3)
                    )
                    );
            }
            sqlDataReader.Close();
            sqlConnection.Close();
            return listaAlumnos;
        }

        string guardarAlumno(Alumno alumno)
        {
            // 1. Crear la cadena de conexion
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);
            // 2. Aperturar la cadena de conexion
            sqlConnection.Open();

            // 3. Crear el query
            SqlCommand sqlCommand = new SqlCommand("insert into alumno (Id, Nombre, Apellido, Carrera) " +
                "values (@id, @nombre, @apellido, @carrera)", sqlConnection);
            // 4. Reemplazar los valores del alias
            sqlCommand.Parameters.AddWithValue("@id", alumno.Id);
            sqlCommand.Parameters.AddWithValue("@nombre", alumno.Nombre);
            sqlCommand.Parameters.AddWithValue("@apellido", alumno.Apellido);
            sqlCommand.Parameters.AddWithValue("@carrera", alumno.Carrera);
            int cantidadCambios = sqlCommand.ExecuteNonQuery();
            if (cantidadCambios > 0)
            {
                return "Datos registrados correctamente";
            }
            return "Hubo un error, reintente";
        }

        Alumno recuperarAlumnoPorId(int id)
        {
            Alumno alumno = new Alumno();
            //1. Crear la conexion
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);
            //2. Aperturar la conexion
            sqlConnection.Open();

            //3. Crear el query
            SqlCommand sqlCommand = new SqlCommand("select * from alumno where id = @id", sqlConnection);
            //4. Ingresar los valores en el alias
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                alumno = new Alumno()
                {
                    Id = sqlDataReader.GetInt32(0),
                    Nombre = sqlDataReader.GetString(1),
                    Apellido = sqlDataReader.GetString(2),
                    Carrera = sqlDataReader.GetString(3),
                };
            }
            return alumno;
        }

        string EliminarAlumnoPorId(int id)
        {
            //1. Crear la conexion
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);
            //2. Aperturar la conexion
            sqlConnection.Open();
            //3. Crear el query
            SqlCommand sqlCommand = new SqlCommand("delete alumno where Id = @id", sqlConnection);
            //3.1. Asignar valores a los alias
            sqlCommand.Parameters.AddWithValue("@id", id);
            //4. Ejecutarlo
            int cantidad = sqlCommand.ExecuteNonQuery();
            //5. Validamos
            string mensaje = cantidad > 0 ? "Registro eliminado" : "Error, reintentar";
            return mensaje;
        }

        public ActionResult Index()
        {
            return View(listarAlumnos());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            //1. Guardar en BD
            string mensaje = guardarAlumno(alumno);
            ViewBag.mensaje = mensaje;
            //2. Mostrar el form
            return View(alumno);
        }

        public ActionResult Details(int id)
        {
            //1. Recupera el alumno por ID
            Alumno alumnoExistente = recuperarAlumnoPorId(id);
            //2. Mandar hacia la vista
            return View(alumnoExistente);
        }

        //Actualizar - 9:54

        //Eliminar
        public ActionResult Delete(int id)
        {
            Alumno alumnoExistente = recuperarAlumnoPorId(id);
            return View(alumnoExistente);
        }

        [HttpPost]
        public ActionResult Delete(Alumno alumno)
        {
            string mensaje = EliminarAlumnoPorId(alumno.Id);
            ViewBag.Mensaje = mensaje;
            return RedirectToAction("Index");
        }
    }
}