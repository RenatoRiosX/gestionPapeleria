using LogicaAplicacion.DTOs.ArticuloDTOs;
using LogicaAplicacion.DTOs.PedidoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUsos.Pedidos
{
    public interface IGetPedidosPorFecha
    {
        public IEnumerable<PedidoParaListaDto> Ejecutar(DateTime fecha);
    }
}
