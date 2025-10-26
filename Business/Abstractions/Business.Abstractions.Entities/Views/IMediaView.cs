namespace Business.Abstractions.Entities.Views
{
    /// <summary>
    /// Vista de medio de reproduccion
    /// </summary>
    public interface IMediaView
    {
        /// <summary>
        /// Nombre
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Tipo
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Estado
        /// </summary>
        bool Playing { get; }

        /// <summary>
        /// Duracion
        /// </summary>
        TimeSpan? Duration { get; }

        /// <summary>
        /// Tiempo de reproduccion
        /// </summary>
        TimeSpan? Played { get; }

        /// <summary>
        /// Frecuencia
        /// </summary>
        decimal? Frequency { get; }

        /// <summary>
        /// Banda
        /// </summary>
        string Wave { get; }
    }
}
