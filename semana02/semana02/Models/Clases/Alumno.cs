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

        //Constructores
        public Alumno() // Este siempre se genera por defecto, a menos que tu especifiques un constructor
        {

        }

        public Alumno(string codigoAlumno, string carrera, string facultad)
        {
            this.codigoAlumno = codigoAlumno;
            this.carrera = carrera;
            this.facultad = facultad;
        }

        public Boolean validarCampos()
        {
            if (!string.IsNullOrEmpty(this.codigoAlumno) && !string.IsNullOrEmpty(this.carrera) && !string.IsNullOrEmpty(this.facultad))
            {
                return true && validarPersona();
            }
            return false;
        }
    }
}