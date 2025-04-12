using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core
{
    public class Marca : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        
        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre)) { throw new Exception("El nombre de la marca no es valido."); }
        }

    }
}
