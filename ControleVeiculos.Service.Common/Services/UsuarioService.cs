using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Common.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace ControleVeiculos.Service.Common.Services
{
    public class UsuarioService : GenericService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IValidator<Usuario> validatorUsuario;

        public UsuarioService(IUsuarioRepository usuarioRepository, IValidator<Usuario> validatorUsuario) : base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.validatorUsuario = validatorUsuario;
        }

        public async Task<Usuario> Authenticate(string email, string senha)
        {
            return await usuarioRepository.Authenticate(email, senha);
        }

        public override void Consistency(Usuario entity)
        {
            validatorUsuario.ValidateAndThrow(entity);
        }
    }
}
