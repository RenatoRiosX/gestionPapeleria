using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.InterfacesCasosUsos.Clientes
{
	public  interface IGetAllClientes
	{
		public IEnumerable<ClienteDto> Ejecutar();
	}
}
