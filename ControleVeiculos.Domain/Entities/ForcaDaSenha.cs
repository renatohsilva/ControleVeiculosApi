using System.Runtime.Serialization;

namespace ControleVeiculos.Domain.Entities
{
    public enum ForcaDaSenha
    {
        [EnumMember(Value = "Inaceitável")]
        Inaceitavel,
        [EnumMember(Value = "Fraca")]
        Fraca,
        [EnumMember(Value = "Aceitável")]
        Aceitavel,
        [EnumMember(Value = "Forte")]
        Forte,
        [EnumMember(Value = "Segura")]
        Segura
    }
}
