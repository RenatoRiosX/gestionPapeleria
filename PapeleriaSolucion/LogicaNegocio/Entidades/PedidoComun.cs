using LogicaNegocio.Excepciones;

namespace LogicaNegocio.Entidades
{
	public class PedidoComun : Pedido
	{
		
		public override double Recargo()
		{
			double recargo = 0;
			if (Cliente.Direccion.DistanciaPapeleria > 100)
			{
				recargo = 0.05;
			}

			return recargo;
		}


		public override void EsValido()
		{
			if (FechaPrometida.Day - FechaCreacionPedido.Day < 7)
			{
				throw new PedidoNoValidoException("El pedido comun no pude tener una fecha de entrega menor a 7 dias desde su fecha de creación.");
			}
			base.EsValido();

		}

	}

}

