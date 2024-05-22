using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;

namespace AccesoDatos.RepositorioEF
{
	public class RepositorioConfiguracionEF : IRepositorioConfiguracion
	{

		private Context _db;
		public RepositorioConfiguracionEF (){
            _db = new Context();
        }
		public void Add(Configuracion configuracion)
		{
			try
			{
				configuracion.EsValido();
				_db.Configuraciones.Add(configuracion);
				_db.SaveChanges();
			}
			catch (Exception e)
			{
				throw e;
			}

		}

		public IEnumerable<Configuracion> GetAll()
		{
			throw new NotImplementedException();
		}

		public double GetValueByName(string nombre)
		{
			try
			{
                if (string.IsNullOrEmpty(nombre)) throw new NoNullAllowedException("El nombre de la configuracion no puede ser nulo o vacio.");

                return _db.Configuraciones.FirstOrDefault(c => c.Nombre == nombre).Valor;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			
		}


		public Configuracion GetById(int id)
		{
			return _db.Configuraciones.FirstOrDefault(c => c.Id == id);
		}

		public void Remove(int id)
		{
			throw new NotImplementedException();
		}

		public void Remove(Configuracion configuracion)
		{
			throw new NotImplementedException();
		}

		public void Update(Configuracion configuracion)
		{
			throw new NotImplementedException();
		}
	}
}
