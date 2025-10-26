namespace Cross.Abstractions
{
    /// <summary>
    /// Interfaz para la creacion de builders
    /// </summary>
    /// <typeparam name="T">Objeto a construir</typeparam>
    public interface IBuilder<T>
    {
        /// <summary>
        /// Constructor del objeto
        /// </summary>
        /// <returns>Objeto a construir</returns>
        T Build();
    }
}
