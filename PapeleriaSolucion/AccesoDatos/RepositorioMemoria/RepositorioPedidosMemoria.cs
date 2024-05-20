using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.InterfacesRepositorio;
using System.Collections;

namespace AccesoDatos.RepositorioMemoria
{
    public class RepositorioPedidosMemoria : IRepositorioPedidos
    {
        public void Add(Pedido unObjeto)
        {
            throw new NotImplementedException();
        }


        public Pedido GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> PedidosAnulados()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> PedidosNoEntregados(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> PedidosPorNombreApellido()
        {
            throw new NotImplementedException();
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

        public void Update(Pedido unObjeto)
        {
            throw new NotImplementedException();
        }
    }

}

