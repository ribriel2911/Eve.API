using Cross.Entities.Enums;
using Resources.Abstractions.Entities.Samples;

namespace Business.Tests.Samples
{
    public class RadioSample : IRadioSample
    {
        public int Id { get; set; }

        public decimal? Frequency { get; set; }

        public Wave Wave { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}
