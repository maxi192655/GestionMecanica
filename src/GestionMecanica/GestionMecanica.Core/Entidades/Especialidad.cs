using GestionMecanica.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core.Entidades
{
    public class Especialidad : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Especialidad()
        {         
        }
        public Especialidad(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;            
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre de la especialidad no puede estar vacío.");
            }
        }
    }
}
