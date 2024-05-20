using System.ComponentModel.DataAnnotations;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.Entidades
{
	[Index(nameof(Email), IsUnique = true)]
	public class Usuario : IValidable, IEntity
	{
		
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "El email no es valido.")]

		public string Email { get; set; }

		public NombreCompleto NombreCompleto {get; set;}

        public string Contrasenia { get; set; }
        public string ContraseniaSinEncriptar { get; set; }


        public void EsValido()
		{

            // Expresión regular para validar el formato de correo electrónico
            var emailRegex = new System.Text.RegularExpressions.Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");

            if (string.IsNullOrEmpty(Email))
            {
                throw new UsuarioNoValidoExeption("Debe de ingresar un email.");
            }

            if (!emailRegex.IsMatch(Email))
            {
                throw new UsuarioNoValidoExeption("Email no cumple con los requisitos de formato.");
            }

            if (NombreCompleto == null ||  string.IsNullOrWhiteSpace(NombreCompleto.Nombre))
            {
                throw new UsuarioNoValidoExeption("El nombre del usuario no es valido.");
            }

            if (NombreCompleto == null || string.IsNullOrWhiteSpace(NombreCompleto.Apellido))
            {
                throw new UsuarioNoValidoExeption("El apellido del usuario no es valido.");
            }

            
            if (!EsContraseniaValida(Contrasenia)){
                throw new UsuarioNoValidoExeption("La contraseña debe tener al menos 6 caracteres, al menos una minuscula, una mayuscula, un digito y un caracter de puntuacion.");
            }
        }

        private bool EsContraseniaValida(string contrasenia)
        {
            return contrasenia.Length >= 6
                && contrasenia.Any(char.IsLower)
                && contrasenia.Any(char.IsUpper)
                && contrasenia.Any(char.IsDigit)
                && contrasenia.Any(char.IsPunctuation);
        }


    }

}

