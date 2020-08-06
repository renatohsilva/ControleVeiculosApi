using AutoMapper;
using ControleVeiculos.Application.Common.Helper;
using ControleVeiculos.Domain.DTOs;
using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Application.Common.Mapper
{
    public class AbastecimentoMappingProfile : Profile
    {
        public AbastecimentoMappingProfile()
        {
            CreateMap<Abastecimento, AbastecimentoDto>()
                    .ForMember(dest => dest.Combustivel, opts => opts.MapFrom(src => src.Combustivel.ToEnumString()));

            CreateMap<AbastecimentoDto, Abastecimento>()
                .ForMember(dest => dest.Combustivel, opts => opts.MapFrom(src => src.Combustivel.ToEnum<TipoCombustivel>()));
        }
    }
}
