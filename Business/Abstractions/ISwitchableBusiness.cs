namespace Business.Abstractions
{
    /// <summary>
    /// Logica general para componentes logicos
    /// </summary>
    public interface ISwitchableBusiness
    {
        /// <summary>
        /// Enciende los componentes logicos
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> TurnOnAsync();

        /// <summary>
        /// Apaga los componentes logicos
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> TurnOffAsync();

        /// <summary>
        /// Obtiene el estado general de los componentes
        /// </summary>
        /// <returns>Estado</returns>
        Task<bool> GetStateAsync();
    }
}
