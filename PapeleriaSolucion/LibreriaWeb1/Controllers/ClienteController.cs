using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccesoDatos.RepositorioEF;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosUsos.Clientes;
using LogicaAplicacion.ImplementacionCasosUsos.Clientes;
using LogicaAplicacion.DTOs.ClienteDTOs;
using NuGet.Packaging;

namespace Web.Controllers
{
    public class ClienteController : Controller
    {

        private IRepositorioClientes _repositorioClientes;
        private IBuscarClientePorRazonSocial _buscarCliente;
        private IBuscarClientePorMonto _buscarClientePorMonto;
        private IGetAllClientes _getAllClientes;

        public ClienteController(IRepositorioClientes repositorioClientes, IBuscarClientePorRazonSocial buscarClientePorRazonSocial, 
            IBuscarClientePorMonto buscarClientePorMonto, IGetAllClientes getAllClientes)
        {
            _repositorioClientes = repositorioClientes;
            _buscarCliente = buscarClientePorRazonSocial;
            _buscarClientePorMonto = buscarClientePorMonto;
            _getAllClientes = getAllClientes;
        }

        public ActionResult ListarCliente()
        {
            IEnumerable<ClienteDto> clientes = _getAllClientes.Ejecutar();
            return View(clientes);
        }

        [HttpPost]
        public ActionResult BuscarCliente(string razonSocial, double monto)
        {
            IEnumerable <ClienteDto> clientes = new List<ClienteDto>();
            try
            {
                if (!string.IsNullOrEmpty(razonSocial))
                {
                    ClienteDto cliente = _buscarCliente.GetByRazon(razonSocial);
                    clientes = new List<ClienteDto> { cliente };
                }

                if (monto > 0)
                {
                    IEnumerable <ClienteDto> clientePedidosSuperanMonto = _buscarClientePorMonto.GetByMonto(monto);
                    clientes = clientePedidosSuperanMonto;
                }

                TempData["Mensaje"] = "Búsqueda realizada con éxito";
                return View("ListarCliente", clientes);
            }catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("ListarCliente");
            }
            
        }

    }

}
