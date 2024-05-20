using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs.ArticuloDTOs
{
    public record ArticuloDto
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 10, ErrorMessage = "Largo del nombre: entre 10 y 200 caracteres")]

        public string Nombre { get; set; }

        [StringLength(13, MinimumLength = 13, ErrorMessage = "Largo del código: 13 caracteres")]

        public string Codigo { get; set; }
        public double PrecioActual { get; set; }
        public string Descripcion { get; set;}
        public int Stock { get; set;}

    }
}
