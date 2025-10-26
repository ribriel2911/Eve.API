namespace Cross.Entities.Validations.Properties.Extensions
{
    /// <summary>
    /// Extension para <inheritdoc cref="IValidatableProperty" path="/summary"/>
    /// </summary>
    public static class ValidatablePropertyExtensions
    {
        /// <summary>
        /// Establece la validacion de que la propiedad no pertenezca a una coleccion de valores
        /// </summary>
        /// <param name="collection">Coleccion de valores</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/></returns>
        public static IValidatableProperty<TProperty> SetNotIn<TProperty>(this IValidatableProperty<TProperty> property, IEnumerable<TProperty> collection, string message)
        {
            return property.SetValidation(value => !collection.Contains(value), message);
        }

        /// <summary>
        ///     <inheritdoc cref="SetNotIn{TProperty}(IValidatableProperty{TProperty}, IEnumerable{TProperty}, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.INVALID_MESSAGE"/></para>
        /// </summary>
        /// <param name="collection">
        ///     <inheritdoc cref="SetNotIn{TProperty}(IValidatableProperty{TProperty}, IEnumerable{TProperty}, string)"
        ///                 path="/param[@name='collection']"/></param>
        /// <returns>
        ///     <inheritdoc cref="SetNotIn{TProperty}(IValidatableProperty{TProperty}, IEnumerable{TProperty}, string)"
        ///                 path="/returns"/></returns>
        public static IValidatableProperty<TProperty> SetNotIn<TProperty>(this IValidatableProperty<TProperty> property, IEnumerable<TProperty> collection)
        {
            return property.SetNotIn(collection, ValidationMessages.INVALID_MESSAGE);
        }

        /// <summary>
        /// Establece la validacion de que la propiedad pertenezca a una coleccion de valores
        /// </summary>
        /// <param name="collection">Coleccion de valores</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/></returns>
        public static IValidatableProperty<TProperty> SetIn<TProperty>(this IValidatableProperty<TProperty> property, IEnumerable<TProperty> collection, string message)
        {
            return property.SetValidation(value => collection.Contains(value), message);
        }

        /// <summary>
        ///     <inheritdoc cref="SetIn{TProperty}(IValidatableProperty{TProperty}, IEnumerable{TProperty}, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.INVALID_MESSAGE"/></para>
        /// </summary>
        /// <param name="collection">
        ///     <inheritdoc cref="SetIn{TProperty}(IValidatableProperty{TProperty}, IEnumerable{TProperty}, string)"
        ///                 path="/param[@name='collection']"/></param>
        /// <returns>
        ///     <inheritdoc cref="SetIn{TProperty}(IValidatableProperty{TProperty}, IEnumerable{TProperty}, string)"
        ///                 path="/returns"/></returns>
        public static IValidatableProperty<TProperty> SetIn<TProperty>(this IValidatableProperty<TProperty> property, IEnumerable<TProperty> collection)
        {
            return property.SetIn(collection, ValidationMessages.INVALID_MESSAGE);
        }

        /// <summary>
        /// Establece la validacion de que la propiedad no sea nula
        /// </summary>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/></returns>
        public static IValidatableProperty SetNotNull<TProperty>(this IValidatableProperty<TProperty> property, string message)
        {
            return property.SetValidation(value => value != null, message);
        }

        /// <summary>
        ///     <inheritdoc cref="SetNotNull{TProperty}(IValidatableProperty{TProperty}, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.EMPTY_MESSAGE"/></para>
        /// </summary>
        /// <returns>
        ///     <inheritdoc cref="SetNotNull{TProperty}(IValidatableProperty{TProperty}, string)"
        ///                 path="/returns"/></returns>
        public static IValidatableProperty SetNotNull<TProperty>(this IValidatableProperty<TProperty> property)
        {
            return property.SetNotNull(ValidationMessages.EMPTY_MESSAGE);
        }
    }
}
