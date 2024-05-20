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
	public class PedidoParaListaDtoMapper
	{
			public static PedidoParaListaDto toDto(Pedido pedido)
			{
				return new PedidoParaListaDto
				{
					FechaEmisionPedido = pedido.FechaCreacionPedido,
					FechaPrometidaEntrega = pedido.FechaPrometida,
					Cliente = ClienteDtoMapper.toDto(pedido.Cliente),
					CostoTotal = pedido.CostoTotalPedido,
					Id = pedido.Id
				};
			}

			public static Pedido FromDto(PedidoParaListaDto pedido)
			{
				return new Pedido
				{
					Id = pedido.Id,
					FechaCreacionPedido = pedido.FechaEmisionPedido,
					FechaPrometida = pedido.FechaPrometidaEntrega,
					Cliente = ClienteDtoMapper.FromDto(pedido.Cliente),
					CostoTotalPedido = pedido.CostoTotal
				};
			}
		
	}
}
