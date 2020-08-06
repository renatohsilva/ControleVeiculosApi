using System;
using System.Globalization;

namespace ControleVeiculos.Domain.DTOs
{
    public class AbastecimentoPorCarroDto
    {
        public decimal MediaQuilometragem {get; set; }

        public string Placa { get; set; }

        public int Ano { get; set; }
    }
}
