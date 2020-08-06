using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Service.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
