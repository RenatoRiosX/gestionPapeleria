using LogicaAplicacion.DTOs.AdministradorDTOs;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.UsuarioDTOs;

namespace LogicaAplicacion.DTOsMappers.UsuarioMappers
{
    public class UsuarioDtoMapper
    {
        public static UsuarioDto toDto(Usuario usuario)
        {

            return new UsuarioDto
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nombre = usuario.NombreCompleto.Nombre,
                Apellido = usuario.NombreCompleto.Apellido,
                Contrasenia = usuario.Contrasenia,
                ContraseniaSinEncriptar = usuario.ContraseniaSinEncriptar

            };
        }

        public static Usuario FromDto(UsuarioDto usuario)
        {
            return new Usuario
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreCompleto = new NombreCompleto(usuario.Nombre, usuario.Apellido),
                Contrasenia = usuario.Contrasenia,
                ContraseniaSinEncriptar = usuario.Contrasenia
            };

        }
    }
}
