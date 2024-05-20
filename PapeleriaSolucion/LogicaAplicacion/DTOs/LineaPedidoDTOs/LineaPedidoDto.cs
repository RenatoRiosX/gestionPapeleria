using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ArticuloDTOs;


namespace LogicaAplicacion.DTOs.LineaPedidoDto
{
	public record LineaPedidoDto
	{
		public int Id { get; set; }
		public ArticuloDto ArticuloDto { get; set; }
		public int Unidades { get; set; }

		public double PrecioUnitario { get; set; }
	}
}
