using Cross.Entities.Enums;

namespace Resources.Abstractions.Entities.Parameters
{
    /// <summary>
    /// Parametro para obtener una radio
    /// </summary>
    public interface IGetByRadioParameter : IGetByNameParameter
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
