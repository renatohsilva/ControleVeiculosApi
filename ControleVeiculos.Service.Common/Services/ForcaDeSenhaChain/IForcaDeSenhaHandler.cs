using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Service.Common.Services.ForcaDeSenhaChain
{
    public interface IForcaDeSenhaHandler
    {
        IForcaDeSenhaHandler SetNext(IForcaDeSenhaHandler handler);

        ForcaDaSenha Handle(int placar);
    }
}
