using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace semana02.Models.Clases
{
    public class Persona2 : Persona //Recuperando las propiedades y los metodos
    {
        public string nombreCompleto()
        {
            return apellidos + ", " + nombres;
        }
    }
}