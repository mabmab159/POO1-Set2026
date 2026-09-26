using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace semana02.Models.Clases
{
    public class Persona
    {
        public int id;
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public string nombreCompleto()
        {
            //return nombres + " " + apellidos;
            return apellidos + ", " + nombres;
        }

        /*
        public string nombreFormato()
        {
            return apellidos + ", " + nombres;
        }
        */

        public int edad()
        {
            return DateTime.Now.Year - fechaNacimiento.Year;
        }

        public Boolean validarPersona()
        {
            if(fechaNacimiento.Year <= 1900)
            {
                return false;
            }
            return true;
        }
    }
}