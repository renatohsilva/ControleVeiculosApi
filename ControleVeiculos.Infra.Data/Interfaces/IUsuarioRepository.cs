
using ControleVeiculos.Domain.Entities;
using System.Threading.Tasks;

namespace ControleVeiculos.Infra.Data.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> Autenticar(string email, string senha);

        Task<Usuario> LoadByEmail(string email);
    }
}
