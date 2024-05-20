using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaAplicacion.DTOsMappers.ClienteMappers;
using LogicaAplicacion.InterfacesCasosUsos.Clientes;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.ImplementacionCasosUsos.Clientes
{
	public class GetAllClientes : IGetAllClientes
	{
		private IRepositorioClientes _repositorioClientes;
		public GetAllClientes(IRepositorioClientes repo)
		{
			_repositorioClientes = repo;
		}
		public IEnumerable<ClienteDto> Ejecutar()
		{
			return _repositorioClientes.GetAll().Select(c => ClienteDtoMapper.toDto(c));
		}
	}
}
