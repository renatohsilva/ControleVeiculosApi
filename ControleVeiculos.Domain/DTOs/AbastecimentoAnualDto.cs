using System;
using System.Globalization;

namespace ControleVeiculos.Domain.DTOs
{
    public class AbastecimentoMensalDto
    {
        public decimal Quilometragem { get; set; }

        public int Mes { get; set; }

        public string NomeMes
        {
            get
            {
               return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Mes);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as AbastecimentoMensalDto);
        }

        public bool Equals(AbastecimentoMensalDto obj)
        {
            if (obj == null)
                return false;

            return Equals(obj.Quilometragem, Quilometragem)
                && Equals(obj.Mes, Mes)
                && Equals(obj.NomeMes, NomeMes);
        }

        public override int GetHashCode()
        {
            // It does not metter int overflow
            unchecked
            {
                return Tuple.Create(Quilometragem, Mes, NomeMes).GetHashCode();
            }
        }
    }
}
