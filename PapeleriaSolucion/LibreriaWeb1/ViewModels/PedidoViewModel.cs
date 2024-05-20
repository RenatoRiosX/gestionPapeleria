using LogicaAplicacion.DTOs.ArticuloDTOs;
using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaAplicacion.DTOs.LineaPedidoDto;
using LogicaNegocio.Entidades;

namespace Web.ViewModels
{
	public class PedidoViewModel
	{
		public IEnumerable<ArticuloDto> Articulos { get; set; }
		public IEnumerable<ClienteDto> Clientes { get; set; }
		public int ClienteId { get; set; }
        public List<LineaPedidoDto> LineasPedido { get; set; } = new List<LineaPedidoDto>();
		public LineaPedidoDto LineaPedidoDto { get; set; }
		public bool PedidoExpress { get; set; }
		public DateTime FechaPrometidaEntrega { get; set; } = DateTime.Today;

	}
}
