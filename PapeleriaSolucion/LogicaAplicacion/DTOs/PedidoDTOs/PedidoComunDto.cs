using LogicaAplicacion.DTOs.ClienteDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs.PedidoDTOs
{
	public class PedidoComunDto
	{
		public DateTime FechaPrometidaEntrega { get; set; }
		public ClienteCompletoDto Cliente { get; set; }
		public IEnumerable<LineaPedidoDto.LineaPedidoDto> LineasPedido { get; set; }
		public double CostoTotal { get; set; }
	}
}
