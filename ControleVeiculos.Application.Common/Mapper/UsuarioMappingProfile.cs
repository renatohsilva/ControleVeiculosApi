using AutoMapper;
using ControleVeiculos.Application.Common.Helper;
using ControleVeiculos.Domain.DTOs;
using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Domain.Secutiry;

namespace ControleVeiculos.Application.Common.Mapper
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.Role.ToEnumString()));

            CreateMap<UsuarioDto, Usuario>()
                      .ForMember(dest => dest.Senha, opts => opts.MapFrom(src => src.Senha.Encrypt()))
                      .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.Role.ToEnum<TipoUsuario>()));
        }
    }
}
