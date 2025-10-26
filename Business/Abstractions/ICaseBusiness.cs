namespace Business.Abstractions
{
    /// <summary>
    /// Logica del gabinete
    /// </summary>
    public interface ICaseBusiness : ISwitchableBusiness
    {
        /// <summary>
        /// Obtiene el estado actual de
        /// la pantalla del gabinete
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> GetStateScreenAsync();

        /// <summary>
        /// Enciende la pantalla del gabinete
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> TurnOnScreenAsync();

        /// <summary>
        /// Apaga la pantalla del gabinete
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> TurnOffScreenAsync();

        /// <summary>
        /// Obtiene el estado actual de
        /// las luces del gabinete
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> GetStateLightsAsync();

        /// <summary>
        /// Enciende las luces del gabinete
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> TurnOnLightsAsync();

        /// <summary>
        /// Apaga las luces del gabinete
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> TurnOffLightsAsync();

        /// <summary>
        /// Obtiene el estado actual de
        /// los ventiladores del gabinete
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> GetStateFansAsync();

        /// <summary>
        /// Enciende los ventiladores del gabinete
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> TurnOnFansAsync();

        /// <summary>
        /// Apaga los ventiladores del gabinete
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> TurnOffFansAsync();
    }
}
