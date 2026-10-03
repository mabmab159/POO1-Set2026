using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace semana04.Models
{
    public class Alumno
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string profession { get; set; }

        public Alumno() { }

        public Alumno(int id, string name, string lastname, string profession) { }
    }
}