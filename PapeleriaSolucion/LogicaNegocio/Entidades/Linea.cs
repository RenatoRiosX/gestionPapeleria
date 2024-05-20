using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesEntidades;

namespace LogicaNegocio.Entidades
{
	
    public class Linea : IValidable, IEntity
	{
		public int Id { get; set; }
		public Articulo Articulo { get; set;}

		public int Unidades{get;set;}

		public double PrecioUnitarioVigente{get;set;}


        public double CalcularTotalLinea()
		{
			return Unidades * PrecioUnitarioVigente;
		}


		public void EsValido()
		{
			if(Articulo == null) throw new LineaNoValidaException("La linea debe tener un articulo.");
			if(Unidades <= 0) throw new LineaNoValidaException("La cantidad de unidades debe ser mayor a 0.");
			if(PrecioUnitarioVigente <= 0) throw new LineaNoValidaException("El precio unitario debe ser mayor a 0.");
		}

		
	}

}

