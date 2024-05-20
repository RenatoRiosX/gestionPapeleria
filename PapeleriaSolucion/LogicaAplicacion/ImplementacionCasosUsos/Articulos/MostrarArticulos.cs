using LogicaAplicacion.InterfacesCasosUsos.Articulos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ArticuloDTOs;
using LogicaAplicacion.DTOsMappers.ArticulosMappers;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.ImplementacionCasosUsos.Articulos
{
    public class MostrarArticulos : IMostrarArticulos
    {
	    private IRepositorioArticulos _repositorioArticulo;

	    public MostrarArticulos(IRepositorioArticulos repositorioArticulos)
	    {
		    _repositorioArticulo = repositorioArticulos;
	    }
		public IEnumerable<ArticuloDto> Ejecutar()
        {
			IEnumerable<Articulo> articulos = _repositorioArticulo.GetAll();
			return articulos.Select(a => ArticuloDtoMapper.toDto(a));
        }
    }
}
