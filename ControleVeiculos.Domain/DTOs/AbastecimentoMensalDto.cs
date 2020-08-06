using System;

namespace ControleVeiculos.Domain.DTOs
{
    public class AbastecimentoAnualDto
    {
        public decimal? ValorAbastecido { get; set; }

        public decimal? LitrosAbastecidos { get; set; }

        public int Ano { get; set; }
    }
}
