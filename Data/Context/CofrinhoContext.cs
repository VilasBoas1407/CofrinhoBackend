using Data.Mapping;
using Domain.Entities;
using Domain.Entities.History;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class CofrinhoContext : DbContext
    {
        public CofrinhoContext(DbContextOptions<CofrinhoContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(localdb) \\mssqllocaldb;Database=DBTarefas;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<LoginHistoryEntity>(new LoginHistoryMap().Configure);

        }
    }
}
