using ControleVeiculos.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVeiculos.Service.Common.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll(int idUsuario);
        Task<TEntity> GetById(int id, int idUsuario);
        Task Create(TEntity entity, int idUsuario);
        Task Update(int id, TEntity entity, int idUsuario);
        Task Delete(int id);
    }
}
