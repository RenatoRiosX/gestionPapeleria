using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.LineaPedidoDto;
using LogicaAplicacion.DTOsMappers.ArticulosMappers;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.DTOsMappers.LineaPedidoMappers
{
	public class LineaPedidoDtoMapper
	{
		public static LineaPedidoDto toDto(Linea lineaPedido)
		{
			return new LineaPedidoDto
			{
				Id = lineaPedido.Id,
				ArticuloDto = ArticuloDtoMapper.toDto(lineaPedido.Articulo),
				Unidades = lineaPedido.Unidades,
				PrecioUnitario = lineaPedido.Articulo.PrecioActual
			};
		}

		public static Linea FromDto(LineaPedidoDto lineaPedidoDto)
		{
			return new Linea
			{
				Id = lineaPedidoDto.Id,
				Articulo =  ArticuloDtoMapper.FromDto(lineaPedidoDto.ArticuloDto),
				Unidades = lineaPedidoDto.Unidades,
				PrecioUnitarioVigente = lineaPedidoDto.PrecioUnitario
			};
		}
	}
}
