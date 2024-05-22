using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Entidades;
using System.Collections;
using LogicaNegocio.Excepciones;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.RepositorioEF
{
    public class RepositorioPedidosEF : IRepositorioPedidos
    {
	    private Context _db;

        public RepositorioPedidosEF()
        {
            _db = new Context();
        }
		public void Add(Pedido pedido)
        {
	        try
	        {
		        //_db.Attach se utiliza para que no se dupliquen los objetos en la base de datos
		        _db.Attach(pedido.Cliente);
		        foreach (var lineaPedido in pedido._lineas)
		        {
			        _db.Attach(lineaPedido.Articulo);
		        }
		        pedido.EsValido();
		        _db.Pedidos.Add(pedido);
		        _db.SaveChanges();
			}
	        catch (PedidoNoValidoException exception)
	        {
		        throw exception;
	        }
            
        }


        public Pedido GetById(int id)
        {
            return _db.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p._lineas) 
                .FirstOrDefault(p => p.Id == id);

        }
        public IEnumerable<Pedido> GetAll()
        {
            return _db.Pedidos.Include(p => p.Cliente).ToList();
        }



        public IEnumerable<Pedido> PedidosAnulados()
        {
            return _db.Pedidos.Include(p => p.Cliente).Where(p => p.Anulado).OrderByDescending(p=>p.FechaCreacionPedido).ToList();
        }

        public IEnumerable<Pedido> PedidosNoEntregados(DateTime fecha)
        {
            // Filtramos los pedidos que fueron emitidos en la fecha proporcionada y que a�n no han sido entregados
            return _db.Pedidos
                .Include(p => p.Cliente)
                .Where(p => p.FechaCreacionPedido.Date == fecha.Date && !p.Entregado && !p.Anulado)
                .ToList();
        }


        public IEnumerable<Pedido> PedidosSuperenMonto(double monto)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Pedido unObjeto)
        {
            throw new NotImplementedException();
        }

        public void Update(Pedido pedido)
        {
            _db.Pedidos.Update(pedido);
            _db.SaveChanges();
        }
    }

}

