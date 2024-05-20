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
	public class GetClienteById : IGetClienteById
	{
		private IRepositorioClientes _repositorioClientes;
		public GetClienteById(IRepositorioClientes repo)
		{
			_repositorioClientes = repo;
		}
		public ClienteCompletoDto Ejecutar(int id)
		{
			Cliente cliente = _repositorioClientes.GetById(id); ;
			return ClienteCompletoDtoMapper.toDto(cliente);
		}
	}
	
}
