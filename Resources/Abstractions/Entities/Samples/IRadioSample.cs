using Cross.Entities.Enums;

namespace Resources.Abstractions.Entities.Samples
{
    /// <summary>
    /// Vista de Radio
    /// </summary>
    public interface IRadioSample : IMediaSample
    {
        /// <summary>
        /// Frequencia de la radio
        /// </summary>
        decimal? Frequency { get; }

        /// <summary>
        /// Banda de la radio
        /// </summary>
        Wave Wave { get; }
    }
}
