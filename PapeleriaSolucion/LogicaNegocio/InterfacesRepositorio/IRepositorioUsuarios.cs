using LogicaNegocio.Entidades;
namespace LogicaNegocio.InterfacesRepositorio
{
	public interface IRepositorioUsuarios : IRepositorio<Usuario>
	{
		Usuario LoginUsuario(string email);

	}

}

