using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Resources.Entities.DTOs.Configurations
{
    public class MediaDTOConfiguration : IEntityTypeConfiguration<MediaDTO>
    {
        public void Configure(EntityTypeBuilder<MediaDTO> builder)
        {
            builder.ToTable("Medias");

            builder.HasKey(w => w.Id)
                .HasName("PK_Medias_Id");

            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(m => m.Radio)
                .WithMany(r => r.Medias)
                .HasForeignKey(m => m.RadioId);
        }
    }
}
