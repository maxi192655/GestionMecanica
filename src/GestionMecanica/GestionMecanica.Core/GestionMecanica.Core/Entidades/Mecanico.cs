using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core.Entidades
{
    public class Mecanico : Usuario
    {
        public override string Rol => "Mecanico";

        public Especialidad Especialidad { get; set; }
        public List<OrdenMecanico> OrdenesMecanicos { get; set; } = new();

        public override void Validar()
        {
            base.Validar();
            
            ValidarEspecialidad();
        }

        private void ValidarEspecialidad()
        {
            if (Especialidad == null)
            {
                throw new Exception("La especialidad del mecanico no puede estar vacia");
            }
        }
    }
}
