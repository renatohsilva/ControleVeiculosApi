using ControleVeiculos.Domain.Entities;

namespace ControleVeiculos.Service.Common.Services.ForcaDeSenhaChain
{
    public abstract class ForcaDeSenhaAbstractHandler : IForcaDeSenhaHandler
    {
        private IForcaDeSenhaHandler _nextHandler;

        public IForcaDeSenhaHandler SetNext(IForcaDeSenhaHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual ForcaDaSenha Handle(int placar)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(placar);
            }
            return ForcaDaSenha.Forte;
        }
    }
}
