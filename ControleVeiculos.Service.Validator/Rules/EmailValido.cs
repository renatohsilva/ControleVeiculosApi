using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Validator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ControleVeiculos.Service.Validator.Rules
{
    public class EmailValido : IEmailValido
    {
        private readonly IUsuarioRepository usuarioRepository;

        public EmailValido(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public bool IsEmail(string email)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            return Regex.IsMatch(email, strModelo);
        }

        public bool IsEmailInexistente(Usuario usuario)
        {
            var usuarioByEmail = usuarioRepository.LoadByEmail(usuario.Email).Result;

            if (usuarioByEmail == null)
                return true;

            if (usuario.Id == usuarioByEmail.Id)
                return true;

            return false;
        }
    }
}
