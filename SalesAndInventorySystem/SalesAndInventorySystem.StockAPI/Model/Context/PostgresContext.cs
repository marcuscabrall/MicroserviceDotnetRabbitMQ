using Microsoft.EntityFrameworkCore;
using SalesAndInventorySystem.InventoryAPI.Model;
using SalesAndInventorySystem.InventoryAPI.Model.Enums;

namespace SalesAndInventorySystem.InventoryAPI.Model.Context
{
    public class PostgresContext : DbContext
    {
        public PostgresContext() { }

        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Só traz produtos disponíveis
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => p.Status == StatusType.Available);

            // Melhora a busca por status
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Status);
        }
    }
}
