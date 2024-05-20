using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.PedidoDTOs;

namespace LogicaAplicacion.InterfacesCasosUsos.Pedidos
{
	public interface IGetAllPedidos
	{
		IEnumerable<PedidoParaListaDto> Ejecutar();
	}
}
