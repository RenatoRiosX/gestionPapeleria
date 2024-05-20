using System.Collections;
using AccesoDatos.RepositorioEF;
using LogicaAplicacion.DTOs.ArticuloDTOs;
using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaAplicacion.DTOs.LineaPedidoDto;
using LogicaAplicacion.DTOs.PedidoDTOs;
using LogicaAplicacion.DTOsMappers.ArticulosMappers;
using LogicaAplicacion.DTOsMappers.ClienteMappers;
using LogicaAplicacion.ImplementacionCasosUsos.Articulos;
using LogicaAplicacion.ImplementacionCasosUsos.Clientes;
using LogicaAplicacion.ImplementacionCasosUsos.Pedidos;
using LogicaAplicacion.InterfacesCasosUsos.Articulos;
using LogicaAplicacion.InterfacesCasosUsos.Clientes;
using LogicaAplicacion.InterfacesCasosUsos.Pedidos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Web.ViewModels;


namespace Web.Controllers
{
    public class PedidoController : Controller
	{
		private IRepositorioPedidos _repositorioPedidos = new RepositorioPedidosEF();
		private IRepositorioArticulos _repositorioArticulos = new RepositorioArticulosEF();
		private IRepositorioClientes _repositorioClientes = new RepositorioClientesEF();
		private IRepositorioConfiguracion _repositorioConfiguracion = new RepositorioConfiguracionEF();
		
		private IGetAllPedidos _getAllPedidos;
		private IAltaPedido _altaPedido;
		private IBajaPedido _bajaPedido;
		private IGetAllClientes _getAllClientes;
		private IGetAllArticulos _getAllArticulos;
		private IGetClienteById _getById;
        private IGetPedidosPorFecha _getPedidosPorFecha;
        private IAnularPedido _anularPedido;

        public PedidoController()
		{
			_altaPedido = new AltaPedido(_repositorioPedidos, _repositorioConfiguracion);
			_bajaPedido = new BajaPedido(_repositorioPedidos);
			_getAllClientes = new GetAllClientes(_repositorioClientes);
			_getAllArticulos = new GetAllArticulos(_repositorioArticulos);
			_getById = new GetClienteById(_repositorioClientes);
			_getAllPedidos = new GetAllPedidos(_repositorioPedidos);
			_getPedidosPorFecha = new GetPedidosPorFecha(_repositorioPedidos);
            _anularPedido = new AnularPedido(_repositorioPedidos);
        }

		// GET: PedidoController
		public ActionResult Index()
		{
			return View();
		}


		// GET: PedidoController/CrearPedido
		public ActionResult CrearPedido()
		{

			IEnumerable<ArticuloDto> articulosDto = _getAllArticulos.Ejecutar();
			IEnumerable<ClienteDto> clientesDto = _getAllClientes.Ejecutar();

			var viewModel = new PedidoViewModel
			{
				Articulos = articulosDto,
				Clientes = clientesDto
			};

			ViewBag.ClearLocalStorage = true;

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult CrearPedido(PedidoViewModel pedidoViewModel)
		{
			try
			{
				ClienteCompletoDto clienteDto = _getById.Ejecutar(pedidoViewModel.ClienteId);

				if (clienteDto == null){
					throw new ClienteNoValidoException("El cliente ingresado no se encuentra en la base de datos.");
				}

                pedidoViewModel.LineasPedido = JsonConvert.DeserializeObject<List<LineaPedidoDto>>(Request.Form["LineasPedido"]);
                 
                if (pedidoViewModel.LineasPedido.Any(lineaPedido => lineaPedido.ArticuloDto.Stock < lineaPedido.Unidades)) {
	                throw new ArticuloNoValidoException("No hay stock suficiente para los artículos seleccionados.");
                }

				PedidoDto peditoDto = new PedidoDto 
				{
					Cliente = clienteDto,
					FechaPrometidaEntrega = pedidoViewModel.FechaPrometidaEntrega,
					LineasPedido = pedidoViewModel.LineasPedido
				};
				
				double costoTotal = _altaPedido.Ejecutar(peditoDto, pedidoViewModel.PedidoExpress);

				ViewBag.Mensaje = "Pedido creado correctamente. El costo total del pedido es: "+costoTotal;

				IEnumerable<ArticuloDto> articulosDto = _getAllArticulos.Ejecutar();
				IEnumerable<ClienteDto> clientesDto = _getAllClientes.Ejecutar();

				var viewModel = new PedidoViewModel
				{
					Articulos = articulosDto,
					Clientes = clientesDto
				};

				ViewBag.ClearLocalStorage = true;

				return View(viewModel);
			}
			catch (Exception ex)
			{
				//Si se produce un error, volvemos a cargar los datos de la vista
				IEnumerable<ArticuloDto> articulosDto = _getAllArticulos.Ejecutar();
				IEnumerable<ClienteDto> clientesDto = _getAllClientes.Ejecutar();

				pedidoViewModel.Articulos = articulosDto;
				pedidoViewModel.Clientes = clientesDto;

				ViewBag.Error = ex.Message;
				return View(pedidoViewModel);
			}
			
		}
        [HttpGet]
        public IActionResult ListarPedidosPendientesPorFecha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ListarPedidosPendientesPorFecha(DateTime fecha)
        {
            var pedidos = _getPedidosPorFecha.Ejecutar(fecha);
            return View(pedidos);
        }
        public IActionResult AnularPedido(int id)
        {
            _anularPedido.Ejecutar(id);
            TempData["Mensaje"] = "Pedido Anulado correctamente.";
            return RedirectToAction("ListarPedidosPendientesPorFecha");
        }

        
    }

}
