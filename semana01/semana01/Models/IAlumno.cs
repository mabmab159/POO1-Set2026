using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana01.Models
{
    public interface IAlumno
    {
        //No me permite poner modificador de acceso : public, private, protected
        string nombreCompleto();
    }
}
