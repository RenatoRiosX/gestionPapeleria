using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaAplicacion.DTOs.UsuarioDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOsMappers.ClienteMappers
{
    public class BuscarClienteDtoMapper
    {
        public static ClienteDto toDto(Cliente cliente)
        {
            return new ClienteDto
            {
                RazonSocial = cliente.RazonSocial,
                Id = cliente.Id

            };
        }
        public static Cliente FromDto(ClienteDto clienteDto)
        {
            return new Cliente
            {
                RazonSocial = clienteDto.RazonSocial,
                Id = clienteDto.Id
            };
        }

    }
}
