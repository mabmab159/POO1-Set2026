using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace semana02.Models.Clases
{
    public class Alumno : Persona
    {
        public string codigoAlumno { get; set; }
        public string carrera { get; set; }
        public string facultad {get; set; }
    }
}