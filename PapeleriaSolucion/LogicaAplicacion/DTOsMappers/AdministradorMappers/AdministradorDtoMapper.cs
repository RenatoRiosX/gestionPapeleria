using LogicaAplicacion.DTOs.AdministradorDTOs;
using LogicaNegocio.Entidades;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs.ValueObjectsDTOs;
using LogicaNegocio.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.DTOsMappers.AdministradorMappers
{
    public class AdministradorDtoMapper
    {
        public static AdministradorDto toDto(Administrador admin) {

            return new AdministradorDto
            {
                Id = admin.Id,
                Email = admin.Email,
                Nombre = admin.NombreCompleto.Nombre,
                Apellido = admin.NombreCompleto.Apellido,
                Contrasenia = admin.Contrasenia

            };
        }

        public static Administrador FromDto(AdministradorDto admin)
        {
            return new Administrador 
            {
                Id = admin.Id,
                Email = admin.Email,
                NombreCompleto = new NombreCompleto(admin.Nombre, admin.Apellido),
                Contrasenia = admin.Contrasenia
            };

        }
 
    }
}
