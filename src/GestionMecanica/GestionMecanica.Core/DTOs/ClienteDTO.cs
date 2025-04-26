using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.Core.DTOs
{
    public class ClienteDTO
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
    }
}
