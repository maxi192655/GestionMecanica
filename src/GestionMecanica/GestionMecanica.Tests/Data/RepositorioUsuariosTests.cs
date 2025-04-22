using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMecanica.Core.Entidades;
using GestionMecanica.Data.Repositorios;
using Xunit;

namespace GestionMecanica.Tests.Data
{
    public class RepositorioUsuariosTests
    {
        [Fact]
        public void InsertAndGetCliente() {
            // Arrange
            var repositorio = new RepositorioUsuarios();
            var cliente = new Cliente(
                nombre: "Test Clien1te",
                email: "test_cliente@example.com",
                pwd: "pwd1234",
                telefono: "123456789",
                direccion: "Calle Falsa 123",
                ciudad: "Ciudad Test",
                estado: "Estado Test",
                codigoPostal: "12345",
                pais: "Testland"
            );

            repositorio.InsertarCliente(cliente);
            var clienteObtenido = repositorio.GetClientePorMail(cliente.Email);

            // Assert
            Assert.NotNull(clienteObtenido);
            Assert.Equal("Test Clien1te", clienteObtenido.Nombre);
            Assert.Equal("test_cliente@example.com", clienteObtenido.Email);
            Assert.Equal("123456789", clienteObtenido.Telefono);
            Assert.Equal("Calle Falsa 123", clienteObtenido.Direccion);
            Assert.Equal("Ciudad Test", clienteObtenido.Ciudad);
            Assert.Equal("Estado Test", clienteObtenido.Estado);
            Assert.Equal("12345", clienteObtenido.CodigoPostal);
            Assert.Equal("Testland", clienteObtenido.Pais);
        }
    }
}
