namespace Resources.Abstractions.Entities.Parameters
{
    /// <summary>
    /// Parametro para obtener un recurso a partir de su id
    /// </summary>
    public interface IGetByIdParameter
    {
        /// <summary>
        /// Id del recurso
        /// </summary>
        int Id { get; }
    }
}
