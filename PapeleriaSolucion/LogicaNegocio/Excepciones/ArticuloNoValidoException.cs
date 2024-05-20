using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class ArticuloNoValidoException:Exception
    {
        public ArticuloNoValidoException() { }
        public ArticuloNoValidoException(string mensaje) : base(mensaje) { }
        public ArticuloNoValidoException(string mensaje, Exception ex) : base(mensaje, ex) { }
    }
}
