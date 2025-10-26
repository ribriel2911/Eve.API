namespace Resources.Abstractions.Entities.Parameters
{
    /// <summary>
    /// Parametro para actualizar el estado de un medio de radio
    /// </summary>
    public interface ISetStatusParameter : IGetByIdParameter
    {
        /// <summary>
        /// Estado actualizado
        /// </summary>
        bool Status { get; }
    }
}
