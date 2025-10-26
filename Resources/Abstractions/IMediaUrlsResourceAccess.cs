using Resources.Abstractions.Entities.Parameters;
using Resources.Abstractions.Entities.Samples;

namespace Resources.Abstractions
{
    /// <summary>
    /// Acceso a archivos media
    /// </summary>
    public interface IMediaUrlsResourceAccess<ITMedia, TParam>
        where ITMedia : IMediaSample
        where TParam : IGetByNameParameter
    {
        /// <summary>
        /// Obtiene un de un medio a partir del parametro de entrada
        /// </summary>
        /// <param name="param"><inheritdoc cref="IGetByNameParameter" path="/summary"/></param>
        /// <returns><inheritdoc cref="IMediaSample" path="/summary"/></returns>
        Task<ITMedia> GetByParameterAsync(TParam param);

        /// <summary>
        /// Obtiene un de un medio a partir de su id
        /// </summary>
        /// <param name="param"><inheritdoc cref="IGetByNameParameter" path="/summary"/></param>
        /// <returns><inheritdoc cref="IMediaSample" path="/summary"/></returns>
        Task<ITMedia> GetByParameterAsync(IGetByIdParameter param);
    }

    /// <inheritdoc cref="IMediaUrlsResourceAccess{ITMedia, TParam}"/>
    public interface IMediaUrlsResourceAccess<ITMedia> : IMediaUrlsResourceAccess<ITMedia, IGetByNameParameter>
        where ITMedia : IMediaSample { }

    /// <inheritdoc cref="IMediaUrlsResourceAccess{ITMedia}"/>
    public interface IMediaUrlsResourceAccess : IMediaUrlsResourceAccess<IMediaSample> { }
}
