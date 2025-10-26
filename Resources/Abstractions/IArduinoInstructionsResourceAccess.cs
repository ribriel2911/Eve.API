using Resources.Abstractions.Entities.Parameters;
using Resources.Abstractions.Entities.Samples;

namespace Resources.Abstractions
{
    /// <summary>
    /// Acceso a instrucciones Arduino
    /// </summary>
    public interface IArduinoInstructionsResourceAccess
    {
        /// <summary>
        /// Obtiene las instrucciones para el Arduino
        /// </summary>
        /// <returns>Coleccion de <inheritdoc cref="IArduinoInstructionView" path="/summary"/></returns>
        Task<IEnumerable<IArduinoInstructionSample>> GetInstructionsAsync();

        /// <summary>
        /// Obtiene una instruccion en base al nombre
        /// </summary>
        /// <param name="param"><inheritdoc cref="IGetByNameParameter" path="/summary"/></param>
        /// <returns><inheritdoc cref="IArduinoInstructionView" path="/summary"/></returns>
        Task<IArduinoInstructionSample> GetInstructionByNameAsync(IGetByNameParameter param);
    }
}
