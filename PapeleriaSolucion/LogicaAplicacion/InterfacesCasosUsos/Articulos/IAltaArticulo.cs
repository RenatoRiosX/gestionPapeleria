using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ArticuloDTOs;

namespace LogicaAplicacion.InterfacesCasosUsos.Articulos
{
    public interface IAltaArticulo
    {
        void Ejecutar(ArticuloDto articulo);
    }
}
