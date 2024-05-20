using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.Entidades
{
    public class Articulo : IValidable, IEntity
	{
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 10, ErrorMessage = "Largo del nombre: entre 10 y 200 caracteres")]

		public string Nombre{ get; set; }

		public string Descripcion{ get;set;}

        [StringLength(13, MinimumLength = 13, ErrorMessage = "Largo del código: 13 caracteres")]
		public string Codigo{ get;set;}
        

		public double PrecioActual { get;set;}

		public int Stock{ get;set;}


		public void AumentarStock(int cant)
		{

		}

		public void BajarStock(int cant)
		{

		}


		public void EsValido()
		{

            if (string.IsNullOrEmpty(Nombre))
            {
                throw new ArticuloNoValidoException("Nombre no válido");
            }

            if (string.IsNullOrEmpty(Descripcion) || Descripcion.Length < 5)
            {
                throw new ArticuloNoValidoException("Descripción no válida");
            }

            if (Codigo.Length != 13 )
            {
                throw new ArticuloNoValidoException("Código no válido");
            }

            if (PrecioActual <= 0)
            {
                throw new ArticuloNoValidoException("Precio actual no válido");
            }

            if (Stock < 0)
            {
                throw new ArticuloNoValidoException("Stock no válido");
            }
        }

	}

}

