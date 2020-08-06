using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Service.Common.Services.ForcaDeSenhaChain
{
    public class SenhaFracaHandler : ForcaDeSenhaAbstractHandler
    {
        public override ForcaDaSenha Handle(int placar)
        {
            if (placar >= 50 && placar < 70)
                return ForcaDaSenha.Fraca;

            return base.Handle(placar);
        }
    }
}
