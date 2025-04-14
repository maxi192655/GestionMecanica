using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core.Entidades
{
    public class Mecanico : Usuario
    {
        //TODO
        public int Id { get; set; }
        public Especialidad Especialidad { get; set; }
        public List<OrdenMecanico> OrdenesMecanicos { get; set; } = new();
    }
}
