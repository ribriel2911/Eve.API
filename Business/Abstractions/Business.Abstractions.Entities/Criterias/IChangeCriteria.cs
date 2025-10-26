using Cross.Entities.Enums;

namespace Business.Abstractions.Entities.Criterias
{
    /// <summary>
    /// Criteria para reproducir el siguiente medio de la lista
    /// </summary>
    public interface IChangeCriteria : IVolumeCriteria
    {
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
