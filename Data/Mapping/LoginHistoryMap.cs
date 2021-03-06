using Domain.Entities.History;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class LoginHistoryMap : IEntityTypeConfiguration<LoginHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<LoginHistoryEntity> builder)
        {
            builder.ToTable("LoginHistory");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
           .IsRequired();

            builder.Property(u => u.Email)
           .IsRequired();

        }
    }
}
