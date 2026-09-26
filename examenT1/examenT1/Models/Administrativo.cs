using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace examenT1.Models
{
    public class Administrativo : Empleado
    {
        public int anioIngreso { get; set; }
        public Boolean PostGrado { get; set; }

        public double Incentivo()
        {
            return (PostGrado ? 1 : 0) * 500;
        }

        public double Bonificacion()
        {
            if (anioIngreso < 5) return 200;
            if (anioIngreso >= 5 && anioIngreso <= 10) return 450;
            return 300;
        }

        public double MontoAPagar()
        {
            return SueldoBasico() + Bonificacion() + Escolaridad() + Incentivo();
        }
    }
}