namespace Resources.Abstractions.Entities.Parameters
{
    /// <summary>
    /// Parametro para obtener un recurso a partir del nombre
    /// </summary>
    public interface IGetByNameParameter
    {
        /// <summary>
        /// Nombre del recurso
        /// </summary>
        string Name { get; }
    }
}
