using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace semana06.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Carrera { get; set; }

        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, string carrera)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Carrera = carrera;
        }
    }
}