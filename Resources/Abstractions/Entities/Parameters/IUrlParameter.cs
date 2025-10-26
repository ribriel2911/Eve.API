namespace Resources.Abstractions.Entities.Parameters
{
    /// <summary>
    /// Parametro para instanciar un medio a partir de su url
    /// </summary>
    public interface IUrlParameter
    {
        /// <summary>
        /// Url del medio
        /// </summary>
        string Url { get; }
    }
}
