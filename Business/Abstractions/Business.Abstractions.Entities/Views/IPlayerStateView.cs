namespace Business.Abstractions.Entities.Views
{
    /// <summary>
    /// Vista de estado del reproductor
    /// </summary>
    public interface IPlayerStateView
    {
        /// <summary>
        /// Ultimo medio en reproduccion
        /// </summary>
        IMediaView Media { get; }

        /// <summary>
        /// Valor del volumen (0-100)
        /// </summary>
        int Volume { get; }

        /// <summary>
        /// Bandera indicadora de seleccion de medio aleatorio
        /// </summary>
        bool Aleatory { get; }

        /// <summary>
        /// Bandera indicadora de repeticion de medios
        /// </summary>
        int RepeatMode { get; }
    }
}
