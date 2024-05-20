using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ClienteDTOs;

namespace LogicaAplicacion.DTOs.PedidoDTOs
{
	public record PedidoDto
	{
		public DateTime FechaPrometidaEntrega { get; set; }
		public ClienteCompletoDto Cliente { get; set; }
		public IEnumerable <LineaPedidoDto.LineaPedidoDto> LineasPedido { get; set; }
		public double CostoTotal { get; set; }
	}
}
