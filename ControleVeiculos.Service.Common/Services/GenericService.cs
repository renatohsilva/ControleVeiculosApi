using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Common.Interfaces;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ControleVeiculos.Service.Common.Services
{
    public abstract class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IQueryable<TEntity> GetAll()
        {
            return GetRepository().GetAll();
        }

        public async Task Create(TEntity entity)
        {
            Consistency(entity);
            await GetRepository().Create(entity);
        }

        public Task<TEntity> GetById(int id)
        {
            return GetRepository().GetById(id);
        }

        public async Task Update(int id, TEntity entity)
        {
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


        private void GetClains()
        {
            /*var userIdentity = (ClaimsIdentity)User.Identity;
            var claims = userIdentity.Claims;
            var roleClaimType = userIdentity.RoleClaimType;
            var roles = claims.Where(c => c.Type == ClaimTypes.Role).ToList();*/
        }

        public abstract void Consistency(TEntity entity);
    }
}
