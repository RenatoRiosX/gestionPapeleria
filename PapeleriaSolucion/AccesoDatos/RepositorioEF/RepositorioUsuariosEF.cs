using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.RepositorioEF;

public class RepositorioUsuariosEF : IRepositorioUsuarios
{
    private readonly Context _db;

    public RepositorioUsuariosEF()
    {
        _db = new Context();
    }

	public void Add(Usuario usuarioNuevo)
    {
        
        try
        {
            if (usuarioNuevo == null)
            {
                throw new UsuarioNoValidoExeption();
            }
           
            usuarioNuevo.EsValido();
            _db.Usuarios.Add(usuarioNuevo);
            _db.SaveChanges();
        }
        catch (UsuarioNoValidoExeption ex)
        {
                throw new UsuarioNoValidoExeption("El Usuario no es valido.");
        }
    }



    public Usuario GetById(int id)
    {
        Usuario usuario = _db.Usuarios.FirstOrDefault(u => u.Id == id);
         
        if (usuario == null)
        {
            throw new Exception($"Usuario con ID {id} no encontrado");
        }

        return usuario;
    }

    public IEnumerable<Usuario> GetAll()
    {

        return _db.Usuarios.ToList();
    }


    public Usuario LoginUsuario(string email)
    {
        return _db.Usuarios.FirstOrDefault(u => u.Email == email);
    }

    public void Remove(int id)
    {
        var usuario = _db.Usuarios.FirstOrDefault(u => u.Id == id);

        if (usuario == null)
        {
            throw new Exception($"Usuario con ID {id} no encontrado");
        }

        _db.Usuarios.Remove(usuario);
        _db.SaveChanges();
    }

    public void Remove(Usuario unObjeto)
    {
        if (unObjeto == null)
            throw new UsuarioNoValidoExeption("El usuario es nulo");

        try
        {
            _db.Usuarios.Remove(unObjeto);
            _db.SaveChanges();
        }
        catch (UsuarioNoValidoExeption ex)
        {
            throw new UsuarioNoValidoExeption("El Usuario No Es Valido");
        }
    }

    public void Update(Usuario usuarioNuevo)
    {

        try
        {
            if (usuarioNuevo == null)
            {
                throw new UsuarioNoValidoExeption("El usuario no puede ser null.");
            }
            usuarioNuevo.EsValido();

            // Busca el usuario existente en la base de datos
            var usuarioExistente = _db.Usuarios.Find(usuarioNuevo.Id);
            if (usuarioExistente == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            // Actualiza los valores del usuario existente con los del nuevo usuario
            _db.Entry(usuarioExistente).CurrentValues.SetValues(usuarioNuevo);

            //usuarioExistente.Email = usuarioNuevo.Email;
            //usuarioExistente.NombreCompleto = usuarioNuevo.NombreCompleto;
            //usuarioExistente.Contrasenia = usuarioNuevo.Contrasenia;
            //usuarioExistente.ContraseniaSinEncriptar = usuarioNuevo.ContraseniaSinEncriptar;
            _db.SaveChanges();
        }
        catch (UsuarioNoValidoExeption ex)
        {
            throw ex;
        }
    }
}

