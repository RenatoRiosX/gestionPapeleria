using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.UsuarioDTOs;

namespace LogicaAplicacion.InterfacesCasosUsos.Usuarios
{
    public interface IAltaUsuario
    {
        void Ejecutar(UsuarioAltaDto usuarioDto);
    }
}
