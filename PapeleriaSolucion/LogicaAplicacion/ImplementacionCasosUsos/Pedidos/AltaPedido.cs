using LogicaAplicacion.InterfacesCasosUsos.Pedidos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.PedidoDTOs;
using LogicaAplicacion.DTOsMappers.PedidoMappers;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.ImplementacionCasosUsos.Pedidos
{
    public class AltaPedido : IAltaPedido
    {
	    private IRepositorioPedidos _repositorioPedidos;
		private IRepositorioConfiguracion _repositorioConfiguracion;

	    public AltaPedido(IRepositorioPedidos repositorioPedidos, IRepositorioConfiguracion repositorioConfiguracion)
	    {
		    _repositorioPedidos = repositorioPedidos;
			_repositorioConfiguracion = repositorioConfiguracion;

		}

	    public double Ejecutar(PedidoDto pedido, bool esExpress)
        {
	        if (pedido != null)
	        {
		        Pedido pedidoNuevo;
		        if (esExpress) {
			        pedidoNuevo = PedidoExpressDtoMapper.FromDto(pedido);
		        }else {
			        pedidoNuevo = PedidoComunDtoMapper.FromDto(pedido);
		        }
		        double iva = _repositorioConfiguracion.GetValueByName("IVA");
				double costoTotal = pedidoNuevo.CalcularTotal();
				costoTotal = costoTotal + (costoTotal * iva);
				pedidoNuevo.CostoTotalPedido = costoTotal;

				pedidoNuevo.EsValido();
				_repositorioPedidos.Add(pedidoNuevo);

				return costoTotal;
	        }
	        else
	        {
		        throw new PedidoNoValidoException("El pedido no puede ser nulo.");
	        }
	       
        }
    }
}
