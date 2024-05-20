using LogicaAplicacion.InterfacesCasosUsos.Pedidos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.PedidoDTOs;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.ImplementacionCasosUsos.Pedidos
{
    public class BajaPedido : IBajaPedido
    {
        private IRepositorioPedidos _repositorioPedidos;

        public BajaPedido(IRepositorioPedidos repositorioPedidos)
        {
			_repositorioPedidos = repositorioPedidos;
		}
        public void Ejecutar(PedidoDto pedido)
        {
            throw new NotImplementedException();
        }
    }
}
