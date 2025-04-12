using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core
{
    public class Orden
    {
        public int Id { get; set; }
        public static DateTime FIngreso { get; set; } = DateTime.Now;
        public Vehiculo Vehiculo { get; set; }
        public Estado Estado { get; set; } = Estado.Pendiente;
        public DetalleOrden Detalle { get; set; }
        public Reparacion Reparacion { get; set; }
        public List<Orden_Mecanico> OrdenesMecanicos { get; set; } = new();
    }
}
