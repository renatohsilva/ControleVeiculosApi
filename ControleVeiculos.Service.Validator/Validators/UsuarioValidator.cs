using System;
using System.Collections.Generic;
using System.Text;
using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Common.Interfaces;
using FluentValidation;

namespace ControleVeiculos.Service.Validator.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
	{
		private readonly IUsuarioRepository usuarioRepository;
		private readonly ISenhaService senhaService;

		public UsuarioValidator(IUsuarioRepository usuarioRepository, ISenhaService senhaService)
		{
			this.usuarioRepository = usuarioRepository;
			this.senhaService = senhaService;

			RuleFor(x => x.Email).NotEmpty().WithMessage("Campo Email é obrigatório!");
			RuleFor(x => x.Senha).NotEmpty().WithMessage("Campo Senha é obrigatório!");
			RuleFor(x => x.NomeCompleto).NotEmpty().WithMessage("Campo Nome Completo é obrigatório!");
			RuleFor(x => x).Must(IsUsuarioNameJaCadastrado).WithMessage("Usuário já cadastrado");
			RuleFor(x => x).Must(ChecaForcaSenha).WithMessage("A senha deve conter ao menos 6 caracteres, letras maiusculas e minusculas e números");
		}

		private bool IsUsuarioNameJaCadastrado(Usuario usuario)
		{
			var usuarioByEmail = usuarioRepository.LoadByEmail(usuario.Email).Result;
			return usuarioByEmail == null || usuarioByEmail.Id != usuario.Id;
		}

		private bool ChecaForcaSenha(Usuario usuario)
		{
			var forcaDeSenha = senhaService.GetForcaDaSenha(usuario.Senha);
			return forcaDeSenha >= ForcaDaSenha.Aceitavel;
		}
	}
}
