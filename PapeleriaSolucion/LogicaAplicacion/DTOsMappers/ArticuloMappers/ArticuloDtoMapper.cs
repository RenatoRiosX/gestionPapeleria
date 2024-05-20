using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ArticuloDTOs;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.DTOsMappers.ArticulosMappers
{
    public class ArticuloDtoMapper
    {
        public static ArticuloDto toDto(Articulo articulo)
        {
            return new ArticuloDto
            {
                Id = articulo.Id,
                Nombre = articulo.Nombre,
                PrecioActual = articulo.PrecioActual,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,
                Stock = articulo.Stock
            };
        }

        public static Articulo FromDto(ArticuloDto articulo)
        {
            return new Articulo
            {
                Id = articulo.Id,
                Nombre = articulo.Nombre,
                PrecioActual = articulo.PrecioActual,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,
                Stock = articulo.Stock
            };
        }
    }
}
