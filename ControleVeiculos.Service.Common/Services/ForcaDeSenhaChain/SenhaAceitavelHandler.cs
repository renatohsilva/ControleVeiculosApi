using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Service.Common.Services.ForcaDeSenhaChain
{
    public class SenhaAceitavelHandler : ForcaDeSenhaAbstractHandler
    {
        public override ForcaDaSenha Handle(int placar)
        {
            if (placar >= 70 && placar < 90)
                return ForcaDaSenha.Aceitavel;

            return base.Handle(placar);
        }
    }
}
