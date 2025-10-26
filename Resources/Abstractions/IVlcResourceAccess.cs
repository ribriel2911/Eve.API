using Resources.Abstractions.Entities.Parameters;

namespace Resources.Abstractions
{
    /// <summary>
    /// Acceso al reproductor VLC
    /// </summary>
    public interface IVlcResourceAccess
    {
        /// <summary>
        /// Inicia la reproduccion de un medio a partir de un
        /// <see cref="FileInfo"/>
        /// </summary>
        /// <param name="param"><inheritdoc cref="IFileInfoParameter"/></param>
        Task PlayAsync(IFileInfoParameter param);

        /// <summary>
        /// Inicia la reproduccion de un medio a partir de un
        /// <see cref="Uri"/>
        /// </summary>
        /// <param name="param"><inheritdoc cref="Uri" path="/summary"/></param>
        /// <returns></returns>
        Task PlayAsync(Uri param);

        /// <summary>
        /// Continua la reproduccion del medio en reproduccion
        /// <see cref="Uri"/>
        /// </summary>
        /// <returns></returns>
        Task PlayAsync();

        /// <summary>
        /// <inheritdoc cref="PlayAsync(IFileInfoParameter)"/>
        /// </summary>
        /// <param name="param"><inheritdoc cref="IUrlParameter" path="/summary"/></param>
        Task PlayFileAsync(IUrlParameter param);

        /// <summary>
        /// <inheritdoc cref="PlayAsync(Uri))" path="/summary"/>
        /// </summary>
        /// <param name="param"><inheritdoc cref="IUrlParameter" path="/summary"/></param>
        Task PlayUriAsync(IUrlParameter param);

        /// <summary>
        /// Detiene la reproduccion en curso
        /// </summary>
        Task StopAsync();

        /// <summary>
        /// Pausa la reproduccion en curso
        /// </summary>
        Task PauseAsync();

        /// <summary>
        /// Establece el volumen del reproductor a partir de su
        /// <inheritdoc cref="IVolumeParameter.Volume"/>
        /// </summary>
        /// <param name="param"><inheritdoc cref="IVolumeParameter" path="/summary"/></param>
        Task SetVolumeAsync(IVolumeParameter param);


        /// <summary>
        /// Verifica si existe una pista en reproduccion
        /// </summary>
        /// <returns>Estado de reproduccion en curso</returns>
        Task<bool> IsNowPlayingAsync();
    }
}
