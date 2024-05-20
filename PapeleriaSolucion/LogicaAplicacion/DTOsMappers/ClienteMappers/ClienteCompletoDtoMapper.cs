using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.DireccionDTOs;
using LogicaNegocio.ValueObjects;


namespace LogicaAplicacion.DTOsMappers.ClienteMappers
{
	public class ClienteCompletoDtoMapper
	{
		public static ClienteCompletoDto toDto(Cliente cliente)
		{
			return new ClienteCompletoDto
			{
				Id = cliente.Id,
				RazonSocial = cliente.RazonSocial,
				Rut = cliente.Rut,
				Direccion = new DireccionDto
				{
					Calle = cliente.Direccion.Calle,
					Numero = cliente.Direccion.Numero,
					Ciudad = cliente.Direccion.Ciudad,
					DistanciaPapeleria = cliente.Direccion.DistanciaPapeleria,
				}
			};
		}

		public static Cliente FromDto(ClienteCompletoDto cliente)
		{
			return new Cliente
			{
				Id = cliente.Id,
				RazonSocial = cliente.RazonSocial,
				Rut = cliente.Rut,
				Direccion = new Direccion
				{
					Calle = cliente.Direccion.Calle,
					Numero = cliente.Direccion.Numero,
					Ciudad = cliente.Direccion.Ciudad,
					DistanciaPapeleria = cliente.Direccion.DistanciaPapeleria,
				}
			};
		}
	}
}
