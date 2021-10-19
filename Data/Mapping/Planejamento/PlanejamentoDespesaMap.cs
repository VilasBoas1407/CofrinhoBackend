using Domain.Entities.Planejamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Planejamento
{
    public class PlanejamentoDespesaMap : IEntityTypeConfiguration<PlanejamentoDespesaEntity>
    {
        public void Configure(EntityTypeBuilder<PlanejamentoDespesaEntity> builder)
        {
            builder.ToTable("PlanejamentoDespesa");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.IdUsuario)
           .IsRequired();

            builder.Property(u => u.IdPlanejamento)
           .IsRequired();
        }
    }
}
