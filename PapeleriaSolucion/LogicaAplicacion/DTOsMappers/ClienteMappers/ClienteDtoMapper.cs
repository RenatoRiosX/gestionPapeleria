using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.DTOsMappers.ClienteMappers
{
	public class ClienteDtoMapper
	{

		public static ClienteDto toDto(Cliente cliente)
		{
			return new ClienteDto
			{
				Id = cliente.Id,
				RazonSocial = cliente.RazonSocial,
				Rut = cliente.Rut,
			};
		}

		public static Cliente FromDto(ClienteDto cliente)
		{
			return new Cliente
			{
				Id = cliente.Id,
				RazonSocial = cliente.RazonSocial,
				Rut = cliente.Rut,
			};
		}

	}
}
