using ControleVeiculos.Domain.Entities;
using FluentValidation;

namespace ControleVeiculos.Service.Validator.Validators
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
	{
		public VeiculoValidator()
		{
			RuleFor(x => x.Marca).NotEmpty().WithMessage("Campo marca é obrigatório!");
			RuleFor(x => x.Modelo).NotEmpty().WithMessage("Campo modelo é obrigatório!");
			RuleFor(x => x.Ano).GreaterThan(0).WithMessage("Campo ano é obrigatório!");
			RuleFor(x => x.Quilometragem).GreaterThanOrEqualTo(0).WithMessage("Campo quilometragem é obrigatório!");
		}
	}
}
