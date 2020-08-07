using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleVeiculos.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        [JsonProperty("Tipo")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TipoVeiculo Tipo { get; set; }

        [Required]
        [JsonProperty("Combustivel")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TipoCombustivel Combustivel { get; set; }

        [Required]
        public decimal Quilometragem { get; set; }

        [Column(TypeName = "bytea")]
        public byte[] Foto { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as Veiculo);
        }

        public bool Equals(Veiculo obj)
        {
            if (obj == null)
                return false;

            return Equals(obj.Marca, Marca)
                && Equals(obj.Modelo, Modelo)
                && Equals(obj.Ano, Ano)
                && Equals(obj.Placa, Placa)
                && Equals(obj.Tipo, Tipo)
                && Equals(obj.Combustivel, Combustivel)
                && Equals(obj.Quilometragem, Quilometragem)
                && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            // It does not metter int overflow
            unchecked
            {
                return (base.GetHashCode() << 2) ^ Tuple.Create(Marca, Modelo, Ano, Placa, Tipo, Combustivel, Quilometragem).GetHashCode();
            }
        }
    }
}
