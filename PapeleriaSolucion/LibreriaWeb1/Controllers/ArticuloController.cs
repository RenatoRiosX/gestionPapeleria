using AccesoDatos.RepositorioEF;
using LogicaAplicacion.DTOs.ArticuloDTOs;
using LogicaAplicacion.ImplementacionCasosUsos.Articulos;
using LogicaAplicacion.ImplementacionCasosUsos.Usuarios;
using LogicaAplicacion.InterfacesCasosUsos.Articulos;
using LogicaAplicacion.InterfacesCasosUsos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ArticuloController : Controller
    {

        private IRepositorioArticulos _repositorioArticulos;
        private IAltaArticulo _alta;
        private IGetAllArticulos _getAllArticulos;

        public ArticuloController(IRepositorioArticulos repositorioArticulos, IAltaArticulo altaArticulo, IGetAllArticulos getAllArticulos)
        {
            _repositorioArticulos = repositorioArticulos;
            _alta = altaArticulo;
            _getAllArticulos = getAllArticulos;

        }

        // GET: ArticuloController/ListarArticulos/
        public ActionResult ListarArticulos()
        {
            IEnumerable<ArticuloDto> articulos = _getAllArticulos.Ejecutar();
            return View(articulos);
        }

        // GET: ArticuloController/CrearArticulo
        public ActionResult CrearArticulo()
        {
            return View();
        }

        // POST: ArticuloController/CrearArticulo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearArticulo(ArticuloDto articuloDto)
        {
            try
            {
                _alta.Ejecutar(articuloDto);
                TempData["Mensaje"] = "Articulo Creado";
                return RedirectToAction(nameof(CrearArticulo));
            }
            catch(Exception ex) {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        
    }
}
