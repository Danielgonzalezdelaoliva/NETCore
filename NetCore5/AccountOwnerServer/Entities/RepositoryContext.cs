using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ClientCycle> ClientCycle { get; set; }

        public RepositoryContext(DbContextOptions options)
           : base(options)
        {
        }

        //API Fluent
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Keys
            modelBuilder.Entity<Client>()
              .HasKey(c => c.IdClientBase);

            modelBuilder.Entity<ProductType>()
             .HasKey(p => p.IdProductType);

            modelBuilder.Entity<ClientCycle>()
             .HasKey(cc=> new { cc.IdClientBase, cc.Date , cc.IdCycle });

            //Relations
            modelBuilder.Entity<ClientCycle>()
                .HasOne(c => c.Client)
                .WithMany(cc => cc.ClientCycles)
                .HasForeignKey(cc => cc.IdClientBase);

            modelBuilder.Entity<ClientCycle>()
                .HasOne(p => p.ProductType)
                .WithMany(cc => cc.ClientCycles)
                .HasForeignKey(cc => cc.IdProductType);


        }
    }
}
