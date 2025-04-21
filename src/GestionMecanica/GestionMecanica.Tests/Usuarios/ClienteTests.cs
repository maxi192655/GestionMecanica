using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMecanica.Core.Entidades;

namespace GestionMecanica.Tests.Usuarios
{
    public class ClienteTests
    {
        [Fact]
        public void CrearCliente_ConDatosValidos_CreaCliente()
        {
            // Arrange
            var cliente = new Cliente("Juan Pérez", "juan@gmail.com","pwd1234", "987654321", "Calle Falsa 123", "Montepio","Pepex","11800","PaisFalso");
            // Act

            // Assert
            Assert.Equal("juan@gmail.com", cliente.Email);
            Assert.Equal("pwd1234", cliente.Pwd); // si tenés esa propiedad
            Assert.Equal("Calle Falsa 123", cliente.Direccion);

        }
    }
}
