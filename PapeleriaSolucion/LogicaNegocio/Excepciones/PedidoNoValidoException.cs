using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class PedidoNoValidoException:Exception
    {
        public PedidoNoValidoException() { }
        public PedidoNoValidoException(string mensaje) : base(mensaje) { }
        public PedidoNoValidoException(string mensaje, Exception ex) : base(mensaje, ex) { }
    }
}
