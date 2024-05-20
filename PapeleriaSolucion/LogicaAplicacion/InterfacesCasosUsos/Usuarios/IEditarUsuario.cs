using LogicaAplicacion.DTOs.UsuarioDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUsos.Usuarios
{
    public interface IEditarUsuario
    {
        void Ejecutar(UsuarioEditarDto usuarioDto);
    }
}
