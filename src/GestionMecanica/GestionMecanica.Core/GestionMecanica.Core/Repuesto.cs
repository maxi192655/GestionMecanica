using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core
{
    public class Repuesto : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }

        public void Validar()
        {
            ValidarStock();
            ValidarNombre();
            ValidarPrecio();
        }

        private void ValidarPrecio()
        {
            if (Precio <= 0) throw new Exception("El precio no puede ser negativo.");
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre)) throw new Exception("El nombre del repuesto no puede estar vacio.");
        }

        private void ValidarStock()
        {
            if (Stock < 0) throw new Exception("El esto no puede ser negativo.");
        }
    }
}
