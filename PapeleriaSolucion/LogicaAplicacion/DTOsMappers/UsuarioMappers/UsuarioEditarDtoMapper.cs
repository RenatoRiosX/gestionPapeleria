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
    public class UsuarioEditarDtoMapper
    {
        public static UsuarioEditarDto toDto(Usuario usuario)
        {

            return new UsuarioEditarDto
            {
                Id = usuario.Id,
                //Email = usuario.Email,
                Nombre = usuario.NombreCompleto.Nombre,
                Apellido = usuario.NombreCompleto.Apellido,
                Contrasenia = usuario.Contrasenia,
                ContraseniaSinEncriptar = usuario.ContraseniaSinEncriptar
            };
        }

        public static Usuario FromDto(UsuarioEditarDto usuario)
        {
            return new Usuario
            {
                Id = usuario.Id,
                //Email = usuario.Email,
                NombreCompleto = new NombreCompleto(usuario.Nombre, usuario.Apellido),
                Contrasenia = usuario.Contrasenia,
                ContraseniaSinEncriptar = usuario.Contrasenia
            };

        }

        public static void UpdateFromDto(UsuarioEditarDto usuarioDto, Usuario usuarioExistente)
        {

            usuarioExistente.NombreCompleto = new NombreCompleto(usuarioDto.Nombre, usuarioDto.Apellido);
            usuarioExistente.Contrasenia = usuarioDto.Contrasenia;
            usuarioExistente.ContraseniaSinEncriptar = usuarioDto.Contrasenia;

        }
    }
}
