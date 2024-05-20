using System;
using System.Collections.Generic;
using LogicaAplicacion.DTOs.PedidoDTOs;
using LogicaAplicacion.DTOsMappers.PedidoMappers;
using LogicaAplicacion.InterfacesCasosUsos.Pedidos;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.ImplementacionCasosUsos.Pedidos
{
    public class GetPedidosPorFecha : IGetPedidosPorFecha
    {
        private IRepositorioPedidos _repositorioPedidos;

        public GetPedidosPorFecha(IRepositorioPedidos repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }

        public IEnumerable<PedidoParaListaDto> Ejecutar(DateTime fecha)
        {
            return _repositorioPedidos.PedidosNoEntregados(fecha).Select(p => PedidoParaListaDtoMapper.toDto(p)).ToList();
        }
    }
}
