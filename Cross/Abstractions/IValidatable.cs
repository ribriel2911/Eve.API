namespace Cross.Abstractions
{
    /// <summary>
    /// Entidad validable
    /// </summary>
    public interface IValidatable
    {
        /// <summary>
        /// Valida la entidad
        /// </summary>
        /// <returns><see cref="IValidationResult"/> : <inheritdoc cref="IValidationResult" path="/summary"/></returns>
        IValidationResult Validate();
    }
}
