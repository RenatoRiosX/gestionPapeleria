using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class ClienteNoValidoException: Exception
    {
        public ClienteNoValidoException() { }
        public ClienteNoValidoException(string mensaje) : base(mensaje) { }
        public ClienteNoValidoException(string mensaje, Exception ex) : base(mensaje, ex) { }
    }
}
