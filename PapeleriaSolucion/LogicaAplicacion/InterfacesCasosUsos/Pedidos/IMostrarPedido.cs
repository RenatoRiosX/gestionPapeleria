using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUsos.Pedidos
{
    public interface IMostrarPedido
    {
      List<Pedido> GetAnulados();
    }
}
