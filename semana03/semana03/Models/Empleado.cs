using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace semana03.Models
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string nomapeEmpleado { get; set; }
        public string categoriaEmpleado { get; set; }
        public int nHijos { get; set; }
        public string tipoContrato { get; set; }

        public Empleado()
        {

        }

        public Empleado(int idEmpleado, string nomapeEmpleado, string categoriaEmpleado, int nHijos, string tipoContrato)
        {
            this.idEmpleado = idEmpleado;
            this.nomapeEmpleado = nomapeEmpleado;
            this.categoriaEmpleado = categoriaEmpleado;
            this.nHijos = nHijos;
            this.tipoContrato = tipoContrato;
        }
    }
}