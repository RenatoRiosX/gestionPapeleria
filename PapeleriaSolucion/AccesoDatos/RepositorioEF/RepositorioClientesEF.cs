using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ClienteDTOs;
using LogicaAplicacion.DTOsMappers.ClienteMappers;

namespace AccesoDatos.RepositorioEF
{
    public class RepositorioClientesEF : IRepositorioClientes
    {
	    private Context _db;

        public RepositorioClientesEF()
        {
            _db = new Context();
        }

        public void Add(Cliente unObjeto)
        {
            throw new NotImplementedException();
        }

        public Cliente GetByRazonSocial(string razon)
        {
            Cliente cliente = _db.Clientes.FirstOrDefault(c => c.RazonSocial.Contains(razon));

            if (cliente == null)
            {
                throw new Exception($"No fue encontrado un cliente con razon social: {razon}.");
            }

            return cliente;
        }

        public IEnumerable<Cliente> GetByMonto(double monto)
        {
            IEnumerable<Cliente> clientes = _db.Clientes
	        .GroupJoin(_db.Pedidos,
	                   cliente => cliente.Id,
	                   pedido => pedido.Cliente.Id,
	                   (cliente, pedidos) => new { Cliente = cliente, Pedidos = pedidos })
	        .Select(g => new
	        {
	            Cliente = g.Cliente,
	            CostoTotal = g.Pedidos.Sum(p => p.CostoTotalPedido)
	        })
	        .Where(c => c.CostoTotal > monto)
	        .Select(c => c.Cliente)
	        .ToList();
            return clientes;
        }

        public Cliente GetById(int id)
        {
            return _db.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _db.Clientes.ToList();
        }


        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Cliente unObjeto)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente unObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
