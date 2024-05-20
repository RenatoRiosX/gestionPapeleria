using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ArticuloDTOs;
using LogicaAplicacion.DTOs.PedidoDTOs;
using LogicaAplicacion.DTOsMappers.ArticulosMappers;
using LogicaAplicacion.DTOsMappers.PedidoMappers;
using LogicaAplicacion.InterfacesCasosUsos.Pedidos;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.ImplementacionCasosUsos.Pedidos
{
	public class GetAllPedidos : IGetAllPedidos
	{
		private IRepositorioPedidos _repositorioPedidos;

		public GetAllPedidos(IRepositorioPedidos repositorioPedidos)
		{
			_repositorioPedidos = repositorioPedidos;
		}

		public IEnumerable<PedidoParaListaDto> Ejecutar()
		{
			return _repositorioPedidos.GetAll().Select(p => PedidoParaListaDtoMapper.toDto(p)).ToList();
		}
	}
}
