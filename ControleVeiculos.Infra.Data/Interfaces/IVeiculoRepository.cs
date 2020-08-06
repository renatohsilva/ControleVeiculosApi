using ControleVeiculos.Domain.Entities;
using System.Threading.Tasks;

namespace ControleVeiculos.Infra.Data.Interfaces
{
    public interface IVeiculoRepository : IGenericRepository<Veiculo>
    {
        Task<Veiculo> LoadVeiculoByPlaca(string placa);
    }
}
