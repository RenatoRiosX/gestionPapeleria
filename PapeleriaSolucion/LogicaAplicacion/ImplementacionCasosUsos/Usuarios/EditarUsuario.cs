using LogicaAplicacion.DTOs.UsuarioDTOs;
using LogicaAplicacion.DTOsMappers.UsuarioMappers;
using LogicaAplicacion.InterfacesCasosUsos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.InterfacesEntidades;

namespace LogicaAplicacion.ImplementacionCasosUsos.Usuarios
{
    public class EditarUsuario : IEditarUsuario, IEncriptacion
    {
        private IRepositorioUsuarios _repositorioUsuarios;
        public EditarUsuario(IRepositorioUsuarios repo)
        {
            _repositorioUsuarios = repo;
        }
        public void Ejecutar(UsuarioEditarDto usuarioDto)
        {
            if (usuarioDto != null)
            {
                
                Usuario usuarioExistente = _repositorioUsuarios.GetById(usuarioDto.Id);

                
                //Actualiza el Usuario existente con los datos del DTO
                UsuarioEditarDtoMapper.UpdateFromDto(usuarioDto, usuarioExistente);
                usuarioExistente.Contrasenia = EncriptarContrasenia(usuarioDto.Contrasenia);
                usuarioExistente.EsValido();

                _repositorioUsuarios.Update(usuarioExistente);

            }
        }

        public string EncriptarContrasenia(string contrasenia)
        {
            return BCrypt.Net.BCrypt.HashPassword(contrasenia);
        }
    }
}
