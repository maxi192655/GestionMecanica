using GestionMecanica.Core.Entidades;
using GestionMecanica.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.App
{
    public class SistemaUsuario
    {
        private readonly RepositorioUsuarios _repositorioUsuarios;

        public SistemaUsuario(RepositorioUsuarios repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public void AltaCliente(Cliente cliente)
        {
            if(_repositorioUsuarios.CheckEmailExists(cliente.Email))
            {
                throw new Exception("El email ya está registrado.");
            }

            _repositorioUsuarios.InsertarCliente(cliente);
        }

        public void AltaMecanico(Mecanico mecanico)
        {
            if (_repositorioUsuarios.CheckEmailExists(mecanico.Email))
            {
                throw new Exception("El email ya está registrado.");
            }
            _repositorioUsuarios.InsertarMecanico(mecanico);
        }

        public void AltaAdministrador(Administrador administrador)
        {
            if (_repositorioUsuarios.CheckEmailExists(administrador.Email))
            {
                throw new Exception("El email ya está registrado.");
            }
            _repositorioUsuarios.InsertarAdministrador(administrador);
        }


        public Usuario ObtenerUsuarioPorEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacio", nameof(email));
            var usuario = _repositorioUsuarios.GetClientePorMail(email);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");
            return usuario;
        }
    }
}
