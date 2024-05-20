using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Entidades;
using LogicaAplicacion.DTOs.ClienteDTOs;


namespace LogicaAplicacion.InterfacesCasosUsos.Clientes
{
    public interface IBuscarClientePorMonto
    {
       public IEnumerable<ClienteDto> GetByMonto(double monto);
    }
}
