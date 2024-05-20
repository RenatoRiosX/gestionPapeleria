using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs.UsuarioDTOs
{
    public class UsuarioEditarDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Contrasenia { get; set; }

        public string ContraseniaSinEncriptar { get; set; }
    }
}
