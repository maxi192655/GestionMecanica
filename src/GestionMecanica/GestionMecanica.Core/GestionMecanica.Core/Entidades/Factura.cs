using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core.Entidades
{
    public class Factura
    {
        public int Id { get; set; }
        public Orden Orden { get; set; }
        public decimal Total { get; set; }
        public DateTime FEmision { get; set; }
        public Estado Estado { get; set; } = Estado.Pendiente;
    }
}
