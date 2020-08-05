using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Context;
using ControleVeiculos.Infra.Data.Interfaces;

namespace ControleVeiculos.Infra.Data.Repositories
{
    public class VeiculoRepository : GenericRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(VeiculosDataContext dataContext) : base(dataContext)
        {
        }
    }
}
