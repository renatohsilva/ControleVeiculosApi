using System;
using System.Collections.Generic;
using System.Text;
using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Common.Interfaces;
using ControleVeiculos.Service.Validator.Interfaces;
using FluentValidation;

namespace ControleVeiculos.Service.Validator.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
	{
		private readonly IEmailValido emailValido;
		private readonly ISenhaService senhaService;

		public UsuarioValidator(IEmailValido emailValido, ISenhaService senhaService)
		{
			this.emailValido = emailValido;
			this.senhaService = senhaService;

			RuleFor(x => x.Email).Must(emailValido.IsEmail).WithMessage("Campo Email inválido!");
			RuleFor(x => x.Senha).NotEmpty().WithMessage("Campo Senha é obrigatório!");
			RuleFor(x => x.NomeCompleto).NotEmpty().WithMessage("Campo Nome Completo é obrigatório!");
			RuleFor(x => x).Must(emailValido.IsEmailInexistente).WithMessage("Usuário já cadastrado");
			RuleFor(x => x).Must(ChecaForcaSenha).WithMessage("A senha deve conter ao menos 6 caracteres, letras maiusculas e minusculas, simbolos e números");
		}

		private bool ChecaForcaSenha(Usuario usuario)
		{
			var forcaDeSenha = senhaService.GetForcaDaSenha(usuario.Senha);
			return forcaDeSenha >= ForcaDaSenha.Segura;
		}
	}
}
