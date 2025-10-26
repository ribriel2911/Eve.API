using Resources.Abstractions.Entities.Parameters;
using Resources.Abstractions.Entities.Samples;

namespace Resources.Abstractions
{
    /// <summary>
    /// Acceso a archivos de radio
    /// </summary>
    public interface IRadiosResourceAccess : IMediaUrlsResourceAccess<IRadioSample, IGetByRadioParameter>
    {
        /// <summary>
        /// Obtiene las url de los medios de radio
        /// </summary>
        /// <returns>Coleccion de <inheritdoc cref="IRadioSample" path="/summary"/></returns>
        Task<IEnumerable<IRadioSample>> GetRadiosAsync();

        /// <summary>
        /// Actualiza el estado de un medio de radio
        /// </summary>
        /// <param name="parameter"><inheritdoc cref="ISetStatusParameter" path="/summary"/></param>
        Task SetStatusAsync(ISetStatusParameter parameter);
    }
}
