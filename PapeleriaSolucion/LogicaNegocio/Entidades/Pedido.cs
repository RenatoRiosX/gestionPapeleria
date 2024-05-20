using System.Runtime.InteropServices.ComTypes;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesEntidades;

namespace LogicaNegocio.Entidades
{
    public class Pedido : IValidable, IEntity
	{
		//TODO: Agregar FK a linea y a pedido
		public DateTime FechaCreacionPedido {get; set;} = DateTime.Now;

		public DateTime FechaPrometida {get;set;}

		public double CostoTotalPedido {get;set;}

		public Boolean Entregado {get;set;}

		public Boolean Anulado {get;set;}

		public Cliente Cliente {get; set;}

		public IEnumerable<Linea> _lineas { get; set; }

		public int Id{ get; set; }



		public virtual double Recargo()
		{
			return 0;
		}

		public double CalcularTotal()
		{
			double total = 0;
			if (_lineas != null)
			{
				foreach (var linea in _lineas)
				{
					total += linea.CalcularTotalLinea();
				}
			}

			return total + total * Recargo();
		}


		public virtual void EsValido()
		{
			//Si la fecha prometida de entrega es anterior a la fecha de creacion del pedido, el pedido no es valido.
			if (DateTime.Compare(FechaPrometida, FechaCreacionPedido) < 0) throw new PedidoNoValidoException("La fecha prometida de entrega no puede ser anterior a la fecha actual.");
			//Todo: Investigar si se puede hacer un foreach con Linq
			foreach (var linea in _lineas)
			{
				linea.EsValido();
			}
			if (Cliente == null) throw new PedidoNoValidoException("El pedido debe tener un cliente.");
			if (CostoTotalPedido <= 0) throw new PedidoNoValidoException("El costo total del pedido debe ser mayor a 0.");
		}

	}

}

