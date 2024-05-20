using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.DireccionDTOs;

namespace LogicaAplicacion.DTOs.ClienteDTOs
{
	public class ClienteCompletoDto
	{
		public int Id { get; set; }
		public string RazonSocial { get; set; }
		public string Rut { get; set; }
		public DireccionDto Direccion { get; set; }
	}
}
