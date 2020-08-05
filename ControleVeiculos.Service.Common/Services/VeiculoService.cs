using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Common.Interfaces;
using FluentValidation;

namespace ControleVeiculos.Service.Common.Services
{
    public class VeiculoService : GenericService<Veiculo>, IVeiculoService
    {
        private readonly IValidator<Veiculo> validatorVeiculo;
        public VeiculoService(IVeiculoRepository veiculoRepository, IValidator<Veiculo> validatorVeiculo) : base(veiculoRepository)
        {
            this.validatorVeiculo = validatorVeiculo;
        }

        public override void Consistency(Veiculo entity)
        {
            validatorVeiculo.ValidateAndThrow(entity);
        }
    }
}
