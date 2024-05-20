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
    public class UsuarioAltaDtoMapper
    {
        public static UsuarioAltaDto toDto(Usuario usuario)
        {

            return new UsuarioAltaDto
            {
                
                Email = usuario.Email,
                Nombre = usuario.NombreCompleto.Nombre,
                Apellido = usuario.NombreCompleto.Apellido,
                Contrasenia = usuario.Contrasenia,
                ContraseniaSinEncriptar = usuario.Contrasenia

            };
        }

        public static Usuario FromDto(UsuarioAltaDto usuario)
        {
            return new Usuario
            {
                Email = usuario.Email,
                NombreCompleto = new NombreCompleto(usuario.Nombre, usuario.Apellido),
                Contrasenia = usuario.Contrasenia,
                ContraseniaSinEncriptar = usuario.Contrasenia
            };

        }
    }
}
