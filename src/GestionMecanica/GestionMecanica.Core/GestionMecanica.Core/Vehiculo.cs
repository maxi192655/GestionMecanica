using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Modelo Modelo{ get; set; }
        public int Anio { get; set; }

    }
}
