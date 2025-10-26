namespace Business.Abstractions.Entities.Criterias
{
    /// <summary>
    /// Criteria para establecer el volumen de un medio
    /// </summary>
    public interface IVolumeCriteria
    {
        /// <summary>
        /// Valor del volumen (0-100)
        /// </summary>
        int Volume { get; }
    }
}
