using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Common.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace ControleVeiculos.Service.Common.Services
{
    public class VeiculoService : GenericService<Veiculo>, IVeiculoService
    {
        private readonly IValidator<Veiculo> validatorVeiculo;
        public VeiculoService(IVeiculoRepository veiculoRepository, IValidator<Veiculo> validatorVeiculo) : base(veiculoRepository)
        {
            this.validatorVeiculo = validatorVeiculo;
        }

        public async Task<Veiculo> LoadVeiculoByPlaca(string placa)
        {
            IVeiculoRepository veiculoRepository = (IVeiculoRepository)GetRepository();
            Veiculo veiculo = await veiculoRepository.LoadVeiculoByPlaca(placa);
            return veiculo;
        }

        public override void Consistency(Veiculo entity)
        {
            validatorVeiculo.ValidateAndThrow(entity);
        }
    }
}
