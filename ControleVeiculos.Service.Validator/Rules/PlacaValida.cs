using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Validator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ControleVeiculos.Service.Validator.Rules
{
    public class PlacaValida : IPlacaValida
    {
        private readonly IVeiculoRepository veiculoRepository;

        public PlacaValida(IVeiculoRepository veiculoRepository)
        {
            this.veiculoRepository = veiculoRepository;
        }

        public bool IsPlaca(string placa)
        {
            string placaRegex = "[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}|[A-Z]{3}\\-[0-9]{4}";
            return Regex.IsMatch(placa, placaRegex);
        }

        public bool IsPlacaInexistente(Veiculo veiculo)
        {
            var veiculoByPlaca = veiculoRepository.LoadVeiculoByPlaca(veiculo.Placa).Result;

            if (veiculoByPlaca == null)
                return true;

            if (veiculo.Id == veiculoByPlaca.Id)
                return true;

            return false;
        }
    }
}
