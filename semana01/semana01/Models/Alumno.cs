using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace semana01.Models
{
    public class Alumno : IAlumno
    {
        public int id { get; set; } // private int id; public int getId; public void setId
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }

        public string nombreCompleto()
        {
            return this.nombre + " " + this.apellido;
        }
    }
}