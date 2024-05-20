using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaAplicacion.DTOsMappers.ClienteMappers;
using LogicaAplicacion.InterfacesCasosUsos.Clientes;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUsos.Clientes
{
    public class BuscarClientePorRazonSocial : IBuscarClientePorRazonSocial
    {
        private IRepositorioClientes _repositorioClientes;
        public BuscarClientePorRazonSocial(IRepositorioClientes repo)
        {
            _repositorioClientes = repo;
        }
        public ClienteDto GetByRazon(string razonSocial)
        {

            Cliente clienteEncontrado =  _repositorioClientes.GetByRazonSocial(razonSocial);
            ClienteDto clienteDto= ClienteDtoMapper.toDto(clienteEncontrado);
            if (clienteDto != null)
            {
                return clienteDto;
            }

            throw new Exception($"Cliente con razón social '{razonSocial}' no encontrado.");
        }
    }
}
