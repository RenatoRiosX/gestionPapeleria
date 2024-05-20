using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ArticuloDTOs;
using LogicaAplicacion.DTOsMappers.ArticulosMappers;
using LogicaAplicacion.InterfacesCasosUsos.Articulos;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.ImplementacionCasosUsos.Articulos
{
	public class GetAllArticulos : IGetAllArticulos
	{
		private IRepositorioArticulos _repositorioArticulo;

		public GetAllArticulos(IRepositorioArticulos repositorioArticulos)
		{
			_repositorioArticulo = repositorioArticulos;
		}
		public IEnumerable<ArticuloDto> Ejecutar()
		{
			return _repositorioArticulo.GetAll().Select(a => ArticuloDtoMapper.toDto(a)).ToList();
		}
	}
}
