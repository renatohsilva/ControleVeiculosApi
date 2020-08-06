using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Common.Interfaces;
using FluentValidation;

namespace ControleVeiculos.Service.Common.Services
{
    public class AbastecimentoService : GenericService<Abastecimento>, IAbastecimentoService
    {
        private readonly IValidator<Abastecimento> validatorAbastecimento;
        public AbastecimentoService(IAbastecimentoRepository abastecimentoRepository, IValidator<Abastecimento> validatorAbastecimento) : base(abastecimentoRepository)
        {
            this.validatorAbastecimento = validatorAbastecimento;
        }

        public override void Consistency(Abastecimento entity)
        {
            validatorAbastecimento.ValidateAndThrow(entity);
        }
    }
}
