using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.Entidades;

namespace LogicaNegocio.ValueObjects
{
    [ComplexType]
    public record Direccion
    {
        public string Calle { get; set; }

        public int Numero {get; set;}

        public string Ciudad {get; set;}

        public double DistanciaPapeleria {get; set;}

        public Cliente cliente {get; set;}
        //TODO: Verficar si es necesario agregar el cliente

    }

}

