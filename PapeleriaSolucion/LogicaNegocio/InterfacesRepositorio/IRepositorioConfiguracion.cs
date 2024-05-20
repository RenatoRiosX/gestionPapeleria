using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesRepositorio
{
	public interface IRepositorioConfiguracion : IRepositorio<Configuracion>
	{
		public double GetValueByName(string nombre);
	}
}
