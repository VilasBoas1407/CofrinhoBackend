using Domain.Entities.Planejamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class TipoDespesaMap : IEntityTypeConfiguration<TipoDespesaEntity>
    {
        public void Configure(EntityTypeBuilder<TipoDespesaEntity> builder)
        {
            builder.ToTable("TipoDespesa");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.IdUsuario).IsRequired();

            builder.Property(u => u.Nome).IsRequired();

            builder.Property(u => u.IsDespesa).IsRequired();
        }
    }
}
