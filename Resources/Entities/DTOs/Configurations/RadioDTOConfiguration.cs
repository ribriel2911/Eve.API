using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Resources.Entities.DTOs.Configurations
{
    public class RadioDTOConfiguration : IEntityTypeConfiguration<RadioDTO>
    {
        public void Configure(EntityTypeBuilder<RadioDTO> builder)
        {
            builder.ToTable("Radios");

            builder.HasKey(r => r.Id)
                .HasName("PK_Radios_Id");

            builder.Property(r => r.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(r => r.Frequency)
                .HasPrecision(5, 1);

            builder.Property(r => r.WaveId)
                .IsRequired();

            builder.HasOne(r => r.Wave)
                .WithMany(w => w.Radios)
                .HasForeignKey(r => r.WaveId);

            builder.HasMany(r => r.Medias)
                .WithOne(m => m.Radio)
                .HasForeignKey(m => m.RadioId);
        }
    }
}
