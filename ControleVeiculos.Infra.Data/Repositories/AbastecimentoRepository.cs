using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Context;
using ControleVeiculos.Infra.Data.Interfaces;

namespace ControleVeiculos.Infra.Data.Repositories
{
    public class AbastecimentoRepository : GenericRepository<Abastecimento>, IAbastecimentoRepository
    {
        public AbastecimentoRepository(VeiculosDataContext dataContext) : base(dataContext)
        {
        }
    }
}
