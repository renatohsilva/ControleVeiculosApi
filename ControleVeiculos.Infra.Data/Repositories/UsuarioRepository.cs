using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Context;
using ControleVeiculos.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ControleVeiculos.Infra.Data.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(VeiculosDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<Usuario> Autenticar(string email, string senha)
        {
            return await GetDataContext().Set<Usuario>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Email == email && e.Senha == senha);
        }

        public async Task<Usuario> LoadByEmail(string email)
        {
            return await GetDataContext().Set<Usuario>()
                 .AsNoTracking()
                 .FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
