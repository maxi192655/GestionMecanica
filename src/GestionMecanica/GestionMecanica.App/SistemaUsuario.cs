using AutoMapper;
using GestionMecanica.Core.DTOs;
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
        private readonly RepositorioUsuarios _repositorio;
        private readonly IMapper _mapper;

        public SistemaUsuario(RepositorioUsuarios repositorioUsuarios, IMapper mapper)
        {
            _repositorio= repositorioUsuarios;
            _mapper = mapper;
        }


        public ClienteDTO ObtenerPerfilCliente(string email)
        {
            var cliente = _repositorio.GetClientePorMail(email);
            if(cliente == null)
                throw new Exception("Cliente no encontrado");

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public void AltaCliente(Cliente cliente)
        {
            if(_repositorio.CheckEmailExists(cliente.Email))
            {
                throw new Exception("El email ya está registrado.");
            }

            _repositorio.InsertarCliente(cliente);
        }

        public void AltaMecanico(Mecanico mecanico)
        {
            if (_repositorio.CheckEmailExists(mecanico.Email))
            {
                throw new Exception("El email ya está registrado.");
            }
            _repositorio.InsertarMecanico(mecanico);
        }

        public void AltaAdministrador(Administrador administrador)
        {
            if (_repositorio.CheckEmailExists(administrador.Email))
            {
                throw new Exception("El email ya está registrado.");
            }
            _repositorio.InsertarAdministrador(administrador);
        }


        public Usuario ObtenerUsuarioPorEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacio", nameof(email));
            var usuario = _repositorio.GetClientePorMail(email);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");
            return usuario;
        }
    }
}
