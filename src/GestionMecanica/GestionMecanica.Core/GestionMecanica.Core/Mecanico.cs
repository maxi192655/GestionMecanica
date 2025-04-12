using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core
{
    public class Mecanico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Especialidad Especialidad { get; set; }
        public List<Orden_Mecanico> OrdenesMecanicos { get; set; } = new();
    }
}
