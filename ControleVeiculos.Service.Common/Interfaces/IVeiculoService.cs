using ControleVeiculos.Domain.Entities;
using System.Threading.Tasks;

namespace ControleVeiculos.Service.Common.Interfaces
{
    public interface IVeiculoService : IGenericService<Veiculo>
    {
        Task<Veiculo> LoadVeiculoByPlaca(string placa);
    }
}
