using GestionMecanica.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core.Entidades
{
    public class Modelo : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; } // Nombre del modelo
        public Marca Marca { get; set; } //Relacion con la marca

        public void Validar()
        {
            ValidarNombre();
            Marca.Validar();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre)) { throw new Exception("El nombre del modelo, no es valido"); }
        }
    }
}
