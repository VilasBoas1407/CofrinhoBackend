using Domain.Entities.Planejamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Planejamento
{
    public class PlanejamentoMap : IEntityTypeConfiguration<PlanejamentoEntity>
    {
        public void Configure(EntityTypeBuilder<PlanejamentoEntity> builder)
        {
            builder.ToTable("Planejamento");

            builder.HasKey(u => u.Id);
        
            builder.Property(u => u.IdUsuario)
           .IsRequired();

            builder.Property(u => u.MesReferencia)
           .IsRequired();

            builder.Property(u => u.AnoReferencia)
            .IsRequired();      

            builder.Property(u => u.DataInicio)
            .IsRequired();

            builder.Property(u => u.DataFim)
            .IsRequired();    

        }
    }
}
