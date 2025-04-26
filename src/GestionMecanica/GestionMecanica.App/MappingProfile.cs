using AutoMapper;
using GestionMecanica.Core.DTOs;
using GestionMecanica.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMecanica.App
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>();

            //CreateMap<Administrador, AdministradorDTO>();
            //CreateMap<Mecanico, MecanicoDTO>();
        }
    }
}
