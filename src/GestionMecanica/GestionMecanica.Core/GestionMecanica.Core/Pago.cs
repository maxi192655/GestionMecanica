using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core
{
    public class Pago
    {
        public int Id { get; set; }
        public Factura Factura { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FPago { get; set; }
        public MetodoPago MetodoPago { get; set; }

    }
}
