using AccesoDatos.RepositorioEF;
using LogicaAplicacion.DTOs.PedidoDTOs;
using LogicaAplicacion.ImplementacionCasosUsos.Pedidos;
using LogicaAplicacion.InterfacesCasosUsos.Pedidos;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        IRepositorioPedidos _repositorioPedidos = new RepositorioPedidosEF();
        IObtenerPedidosAnulados _obtenerPedidosAnulados;

        public PedidoController()
        {
            _obtenerPedidosAnulados = new ObtenerPedidosAnulados(_repositorioPedidos);
        }

        // GET: api/<PedidoController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult GetPedidosAnulados()
        {
            try
            {
                IEnumerable<PedidoParaListaDto> pedidos = _obtenerPedidosAnulados.Ejecutar();
                if (pedidos.Any())
                {
                    return Ok(pedidos);
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
