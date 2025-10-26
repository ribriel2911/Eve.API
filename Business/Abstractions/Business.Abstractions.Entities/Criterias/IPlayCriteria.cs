namespace Business.Abstractions.Entities.Criterias
{
    /// <summary>
    /// Criteria para reproducir un medio especifico
    /// </summary>
    public interface IPlayCriteria : IChangeCriteria
    {
        /// <summary>
        /// Id de medio a reproducir
        /// </summary>
        int? MediaId { get; }
    }
}
