using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs.ClienteDTOs
{
	public record ClienteDto
	{
		public int Id { get; set; }
		public string RazonSocial { get; set; }
		public string Rut { get; set; }

	}
}
