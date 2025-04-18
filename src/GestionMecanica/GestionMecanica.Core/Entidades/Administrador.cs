using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core.Entidades
{
    public class Administrador : Usuario
    {
        //public Administrador()
        //{
        //}
        public string Area { get; set; }

        public Administrador(string nombre, string email, string pwd, string area) : base(nombre, email, pwd)
        {

        }

        //TODO
        public override string Rol => "Administrador";





        public override void Validar()
        {
            base.Validar();
            ValidarArea();
        }

        private void ValidarArea()
        {
            if(string.IsNullOrWhiteSpace(Area))
            {
                throw new Exception("El area del administrador no puede estar vacia");
            }
        }
    }
}
