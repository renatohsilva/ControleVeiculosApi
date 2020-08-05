using System.Runtime.Serialization;

namespace ControleVeiculos.Domain.Entities
{
    public enum TipoCombustivel
    {
        [EnumMember(Value = "GASOLINA")]
        Gasolina,
        [EnumMember(Value = "ÁLCOOL")]
        Alcool,
        [EnumMember(Value = "DIESEL")]
        Diesel
    }
}
