using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Marca)
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(t => t.Modelo)
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(t => t.Versao)
                .HasMaxLength(45)
                .IsRequired();
        }
    }
}
