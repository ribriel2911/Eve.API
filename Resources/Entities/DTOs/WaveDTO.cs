namespace Resources.Entities.DTOs
{
    public class WaveDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RadioDTO> Radios { get; set; } = new List<RadioDTO>();
    }
}
