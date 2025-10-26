using Cross.Abstractions;

namespace Cross.Entities.Validations
{
    /// <summary>
    /// Extension para entidades validables.
    /// </summary>
    public static class ValidatableExtensions
    {
        /// <summary>
        /// Genera una instancia de <see cref="ValidationBuilder{TEntity}"/> para la entidad.
        /// </summary>
        /// <typeparam name="TEntity"><inheritdoc cref="IValidatable" path="/summary"/></typeparam>
        /// <param name="entity">Entidad que extiende</param>
        /// <returns><inheritdoc cref="ValidationBuilder{TEntity}" path="/summary"/></returns>
        public static ValidationBuilder<TEntity> GetValidationBuilder<TEntity>(this TEntity entity)
            where TEntity : IValidatable
        {
            return new ValidationBuilder<TEntity>(entity);
        }
    }
}
