using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.DireccionDTOs;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.DTOsMappers.DireccionDtoMapper
{
	public class DireccionDtoMapper
	{
		public static DireccionDto toDto(Direccion direccion)
		{
			return new DireccionDto
			{
				Calle = direccion.Calle,
				Numero = direccion.Numero,
				Ciudad = direccion.Ciudad,
				DistanciaPapeleria = direccion.DistanciaPapeleria,
			};
		}

		public static Direccion FromDto(DireccionDto direccion)
		{
			return new Direccion
			{
				Calle = direccion.Calle,
				Numero = direccion.Numero,
				Ciudad = direccion.Ciudad,
				DistanciaPapeleria = direccion.DistanciaPapeleria,
			};
		}
	}
}
