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
    }
}
