using LogicaNegocio.Excepciones;

namespace LogicaNegocio.Entidades
{
	public class PedidoExpress : Pedido
	{
		public override double Recargo()
		{
			double recargo = 0.10;
			if (FechaCreacionPedido.Day == FechaPrometida.Day)
			{
				recargo = 0.15;
			}
			return recargo;
		}

		public override void EsValido()
		{
			if (FechaPrometida.Day - FechaCreacionPedido.Day > 5)
			{
				throw new PedidoNoValidoException("El pedido express no puede tener un plazo de entrega superior a 5 dias desde la fecha de creacion.");
			}
			base.EsValido();
		}
	}

}

