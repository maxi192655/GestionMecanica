using GestionMecanica.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core.Entidades
{
    public class Vehiculo : IValidable
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Modelo Modelo{ get; set; }
        public int Anio { get; set; }     

        public void Validar()
        {
            ValidarCliente();
            ValidarAnio();
            ValidarModelo();

            //Validaciones externas a la clase.
            Cliente.Validar();
            Modelo.Validar();
        }

        private void ValidarCliente()
        {
            if (Cliente == null)
                throw new Exception("El vehículo debe tener un cliente asignado.");
        }

        private void ValidarModelo()
        {
            if (Modelo == null) throw new Exception("El modelo no puede estar vació");
        }

        private void ValidarAnio()
        {
            if (Anio < 1900 || Anio > DateTime.Now.Year + 1) throw new Exception("El año del vehículo no es válido.");
        }
    }
}
