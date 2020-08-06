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

        public async Task<Usuario> Autenticar(string email, string senha)
        {
            return await usuarioRepository.Autenticar(email, senha);
        }

        public async Task<Usuario> LoadByEmail(string email)
        {
            return await usuarioRepository.LoadByEmail(email);
        }

        public override void Consistency(Usuario entity)
        {
            validatorUsuario.ValidateAndThrow(entity);
        }
    }
}
