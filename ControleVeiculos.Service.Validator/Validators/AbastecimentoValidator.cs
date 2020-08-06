using ControleVeiculos.Domain.Entities;
using FluentValidation;

namespace ControleVeiculos.Service.Validator.Validators
{
    public class AbastecimentoValidator : AbstractValidator<Abastecimento>
	{
		public AbastecimentoValidator()
		{
			RuleFor(x => x.KmAbastecimento).GreaterThan(0).WithMessage("Campo Km de Abastecimento é obrigatório!");
			RuleFor(x => x.LitrosAbastecidos).GreaterThan(0).WithMessage("Campo Litros Abastecidos é obrigatório!");
			RuleFor(x => x.ValorPago).GreaterThan(0).WithMessage("Campo Valor Pago é obrigatório!");
			RuleFor(x => x.DataAbastecimento).NotEmpty().WithMessage("Campo Data Abastecimento é obrigatório!");
			RuleFor(x => x.PostoAbastecido).NotEmpty().WithMessage("Campo Posto Abastecido é obrigatório!");
			RuleFor(x => x.VeiculoId).GreaterThan(0).WithMessage("Campo Identificador do Veiculo é obrigatório!");
			RuleFor(x => x.UsuarioId).GreaterThan(0).WithMessage("Campo Identificador do Usuário é obrigatório!");
		}
	}
}
