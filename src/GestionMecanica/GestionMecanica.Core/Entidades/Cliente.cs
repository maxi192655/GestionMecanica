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
        public override string Rol => "Cliente";


        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }

        public List<Vehiculo> _Vehiculos { get; set; } = new();

        #region Constructores
        //public Cliente()
        //{   
        //}

        //Constructor para registro de cliente.
        public Cliente(
            string nombre, string email, string pwd, 
            string telefono, string direccion, string ciudad, 
            string estado, string codigoPostal, string pais, 
            bool validar = true
            ) : base(nombre, email, pwd)
        {
            Telefono = telefono;
            Direccion = direccion;
            Ciudad = ciudad;
            Estado = estado;
            CodigoPostal = codigoPostal;
            Pais = pais;

            if (validar)
                Validar();
        }

        //Constructor sin PWD.
        public static Cliente CrearDesdeDB(string nombre, string email, string telefono, string direccion, string ciudad, string estado, string codigoPostal, string pais)
        {
            return new Cliente(nombre, email,null, telefono, direccion, ciudad, estado, codigoPostal, pais, validar: false);
        }


        //TODO
        //public override string Rol => "Cliente";
        #endregion
        #region Validaciones
        //Validaciones
        public override void Validar()
        {
            //Validaciones de la clase base.
            base.Validar();

            //Validaciones de la clase hija.
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
        #endregion
    }
}

