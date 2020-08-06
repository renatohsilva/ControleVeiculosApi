using ControleVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleVeiculos.Infra.Data.Context
{
    public class VeiculosDataContext : DbContext
    {
        public VeiculosDataContext(DbContextOptions<VeiculosDataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Abastecimento> Abastecimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            base.OnModelCreating(builder);
        }
    }
}
