using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.PedidoDTOs;
using LogicaAplicacion.DTOsMappers.PedidoMappers;
using LogicaAplicacion.InterfacesCasosUsos.Pedidos;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.ImplementacionCasosUsos.Pedidos
{
    public class ObtenerPedidosAnulados: IObtenerPedidosAnulados
    {
        private IRepositorioPedidos _repositorioPedidos;

        public ObtenerPedidosAnulados(IRepositorioPedidos repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }

        public IEnumerable<PedidoParaListaDto> Ejecutar()
        {
            return _repositorioPedidos.PedidosAnulados().Select(p => PedidoParaListaDtoMapper.toDto(p)).ToList();
        }
    }
}
