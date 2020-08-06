using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Service.Common.Services.ForcaDeSenhaChain
{
    public class SenhaInaceitavelHandler : ForcaDeSenhaAbstractHandler
    {
        public override ForcaDaSenha Handle(int placar)
        {
            if (placar < 50)
                return ForcaDaSenha.Inaceitavel;

            return base.Handle(placar);
        }
    }
}
