using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Service.Common.Interfaces
{
    public interface ISenhaService
    {
        ForcaDaSenha GetForcaDaSenha(string senha);
    }
}
