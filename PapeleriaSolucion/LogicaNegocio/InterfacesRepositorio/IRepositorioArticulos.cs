using LogicaNegocio.Entidades;
namespace LogicaNegocio.InterfacesRepositorio
{
	public interface IRepositorioArticulos : IRepositorio<Articulo>
	{
		void AumentarStock();

		void DisminuirStock();

	}

}

