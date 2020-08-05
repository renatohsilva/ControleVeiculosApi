using ControleVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleVeiculos.Infra.Data.Context
{
    public class VeiculosDataContext : DbContext
    {
        public VeiculosDataContext(DbContextOptions<VeiculosDataContext> options) : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {            
            base.OnModelCreating(builder);
        }
    }
}
