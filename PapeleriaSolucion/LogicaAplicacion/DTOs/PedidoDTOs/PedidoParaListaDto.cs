using LogicaAplicacion.DTOs.ClienteDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs.PedidoDTOs
{
	public class PedidoParaListaDto
	{
		public int Id { get; set; }
		public DateTime FechaEmisionPedido { get; set; }
		public DateTime FechaPrometidaEntrega { get; set; }
		public ClienteDto Cliente { get; set; }
		public double CostoTotal { get; set; }
	}
}
