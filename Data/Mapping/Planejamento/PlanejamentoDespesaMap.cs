using Domain.Entities.Planejamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Planejamento
{
    public class PlanejamentoDespesaMap : IEntityTypeConfiguration<PlanejamentoDespesasEntity>
    {
        public void Configure(EntityTypeBuilder<PlanejamentoDespesasEntity> builder)
        {
            builder.ToTable("PlanejamentoDespesas");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.IdUsuario)
           .IsRequired();

            builder.Property(u => u.IdPlanejamento)
           .IsRequired();
        }
    }
}
