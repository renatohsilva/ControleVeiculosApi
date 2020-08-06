using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Service.Common.Services.ForcaDeSenhaChain
{
    public class ForcaDeSenhaConfiguration
    {
        private readonly SenhaInaceitavelHandler senhaInaceitavel;
        private readonly SenhaFracaHandler senhaFraca;
        private readonly SenhaAceitavelHandler senhaAceitavel;
        private readonly SenhaSeguraHandler senhaSegura;

        public ForcaDeSenhaConfiguration()
        {
            senhaInaceitavel = new SenhaInaceitavelHandler();
            senhaFraca = new SenhaFracaHandler();
            senhaAceitavel = new SenhaAceitavelHandler();
            senhaSegura = new SenhaSeguraHandler();

            senhaInaceitavel.SetNext(senhaFraca).SetNext(senhaAceitavel).SetNext(senhaSegura);
        }


        public ForcaDaSenha Handle(int placar)
        {
            return senhaInaceitavel.Handle(placar);
        }
    }
}
