using ControleVeiculos.Domain.Entities;
using System.Threading.Tasks;

namespace ControleVeiculos.Service.Common.Interfaces
{
    public interface IUsuarioService 
    {
        Task<Usuario> Autenticar(string email, string senha);

        Task Registrar(Usuario usuario);

        Task<Usuario> LoadByEmail(string email);
    }
}
