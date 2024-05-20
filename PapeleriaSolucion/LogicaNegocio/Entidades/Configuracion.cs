using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
	public class Configuracion : IValidable, IEntity
	{
		public string Nombre { get; set; }
		public double Valor { get; set; }
		public int Id { get; set; }

		public void EsValido()
		{
			if (string.IsNullOrEmpty(Nombre)) throw new NoNullAllowedException("El nombre de la configuracion no puede ser nulo o vacio.");

		}
	}
}
