using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleVeiculos.Domain.Entities
{
    public class Veiculo : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public int Ano { get; set; }

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
    }
}
