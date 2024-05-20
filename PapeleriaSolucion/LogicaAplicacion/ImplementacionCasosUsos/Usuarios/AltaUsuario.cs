using LogicaAplicacion.InterfacesCasosUsos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.UsuarioDTOs;
using LogicaAplicacion.DTOsMappers.UsuarioMappers;
using LogicaNegocio.InterfacesEntidades;


namespace LogicaAplicacion.ImplementacionCasosUsos.Usuarios
{
    public class AltaUsuario : IAltaUsuario, IEncriptacion
    {
        private IRepositorioUsuarios _repositorioUsuarios;
        public AltaUsuario(IRepositorioUsuarios repo)
        {
            _repositorioUsuarios = repo;
        }

        public void Ejecutar(UsuarioAltaDto usuarioAltaDto)
        {
            if (usuarioAltaDto != null)
            {
               Usuario usuarioNuevo = UsuarioAltaDtoMapper.FromDto(usuarioAltaDto);
               usuarioNuevo.Contrasenia = EncriptarContrasenia(usuarioNuevo.Contrasenia);
                _repositorioUsuarios.Add(usuarioNuevo);
            }

        }

        public string EncriptarContrasenia(string contrasenia)
        {
            return BCrypt.Net.BCrypt.HashPassword(contrasenia);
        }
    }
}
