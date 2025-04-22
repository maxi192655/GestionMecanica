using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Xunit;
namespace GestionMecanica.Tests.Data
{
    public class ConexionTests
    {
        [Fact]
        public void ConexionAbiertaCierra()
        {
            // Arrange
            var connection = GestionMecanica.Data.Conexion.GetOpenConnection();

            //Act & Assert
            Assert.Equal(System.Data.ConnectionState.Open, connection.State);

            //limpieza\
            connection.Close();
            Assert.Equal(System.Data.ConnectionState.Closed, connection.State);
        }
    }
}
