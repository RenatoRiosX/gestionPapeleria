using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs.AdministradorDTOs
{
	public record AdministradorDto
	{
		
		public int Id { get; set; }
		public string Email { get; set; }
		public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasenia { get; set; }
        

    }
}
