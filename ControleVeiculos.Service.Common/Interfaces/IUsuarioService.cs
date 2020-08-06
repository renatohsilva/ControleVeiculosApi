using ControleVeiculos.Domain.Entities;
using System.Threading.Tasks;

namespace ControleVeiculos.Service.Common.Interfaces
{
    public interface IUsuarioService : IGenericService<Usuario>
    {
        Task<Usuario> Authenticate(string email, string senha);
    }
}
