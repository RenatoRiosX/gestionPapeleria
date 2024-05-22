using AccesoDatos.RepositorioEF;
using LogicaAplicacion.DTOs.ArticuloDTOs;
using LogicaAplicacion.ImplementacionCasosUsos.Articulos;
using LogicaAplicacion.InterfacesCasosUsos.Articulos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticuloController : ControllerBase
	{

        private readonly IRepositorioArticulos _repositorioArticulos;
        private readonly IMostrarArticulos _mostrarArticulos;

        public ArticuloController(IRepositorioArticulos repositorioArticulos, IMostrarArticulos mostrarArticulos)
        {
            _repositorioArticulos = repositorioArticulos;
            _mostrarArticulos = mostrarArticulos;
        }

        // GET: api/<ArticuloController>
        [HttpGet]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult ListarArticulos()
		{
			
			try
			{
				IEnumerable<ArticuloDto> articulos = _mostrarArticulos.Ejecutar();
				if (articulos.Any())
				{
					return Ok(articulos);
				}

				return NoContent();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		

	}
}
