namespace API.Entities.Inputs
{
    public class ChangeInput : VolumeInput
    {
        public bool Aleatory { get; set; }

        public int RepeatMode { get; set; }
    }
}
