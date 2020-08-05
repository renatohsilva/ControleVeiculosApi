using System.Runtime.Serialization;

namespace ControleVeiculos.Domain.Entities
{
    public enum TipoVeiculo
    {
        [EnumMember(Value = "CARRO")]
        Carro,
        [EnumMember(Value = "MOTO")]
        Moto,
        [EnumMember(Value = "CAMINHÃO")]
        Caminhão
    }
}
