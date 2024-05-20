using AccesoDatos.RepositorioEF;
using LogicaAplicacion.DTOs.UsuarioDTOs;
using LogicaAplicacion.ImplementacionCasosUsos.Usuarios;
using LogicaAplicacion.InterfacesCasosUsos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using LogicaAplicacion.DTOsMappers.UsuarioMappers;
using LogicaNegocio.Excepciones;
using LogicaAplicacion.InterfacesCasosUsos.Clientes;

namespace Web.Controllers
{
    public class AdministradorController : Controller
    {
        private IRepositorioUsuarios _repositorioUsuarios = new RepositorioUsuariosEF();
		private IAltaUsuario _alta;
        private IEditarUsuario _editarUsuario;
        private IBajaUsuario _baja;
        

        public AdministradorController()
        {
           _alta = new AltaUsuario(_repositorioUsuarios);
           _baja = new BajaUsuario(_repositorioUsuarios);
           _editarUsuario = new EditarUsuario(_repositorioUsuarios);
           
        }
        // GET: AdministradorController
        public ActionResult Index()
        {
            return View();
        }


        // GET: AdministradorController/CrearUsuario
        public ActionResult CrearUsuario()
        {
            return View();
        }

        // POST: AdministradorController/CrearUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearUsuario(UsuarioAltaDto usuarioNuevo)
        {
            int? idUsuarioLogeado = HttpContext.Session.GetInt32("LogueadoId");
            Usuario usuarioLogueado = _repositorioUsuarios.GetById(idUsuarioLogeado.Value);
            if (usuarioLogueado is Administrador administrador)
            {
                try
                {
                    _alta.Ejecutar(usuarioNuevo);
                    TempData["Mensaje"] = "Usuario Creado";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
            }
            else
            {
                TempData["Error"] = "Debe ser administrador para poder crear usuarios";
            }
            return View();
                
        }

        public ActionResult ListarUsuarios()
        {
           IEnumerable<Usuario> usuarios = _repositorioUsuarios.GetAll();
            return View(usuarios);
        }

        // GET: AdministradorController/EditarUsuario
        public ActionResult EditarUsuario()
        {
            return View();
        }

        // POST: AdministradorController/EditarUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(UsuarioEditarDto usuarioDto)
        {
            int? idUsuarioLogeado = HttpContext.Session.GetInt32("LogueadoId");
            Usuario usuarioLogueado = _repositorioUsuarios.GetById(idUsuarioLogeado.Value);
            if (usuarioLogueado is Administrador administrador)
            {
                if (administrador.Autorizado == true)
                {
                    try
                    {
                        _editarUsuario.Ejecutar(usuarioDto);
                        TempData["Mensaje"] = "Usuario editado con exito.";
                        return RedirectToAction("EditarUsuario", "Administrador");
                    }
                    catch (Exception ex)
                    {
                        TempData["Error"] = ex.Message;
                        return View();
                    }
                }
                else
                {
                    TempData["Error"] = "El Administrador No esta autorizado  ";
                    return RedirectToAction("EditarUsuario", "Administrador");
                }
            }
            else
            {
                TempData["Error"] = "El Usuario No es Administrador autorizado ";
                return RedirectToAction("EditarUsuario", "Administrador");
            }
        }

        // GET: AdministradorController/EliminarUsuario
        public ActionResult EliminarUsuario(int id)
        {
            int? idUsuarioLogeado = HttpContext.Session.GetInt32("LogueadoId");
            Usuario usuarioLogueado = _repositorioUsuarios.GetById(idUsuarioLogeado.Value);
            if (usuarioLogueado is Administrador administrador)
            {
              
                    try
                    {
                        Usuario usuarioAEliminar = _repositorioUsuarios.GetById(id);

                        if (usuarioAEliminar == null)
                        {
                            return NotFound();
                        }
                        TempData["Mensaje"] = "Usuario Eliminado";
                        _baja.Ejecutar(usuarioAEliminar);

                        return RedirectToAction("ListarUsuarios", "Administrador");
                    }
                    catch (Exception ex)
                    {
                        return View("Error", new { mensaje = ex.Message });
                    }
                
               
            }
            else
            {
                TempData["Error"] = "El Usuario No es Administrador ";
                return RedirectToAction("ListarUsuarios", "Administrador");
            }
        }

    }
    
}
