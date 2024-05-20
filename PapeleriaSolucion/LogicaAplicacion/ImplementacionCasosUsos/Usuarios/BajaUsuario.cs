using LogicaAplicacion.InterfacesCasosUsos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUsos.Usuarios
{
    public class BajaUsuario : IBajaUsuario
    {
        private IRepositorioUsuarios _repositorioUsuarios;
        public BajaUsuario(IRepositorioUsuarios repo)
        {
            _repositorioUsuarios = repo;
        }
        public void Ejecutar(Usuario usuario)
        {
            if (usuario != null)
            {
                // Aquí puedes realizar validaciones adicionales antes de eliminar el usuario si es necesario
                _repositorioUsuarios.Remove(usuario);
            }
            else
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario proporcionado es nulo.");
            }
        }
    }
}
