using System;

namespace ControleVeiculos.Domain.DTOs
{
    public class AbastecimentoDto
    {
        public decimal KmAbastecimento { get; set; }

        public decimal LitrosAbastecidos { get; set; }

        public decimal ValorPago { get; set; }

        public DateTime DataAbastecimento { get; set; }

        public string PostoAbastecido { get; set; }

        public string Combustivel { get; set; }

        public int VeiculoId { get; set; }
    }
}
