using Resources.Abstractions.Entities.Parameters;

namespace Resources.Abstractions
{
    /// <summary>
    /// Acceso al Arduino
    /// </summary>
    public interface IArduinoResourceAccess
    {
        /// <summary>
        /// Ejecuta la instruccion enviada en <see cref="IExecuteParameter"/>
        /// </summary>
        /// <param name="param"><inheritdoc cref="IExecuteParameter"
        ///                 path="/summary"/></param>
        /// <returns>Estado resultande de ejecucion de la instruccion</returns>
        Task<bool> ExecuteAsync(IExecuteParameter param);

        /// <summary>
        /// Reinicia el arduino.
        /// </summary>
        /// <returns>Mensaje de confirmacion</returns>
        Task<string> ResetAsync();

        /// <summary>
        /// Obtiene el estado actual de los componentes
        /// </summary>
        /// <returns>Coleccion de estados de los componentes</returns>
        Task<bool[]> GetStatesAsync();
    }
}
