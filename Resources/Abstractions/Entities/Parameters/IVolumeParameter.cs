namespace Resources.Abstractions.Entities.Parameters
{
    /// <summary>
    /// Parametro para establecer el valor del volumen
    /// </summary>
    public interface IVolumeParameter
    {
        /// <summary>
        /// Valor del volumen (0-100)
        /// </summary>
        int Volume { get; }
    }
}
