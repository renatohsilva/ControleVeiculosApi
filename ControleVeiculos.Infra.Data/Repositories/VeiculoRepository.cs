using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Context;
using ControleVeiculos.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ControleVeiculos.Infra.Data.Repositories
{
    public class VeiculoRepository : GenericRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(VeiculosDataContext dataContext) : base(dataContext)
        {

        }

        public async Task<Veiculo> LoadVeiculoByPlaca(string placa)
        {
            return await GetDataContext().Set<Veiculo>()
                       .AsNoTracking()
                       .FirstOrDefaultAsync(e => e.Placa == placa);
        }
    }
}
