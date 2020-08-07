using ControleVeiculos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVeiculos.Service.Validator.Interfaces
{
    public interface IEmailValido
    {
        bool IsEmail(string email);

        bool IsEmailInexistente(Usuario email);
    }
}
