using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace examenT1.Models
{
    public class Empleado
    {
        public string idEmpleado { get; set; }
        public string nomapeEmpleado { get; set; }
        public string categoriaEmpleado { get; set; }
        public int nHijos { get; set; }
        public string tipoContrato { get; set; }

        public Empleado() { }

        public Empleado(string idEmpleado, string nomapeEmpleado, string categoriaEmpleado, int nHijos, string tipoContrato)
        {
            this.idEmpleado = idEmpleado;
            this.nomapeEmpleado = nomapeEmpleado;
            this.categoriaEmpleado = categoriaEmpleado;
            this.nHijos = nHijos;
            this.tipoContrato = tipoContrato;
        }

        public double SueldoBasico()
        {
            switch (categoriaEmpleado){
                case "E1": return 5500;
                case "E2": return 2500;
                case "E3": return 2200;
                default: return 1700;
            }
        } 

        public double Escolaridad()
        {
            return 108 * nHijos;
        }

        public double Bonificacion()
        {
            if (tipoContrato.Equals("Indefinido")) return 0.15 * SueldoBasico();
            return 0.10 * SueldoBasico();
        }

        public double MontoAPagar()
        {
            return SueldoBasico() + Escolaridad() + Bonificacion();
        }
    }
}