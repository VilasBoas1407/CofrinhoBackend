using Domain.Entities.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class DespesasMap : IEntityTypeConfiguration<DespesasEntity>
    {
        public void Configure(EntityTypeBuilder<DespesasEntity> builder)
        {
            builder.ToTable("Despesas");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.IdPlanejamento)
           .IsRequired();

            builder.Property(u => u.IdTipoDespesa)
           .IsRequired();

            builder.Property(u => u.IdUsuario)
            .IsRequired();

        }


    }
}
