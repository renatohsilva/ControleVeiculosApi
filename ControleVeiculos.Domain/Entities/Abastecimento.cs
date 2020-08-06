
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleVeiculos.Domain.Entities
{
    public class Abastecimento : IEntity
    {
        [Key]
        public int Id { get; set; }

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
    }
}
