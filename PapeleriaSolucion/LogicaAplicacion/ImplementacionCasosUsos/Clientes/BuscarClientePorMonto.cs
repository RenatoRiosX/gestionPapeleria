using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.InterfacesCasosUsos.Clientes;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaAplicacion.DTOsMappers.ClienteMappers;


namespace LogicaAplicacion.ImplementacionCasosUsos.Clientes
{
    public class BuscarClientePorMonto: IBuscarClientePorMonto
    {
        private IRepositorioClientes _repositorioClientes;
        public BuscarClientePorMonto(IRepositorioClientes repo)
        {
            _repositorioClientes = repo;
        }
        public IEnumerable<ClienteDto> GetByMonto(double monto)
        {
            IEnumerable<ClienteDto> clientes= _repositorioClientes.GetByMonto(monto).Select(c=>ClienteDtoMapper.toDto(c));

            if (clientes != null)
            {
                return clientes;
            }
            return clientes;
           

        }
    }
}
