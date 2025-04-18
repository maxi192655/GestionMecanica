using GestionMecanica.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GestionMecanica.Tests.Usuarios
{
    public class AdministradorTests
    {
        [Fact]
        public void Constructor_Con_Valores()
        {
            string nombre = "Juan";
            string email = "juan@mail.com";
            string pwd = "1234";
            string area = "Ventas";

            var admin = new Administrador(nombre, email, pwd, area);

            Assert.Equal(nombre, admin.Nombre);
            Assert.Equal(email, admin.Email);
            Assert.Equal(pwd, admin.Pwd);
        }
    }
}
