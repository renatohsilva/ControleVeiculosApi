using AutoMapper;
using ControleVeiculos.Application.Common.Helper;
using ControleVeiculos.Domain.DTOs;
using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Application.Common.Mapper
{
    public class VeiculoMappingProfile : Profile
    {
        public VeiculoMappingProfile()
        {
            CreateMap<Veiculo, VeiculoDto>()
                    .ForMember(dest => dest.Tipo, opts => opts.MapFrom(src => src.Tipo.ToEnumString()))
                    .ForMember(dest => dest.Combustivel, opts => opts.MapFrom(src => src.Combustivel.ToEnumString()));

            CreateMap<VeiculoDto, Veiculo>()
                .ForMember(dest => dest.Tipo, opts => opts.MapFrom(src => src.Tipo.ToEnum<TipoVeiculo>()))
                .ForMember(dest => dest.Combustivel, opts => opts.MapFrom(src => src.Combustivel.ToEnum<TipoCombustivel>()));
        }
    }
}
