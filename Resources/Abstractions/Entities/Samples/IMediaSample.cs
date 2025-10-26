namespace Resources.Abstractions.Entities.Samples
{
    /// <summary>
    /// Vista de medio de reproduccion
    /// </summary>
    public interface IMediaSample
    {
        /// <summary>
        /// Id de medio
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Nombre del Medio
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Url del Medio
        /// </summary>
        string Url { get; }
    }
}
