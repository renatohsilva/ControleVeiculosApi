using System.Runtime.Serialization;

namespace ControleVeiculos.Domain.Entities
{
    public enum TipoUsuario
    {
        [EnumMember(Value = "USUÁRIO")]
        Usuario,
        [EnumMember(Value = "ADMIN")]
        Admin
    }
}
