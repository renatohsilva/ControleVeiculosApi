using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Common.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace ControleVeiculos.Service.Common.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IValidator<Usuario> validatorUsuario;

        public UsuarioService(IUsuarioRepository usuarioRepository, IValidator<Usuario> validatorUsuario)
        {
            this.usuarioRepository = usuarioRepository;
            this.validatorUsuario = validatorUsuario;
        }

        public async Task<Usuario> Autenticar(string email, string senha)
        {
            return await usuarioRepository.Autenticar(email, senha);
        }

        public async Task Registrar(Usuario usuario)
        {
            Consistency(usuario);
            await usuarioRepository.Create(usuario);
        }        

        public async Task<Usuario> LoadByEmail(string email)
        {
            return await usuarioRepository.LoadByEmail(email);
        }

        private void Consistency(Usuario entity)
        {
            validatorUsuario.ValidateAndThrow(entity);
        }
    }
}
