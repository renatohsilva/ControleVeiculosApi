using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Service.Common.Services.ForcaDeSenhaChain
{
    public class SenhaSeguraHandler : ForcaDeSenhaAbstractHandler
    {
        public override ForcaDaSenha Handle(int placar)
        {
            if (placar >= 90 && placar < 110)
                return ForcaDaSenha.Segura;

            return base.Handle(placar);
        }
    }
}
