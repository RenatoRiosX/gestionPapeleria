using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System.Collections;
using LogicaAplicacion.DTOs.ArticuloDTOs;
using LogicaAplicacion.DTOsMappers.ArticulosMappers;
using LogicaNegocio.Excepciones;

namespace AccesoDatos.RepositorioEF
{
    public class RepositorioArticulosEF : IRepositorioArticulos
    {
        private Context _db;

        public RepositorioArticulosEF()
        {
            _db = new Context();
        }

        public void Add(Articulo articulo)
        {
            if (articulo == null)
            {
                throw new ArticuloNoValidoException();
            }

            try
            {
                articulo.EsValido();
                _db.Articulos.Add(articulo);
                _db.SaveChanges();
            }
            catch (ArticuloNoValidoException ex)
            {
                throw ex;
            }
        }

        public void AumentarStock()
        {
            throw new NotImplementedException();
        }

        public void DisminuirStock()
        {
            throw new NotImplementedException();
        }


        public Articulo GetById(int id)
        {
            throw new NotImplementedException();
        }


		public IEnumerable<Articulo> GetAll()
        {
            return _db.Articulos.OrderBy(a => a.Nombre).ToList();
        }


		public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Articulo unObjeto)
        {
            throw new NotImplementedException();
        }

        public void Update(Articulo unObjeto)
        {
            throw new NotImplementedException();
        }
    }

}

