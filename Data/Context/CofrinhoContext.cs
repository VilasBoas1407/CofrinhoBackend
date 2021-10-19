using Data.Mapping;
using Data.Mapping.Planejamento;
using Domain.Entities;
using Domain.Entities.Expenses;
using Domain.Entities.History;
using Domain.Entities.Planejamento;
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
            modelBuilder.Entity<DespesasEntity>(new DespesasMap().Configure);
            modelBuilder.Entity<PlanejamentoEntity>(new PlanejamentoMap().Configure);
            modelBuilder.Entity<TipoDespesaEntity>(new TipoDespesaMap().Configure);
            modelBuilder.Entity<PlanejamentoDespesaEntity>(new PlanejamentoDespesaMap().Configure);

            #region Definindo relacionamentos


            modelBuilder.Entity<DespesasEntity>()
                .HasOne(p => p.User)
                .WithMany(u => u.Despesas)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DespesasEntity>().HasOne(p => p.TipoDespesa)
                .WithMany(u => u.Despesas)
                .HasForeignKey(p => p.IdTipoDespesa)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanejamentoEntity>()
                .HasOne(p => p.User)
                .WithMany(b => b.Planejamentos)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TipoDespesaEntity>()
                .HasOne(p => p.User)
                .WithMany(u => u.TipoDespesas)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanejamentoDespesaEntity>().HasOne(p => p.Despesas)
                .WithMany(u => u.PlanejamentosDespesasList)
                .HasForeignKey(p => p.IdDespesa)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanejamentoDespesaEntity>().HasOne(p => p.Planejamento)
                .WithMany(u => u.PlanejamentoDespesas)
                .HasForeignKey(p => p.IdPlanejamento)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanejamentoDespesaEntity>()
                .HasOne(p => p.User)
                .WithMany(u => u.PlanejamentoDespesas)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);


            #endregion

        }
    }
}
