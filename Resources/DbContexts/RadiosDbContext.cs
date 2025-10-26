using Resources.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Resources.Entities.DTOs.Configurations;

namespace Resources.DataContexts
{
    public class RadiosDbContext : BaseDbContext<RadiosDbContext>
    {
        public RadiosDbContext() : base() { }
        public RadiosDbContext(DbContextOptions<RadiosDbContext> options)
            : base(options) { }

        public DbSet<RadioDTO> Radios { get; set; }
        public DbSet<WaveDTO> Waves { get; set; }
        public DbSet<MediaDTO> Medias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MediaDTOConfiguration());
            modelBuilder.ApplyConfiguration(new RadioDTOConfiguration());
            modelBuilder.ApplyConfiguration(new WaveDTOConfiguration());
        }
    }
}
