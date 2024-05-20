using LogicaAplicacion.InterfacesCasosUsos.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.UsuarioDTOs;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaAplicacion.DTOsMappers.UsuarioMappers;
using System.Collections;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.Excepciones;

namespace LogicaAplicacion.ImplementacionCasosUsos.Usuarios
{
    public class Login : ILogin, IVerificarContrasenia
    {
        private IRepositorioUsuarios _repositorioUsuarios;
        public Login(IRepositorioUsuarios repo)
        {
            _repositorioUsuarios = repo;
        }

		public UsuarioDto Ejecutar(UsuarioLoginDto dto)
		{
			try
			{
				if (string.IsNullOrEmpty(dto.Email))
				{
					throw new UsuarioNoValidoExeption("Debe de ingresar un email.");
				}

				if (string.IsNullOrEmpty(dto.Contrasenia))
				{
					throw new UsuarioNoValidoExeption("Debe de ingresar una contraseña.");
				}

				Usuario usuario = _repositorioUsuarios.LoginUsuario(dto.Email);

				if (usuario == null)
				{
					throw new UsuarioNoValidoExeption("El usuario ingresado no existe en la base de datos.");
				}

				UsuarioDto usuarioDto = null;

                if (VerificarContrasenia(dto.Contrasenia, usuario.Contrasenia))
				{
					usuarioDto = UsuarioDtoMapper.toDto(usuario);
				}
				return usuarioDto;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public bool VerificarContrasenia(string contrasenia, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(contrasenia, hash);
        }

    }
}
