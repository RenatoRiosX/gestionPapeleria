using LogicaNegocio.Entidades;
namespace LogicaNegocio.InterfacesRepositorio
{
	public interface IRepositorioPedidos : IRepositorio<Pedido>
	{
		IEnumerable<Pedido> PedidosSuperenMonto(double monto);


		IEnumerable<Pedido> PedidosNoEntregados(DateTime fecha);


        IEnumerable<Pedido> PedidosAnulados();
    }

}

