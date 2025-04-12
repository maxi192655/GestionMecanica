using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core
{
    public class OrdenMecanico
    {
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }
        public int MecanicoId { get; set; }
        public Mecanico Mecanico { get; set; }
    }
}
