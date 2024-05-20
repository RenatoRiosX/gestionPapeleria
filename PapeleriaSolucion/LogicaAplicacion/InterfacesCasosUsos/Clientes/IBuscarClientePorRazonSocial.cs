using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUsos.Clientes
{
    public interface IBuscarClientePorRazonSocial
    {
        ClienteDto GetByRazon(string razonSocial);
    }
}
