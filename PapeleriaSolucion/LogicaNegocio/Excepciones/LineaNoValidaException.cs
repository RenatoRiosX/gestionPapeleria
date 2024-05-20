using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
	public class LineaNoValidaException:Exception
	{
		public LineaNoValidaException() { }
		public LineaNoValidaException(string mensaje) : base(mensaje) { }
		public LineaNoValidaException(string mensaje, Exception ex) : base(mensaje, ex) { }
	}
}
