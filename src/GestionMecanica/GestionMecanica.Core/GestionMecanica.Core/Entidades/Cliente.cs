using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core.Entidades
{
    public class Cliente : Usuario
    {
        //TODO

        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }

        public List<Vehiculo> _Vehiculos { get; set; } = new();
        
        public override void Validar()
        {
            base.Validar();
            ValidarTelefono();
            ValidarDireccion();
            ValidarCiudad();
            ValidarEstado();
            ValidarCodigoPostal();
            ValidarPais();
        }
        private void ValidarTelefono()
        {
            if (string.IsNullOrWhiteSpace(Telefono))
                throw new Exception("El telefono del cliente no puede estar vacio");
        }
        private void ValidarDireccion()
        {
            if (string.IsNullOrWhiteSpace(Direccion))
                throw new Exception("La direccion del cliente no puede estar vacia");
        }
        private void ValidarCiudad()
        {
            if (string.IsNullOrWhiteSpace(Ciudad))
                throw new Exception("La ciudad del cliente no puede estar vacia");
        }
        private void ValidarEstado()
        {
            if (string.IsNullOrWhiteSpace(Estado))
                throw new Exception("El estado del cliente no puede estar vacio");
        }
        private void ValidarCodigoPostal()
        {
            if (string.IsNullOrWhiteSpace(CodigoPostal))
                throw new Exception("El codigo postal del cliente no puede estar vacio");
        }
        private void ValidarPais()
        {
            if (string.IsNullOrWhiteSpace(Pais))
                throw new Exception("El pais del cliente no puede estar vacio");
        }
    }
}

