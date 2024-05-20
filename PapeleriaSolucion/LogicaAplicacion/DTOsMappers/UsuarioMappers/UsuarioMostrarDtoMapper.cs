using LogicaAplicacion.DTOs.UsuarioDTOs;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOsMappers.UsuarioMappers
{
    public class UsuarioMostrarDtoMapper
    {
        public static UsuarioMostrarDto toDto(Usuario usuario)
        {

            return new UsuarioMostrarDto
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nombre = usuario.NombreCompleto.Nombre,

            };
        }

        public static Usuario FromDto(UsuarioMostrarDto usuario)
        {
            return new Usuario
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreCompleto = new NombreCompleto(usuario.Nombre, null),
            };

        }
    }
}
