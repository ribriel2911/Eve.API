using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Resources.Entities.DTOs.Configurations
{
    public class WaveDTOConfiguration : IEntityTypeConfiguration<WaveDTO>
    {
        public void Configure(EntityTypeBuilder<WaveDTO> builder)
        {
            builder.ToTable("Waves");

            builder.HasKey(w => w.Id)
                .HasName("PK_Waves_Id");

            builder.Property(r => r.Id)
                .HasColumnName("Id");

            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(w => w.Radios)
                .WithOne(r => r.Wave)
                .HasForeignKey(r => r.WaveId);
        }
    }
}
