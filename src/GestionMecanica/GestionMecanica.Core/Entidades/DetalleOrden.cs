using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core.Entidades
{
    public class DetalleOrden
    {
        public int Id { get; set; }
        public Repuesto Repuesto { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public Orden Orden { get; set; }

    }
}
