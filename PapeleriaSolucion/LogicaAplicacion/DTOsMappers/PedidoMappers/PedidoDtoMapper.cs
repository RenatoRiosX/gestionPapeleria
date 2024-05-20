using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.PedidoDTOs;
using LogicaAplicacion.DTOsMappers.ClienteMappers;
using LogicaAplicacion.DTOsMappers.LineaPedidoMappers;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.DTOsMappers.PedidoMappers
{
	public  class PedidoDtoMapper
	{
		public static PedidoDto toDto(Pedido pedido)
		{
			return new PedidoDto
			{
				FechaPrometidaEntrega = pedido.FechaPrometida,
				Cliente = ClienteCompletoDtoMapper.toDto(pedido.Cliente),
				CostoTotal = pedido.CalcularTotal(),
				LineasPedido = pedido._lineas.Select(l => LineaPedidoDtoMapper.toDto(l))
			};
		}

		public static Pedido FromDto(PedidoDto pedido)
		{

			return new Pedido
			{
				FechaPrometida = pedido.FechaPrometidaEntrega,
				Cliente = ClienteCompletoDtoMapper.FromDto(pedido.Cliente),
				_lineas = pedido.LineasPedido.Select(l => LineaPedidoDtoMapper.FromDto(l)).ToList(),
				CostoTotalPedido = pedido.CostoTotal
			};
		}
	}
}
