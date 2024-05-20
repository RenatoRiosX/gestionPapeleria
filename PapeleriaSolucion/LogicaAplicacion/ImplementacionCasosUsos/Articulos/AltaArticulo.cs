using LogicaAplicacion.InterfacesCasosUsos.Articulos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ArticuloDTOs;
using LogicaAplicacion.DTOsMappers.ArticulosMappers;

namespace LogicaAplicacion.ImplementacionCasosUsos.Articulos
{
    public class AltaArticulo : IAltaArticulo
    {
        private IRepositorioArticulos _repositorioArticulo;

        public AltaArticulo(IRepositorioArticulos repositorioArticulos)
        {
            _repositorioArticulo = repositorioArticulos;
        }
        public void Ejecutar(ArticuloDto articulo)
        {
            if (articulo != null)
            {
                Articulo articuloNuevo = ArticuloDtoMapper.FromDto(articulo);
                _repositorioArticulo.Add(articuloNuevo);
            }
        }
    }
}
