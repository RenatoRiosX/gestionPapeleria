using AccesoDatos.RepositorioEF;
using LogicaAplicacion.DTOs.UsuarioDTOs;
using LogicaAplicacion.ImplementacionCasosUsos.Usuarios;
using LogicaAplicacion.InterfacesCasosUsos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;


namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        private IRepositorioUsuarios _repositorioUsuarios = new RepositorioUsuariosEF();
        private ILogin _login;
        public UsuarioController()
        {
            _login = new Login(_repositorioUsuarios);
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(UsuarioLoginDto usuario)
        {
	        try
	        {
		        UsuarioDto u = _login.Ejecutar(usuario);

		        if (u != null)
		        {
			        //Creacion de variables de sesion
			        HttpContext.Session.SetString("LogueadoEmail", u.Email);
			        HttpContext.Session.SetInt32("LogueadoId", u.Id);

			        return RedirectToAction("Index", "Home");
		        }
		        else
		        {
			        ViewBag.Error = "Ocurrio un error con los datos ingresados, vuelva a intentarlo.";
			        return View();
		        }
			}
	        catch (Exception ex)
	        {
		        ViewBag.Error = ex.Message;
		        return View();
			}
	        
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
        }
    }

}
