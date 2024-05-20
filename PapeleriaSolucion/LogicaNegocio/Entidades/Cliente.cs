using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ValueObjects;

namespace LogicaNegocio.Entidades
{
    public class Cliente : IValidable, IEntity
    {
		public string RazonSocial { get; set; }

		public string Rut{get; set; }

		public Direccion Direccion{get; set; }

        public int Id { get; set; }
        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }

}

