using System.ComponentModel.DataAnnotations;

namespace GestionMecanica.Core
{
    public class Cliente : IValidable
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }
        public string Telefono { get; set; }
        public List<Vehiculo> _Vehiculos { get; set; } = new();

        public void Validar()
        {
            ValidarNombre();
            ValidarEmail();
            ValidarTelefono();
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

        private void ValidarTelefono()
        {
            if (string.IsNullOrWhiteSpace(Telefono))
                throw new Exception("El telefono del cliente no puede estar vació");
        }
    }
}