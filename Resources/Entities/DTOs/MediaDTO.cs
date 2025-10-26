using Resources.Abstractions.Entities.Samples;
using System.ComponentModel.DataAnnotations;

namespace Resources.Entities.DTOs
{
    public class MediaDTO : IMediaSample
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public int? RadioId { get; set; }

        public bool Status { get; set; }

        public virtual RadioDTO Radio { get; set; }
    }
}
