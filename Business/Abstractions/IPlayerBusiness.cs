using Business.Abstractions.Entities.Criterias;
using Business.Abstractions.Entities.Views;

namespace Business.Abstractions
{
    /// <summary>
    /// Logica del reproductor
    /// </summary>
    public interface IPlayerBusiness
    {
        /// <summary>
        /// Determina si hay algun medio en reproduccion
        /// </summary>
        /// <returns></returns>
        Task<IPlayerStateView> GetPlaying();

        /// <summary>
        /// Pausa la reproduccion en curso
        /// </summary>
        /// <returns></returns>
        Task PauseAsync();

        /// <summary>
        /// Reproduce una medio a partir de 
        /// <paramref name="criteria"/>
        /// </summary>
        /// <param name="criteria"><inheritdoc cref="IPlayCriteria" path="/summary"/></param>
        /// <returns><inheritdoc cref="IMediaView" path="/summary"/></returns>
        Task<IMediaView> PlayAsync(IPlayCriteria criteria);

        /// <summary>
        /// Reproduce el siguiente medio de la lista
        /// <paramref name="criteria"/>
        /// </summary>
        /// <param name="criteria"><inheritdoc cref="IChangeCriteria" path="/summary"/></param>
        /// <returns><inheritdoc cref="IMediaView" path="/summary"/></returns>
        Task<IMediaView> NextAsync(IChangeCriteria criteria);

        /// <summary>
        /// Reproduce el medio anterior en la lista
        /// <paramref name="criteria"/>
        /// </summary>
        /// <param name="criteria"><inheritdoc cref="IChangeCriteria" path="/summary"/></param>
        /// <returns><inheritdoc cref="IMediaView" path="/summary"/></returns>
        Task<IMediaView> PreviousAsync(IChangeCriteria criteria);

        /// <summary>
        /// Establece el volumen de la reproduccion en curso
        /// </summary>
        /// <param name="criteria"><inheritdoc cref="IVolumeCriteria" path="/summary"/></param>
        /// <returns></returns>
        Task SetVolumeAsync(IVolumeCriteria criteria);

        /// <summary>
        /// Detiene la reproduccion en curso
        /// </summary>
        /// <returns></returns>
        Task StopAsync();
    }
}
