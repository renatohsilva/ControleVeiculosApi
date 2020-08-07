
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleVeiculos.Domain.Entities
{
    public class Abastecimento : BaseEntity
    {
        [Required]
        public decimal KmAbastecimento { get; set; }

        [Required]
        public decimal LitrosAbastecidos { get; set; }

        [Required]
        public decimal ValorPago { get; set; }

        [Required]
        public DateTime DataAbastecimento { get; set; }

        [Required]
        public string PostoAbastecido { get; set; }

        [Required]
        [JsonProperty("Combustivel")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TipoCombustivel Combustivel { get; set; }

        public int VeiculoId { get; set; }

        public Veiculo Veiculo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as Abastecimento);
        }

        public bool Equals(Abastecimento obj)
        {
            if (obj == null)
                return false;

            return Equals(obj.KmAbastecimento, KmAbastecimento)
                && Equals(obj.LitrosAbastecidos, LitrosAbastecidos)
                && Equals(obj.ValorPago, ValorPago)
                && Equals(obj.DataAbastecimento, DataAbastecimento)
                && Equals(obj.PostoAbastecido, PostoAbastecido)
                && Equals(obj.Combustivel, Combustivel)
                && Equals(obj.VeiculoId, VeiculoId)
                && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            // It does not metter int overflow
            unchecked
            {
                return (base.GetHashCode() << 2) ^ Tuple.Create(KmAbastecimento, LitrosAbastecidos, ValorPago, DataAbastecimento, PostoAbastecido, Combustivel, VeiculoId).GetHashCode();
            }
        }
    }
}
