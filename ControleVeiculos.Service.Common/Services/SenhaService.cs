using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Service.Common.Interfaces;
using ControleVeiculos.Service.Common.Services.ForcaDeSenhaChain;
using System;
using System.Text.RegularExpressions;

namespace ControleVeiculos.Service.Common.Services
{
    public class SenhaService : ISenhaService
    {
        public ForcaDaSenha GetForcaDaSenha(string senha)
        {
            ForcaDeSenhaConfiguration forcaDeSenhaConfiguration = new ForcaDeSenhaConfiguration();
            ForcaDaSenha forcaDeSenha = forcaDeSenhaConfiguration.Handle(GeraPontosSenha(senha));
            return forcaDeSenha;
        }

        private int GeraPontosSenha(string senha)
        {
            int pontosDaSenha = 0;

            if (senha == null)
                return pontosDaSenha;

            pontosDaSenha += GetPontoPorTamanho(senha);
            pontosDaSenha += GetPontoPorMaiusculaEMinusculas(senha);
            pontosDaSenha += GetPontoPorDigitos(senha);
            pontosDaSenha += GetPontoPorSimbolos(senha);

            return pontosDaSenha;
        }

        private int GetPontoPorTamanho(string senha)
        {
            return Math.Min(10, senha.Length) * 6;
        }

        private int GetPontoPorMaiusculaEMinusculas(string senha)
        {
            int placarMinuscula = GetPontoPorMinusculas(senha);
            int placarMaiusculas = GetPontoPorMaiusculas(senha);
            if (placarMinuscula > 0 && placarMaiusculas > 0)
            {
                int rawplacar = placarMinuscula + placarMaiusculas;
                return rawplacar * 5;
            }
            return 0;
        }

        private int GetPontoPorMinusculas(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[a-z]", "").Length;
            return Math.Min(3, rawplacar);
        }

        private int GetPontoPorMaiusculas(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[A-Z]", "").Length;
            return Math.Min(3, rawplacar);
        }

        private int GetPontoPorDigitos(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[0-9]", "").Length;
            return Math.Min(3, rawplacar) * 5;
        }

        private int GetPontoPorSimbolos(string senha)
        {
            int rawplacar = Regex.Replace(senha, "[a-zA-Z0-9]", "").Length;
            return Math.Min(3, rawplacar) * 5;
        }
    }
}
