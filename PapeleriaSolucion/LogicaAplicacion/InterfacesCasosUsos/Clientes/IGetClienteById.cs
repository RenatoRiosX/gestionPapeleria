using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ClienteDTOs;

namespace LogicaAplicacion.InterfacesCasosUsos.Clientes
{
	public interface IGetClienteById
	{
		ClienteCompletoDto Ejecutar(int id);
	}
}
