using System.ComponentModel.DataAnnotations;

namespace Resources.Entities.DTOs
{
    public class RadioDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Frequency { get; set; }

        [Required]
        public int WaveId { get; set; }

        public virtual WaveDTO Wave { get; set; }
        public virtual List<MediaDTO> Medias { get; set; } = new List<MediaDTO>();

    }
}
