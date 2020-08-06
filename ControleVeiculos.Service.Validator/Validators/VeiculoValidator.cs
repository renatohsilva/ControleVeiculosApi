using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Validator.Interfaces;
using FluentValidation;
using System;

namespace ControleVeiculos.Service.Validator.Validators
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
	{
        private readonly IVeiculoRepository veiculoRepository;
        private readonly IPlacaValida placaValida;

        public VeiculoValidator(IVeiculoRepository veiculoRepository, IPlacaValida placaValida)
        {
            this.veiculoRepository = veiculoRepository;
            this.placaValida = placaValida;
        }

		public VeiculoValidator()
		{
			RuleFor(x => x.Placa).NotEmpty().WithMessage("Campo Placa é obrigatório!");
			RuleFor(x => x.Placa).Must(placaValida.IsPlaca).WithMessage("Placa inválida");
			RuleFor(x => x.Marca).NotEmpty().WithMessage("Campo Marca é obrigatório!");
			RuleFor(x => x.Modelo).NotEmpty().WithMessage("Campo Modelo é obrigatório!");
			RuleFor(x => x.Ano).GreaterThan(0).WithMessage("Campo Ano é obrigatório!");
			RuleFor(x => x.Quilometragem).GreaterThanOrEqualTo(0).WithMessage("Campo Quilometragem é obrigatório!");
			RuleFor(x => x).Must(placaValida.IsPlacaInexistente).WithMessage("Veiculo já cadastrado");
		}

       

	}
}
