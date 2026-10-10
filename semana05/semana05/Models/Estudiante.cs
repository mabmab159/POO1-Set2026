using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace semana05.Models
{
    public class Estudiante
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string carrera { get; set; }
        public string facultad { get; set; }
    }
}