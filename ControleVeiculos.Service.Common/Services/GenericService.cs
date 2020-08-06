using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ControleVeiculos.Service.Common.Services
{
    public abstract class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseEntity
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IQueryable<TEntity> GetAll(int idUsuario)
        {
            return GetRepository().GetAll().Where(item => item.UsuarioId == idUsuario);
        }

        public async Task Create(TEntity entity, int idUsuario)
        {
            entity.UsuarioId = idUsuario;
            Consistency(entity);
            await GetRepository().Create(entity);
        }

        public async Task<TEntity> GetById(int id, int idUsuario)
        {
            return await GetAll(idUsuario).FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task Update(int id, TEntity entity, int idUsuario)
        {
            entity.UsuarioId = idUsuario;
            Consistency(entity);
            await GetRepository().Update(id, entity);
        }

        public async Task Delete(int id)
        {
            await GetRepository().Delete(id);
        }

        public IGenericRepository<TEntity> GetRepository()
        {
            return _genericRepository;
        }

        public abstract void Consistency(TEntity entity);
    }
}
