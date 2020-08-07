using System;

namespace ControleVeiculos.Domain.DTOs
{
    public class LitrosAbastecimentoMensalDto
    {
        public decimal LitrosAbastecidos { get; set; }

        public int Ano { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as LitrosAbastecimentoMensalDto);
        }

        public bool Equals(LitrosAbastecimentoMensalDto obj)
        {
            if (obj == null)
                return false;

            return Equals(obj.LitrosAbastecidos, LitrosAbastecidos)
                && Equals(obj.Ano, Ano);
        }

        public override int GetHashCode()
        {
            // It does not metter int overflow
            unchecked
            {
                return Tuple.Create(LitrosAbastecidos, Ano).GetHashCode();
            }
        }
    }
}
