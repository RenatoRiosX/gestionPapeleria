using LogicaAplicacion.InterfacesCasosUsos.Pedidos;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUsos.Pedidos
{
    public class AnularPedido:IAnularPedido
    {
        private IRepositorioPedidos _repositorioPedidos;

        public AnularPedido(IRepositorioPedidos repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }

        public void Ejecutar(int id)
        {
            var pedido = _repositorioPedidos.GetById(id);

            pedido.Anulado = true;

            _repositorioPedidos.Update(pedido);
        }
    }
}
