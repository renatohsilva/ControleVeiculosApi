using AutoMapper;
using ControleVeiculos.Domain.DTOs;
using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Application.Common.Mapper
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();

            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
