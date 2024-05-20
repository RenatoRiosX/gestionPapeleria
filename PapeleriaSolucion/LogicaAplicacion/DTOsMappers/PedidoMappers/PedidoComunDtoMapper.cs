using LogicaAplicacion.DTOs.PedidoDTOs;
using LogicaAplicacion.DTOsMappers.ClienteMappers;
using LogicaAplicacion.DTOsMappers.LineaPedidoMappers;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOsMappers.PedidoMappers
{
	public class PedidoComunDtoMapper
	{
		public static PedidoComunDto toDto(Pedido pedido)
		{
			return new PedidoComunDto
			{
				FechaPrometidaEntrega = pedido.FechaPrometida,
				Cliente = ClienteCompletoDtoMapper.toDto(pedido.Cliente),
				CostoTotal = pedido.CalcularTotal(),
				LineasPedido = pedido._lineas.Select(l => LineaPedidoDtoMapper.toDto(l))
			};
		}

		public static PedidoComun FromDto(PedidoDto pedido)
		{
			return new PedidoComun
			{
				FechaPrometida = pedido.FechaPrometidaEntrega,
				Cliente = ClienteCompletoDtoMapper.FromDto(pedido.Cliente),
				_lineas = pedido.LineasPedido.Select(l => LineaPedidoDtoMapper.FromDto(l)).ToList(),
				CostoTotalPedido = pedido.CostoTotal
			};
		}
	}
}
