using GestionMecanica.Core.Interface;
using System.ComponentModel.DataAnnotations;

namespace GestionMecanica.Core.Entidades
{
    public abstract class Usuario : IValidable
    {
        //TODO

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Pwd { get; set; }

        public virtual string Rol => GetType().Name;

        public virtual void Validar()
        {
            ValidarNombre();
            ValidarEmail();
            ValidarPwd();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new Exception("El nombre del cliente no puede estar vacio");
            }
        }

        private void ValidarEmail()
        {
            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
            {
                throw new Exception("El email del cliente no es valido");
            }
        }

        private void ValidarPwd()
        {
            if (string.IsNullOrWhiteSpace(Pwd))
            {
                throw new Exception("La contraseña del cliente no puede estar vacia");
            }
        }
    }
}