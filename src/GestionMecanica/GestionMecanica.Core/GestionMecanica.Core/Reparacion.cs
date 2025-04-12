using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core
{
    public class Reparacion : IValidable
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Descripcion)) throw new Exception("La descripcion del arreglo no puede estar vacia");
        }
    }
}
