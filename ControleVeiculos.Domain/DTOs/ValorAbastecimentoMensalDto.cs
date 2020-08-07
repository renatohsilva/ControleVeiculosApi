using System;

namespace ControleVeiculos.Domain.DTOs
{
    public class ValorAbastecimentoMensalDto
    {
        public decimal ValorAbastecido { get; set; }

        public int Ano { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as ValorAbastecimentoMensalDto);
        }

        public bool Equals(ValorAbastecimentoMensalDto obj)
        {
            if (obj == null)
                return false;

            return Equals(obj.ValorAbastecido, ValorAbastecido)
                && Equals(obj.Ano, Ano);
        }

        public override int GetHashCode()
        {
            // It does not metter int overflow
            unchecked
            {
                return Tuple.Create(ValorAbastecido, Ano).GetHashCode();
            }
        }
    }
}
