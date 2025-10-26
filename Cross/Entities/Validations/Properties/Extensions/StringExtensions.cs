namespace Cross.Entities.Validations.Properties.Extensions
{
    /// <summary>
    /// Extension para <inheritdoc cref="IValidatableProperty" path="/summary"/><see cref="string"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     <inheritdoc cref="SetNotNullOrEmpty(IValidatableProperty{string}, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.EMPTY_MESSAGE"/></para>
        /// </summary>
        /// <returns>
        ///     <inheritdoc cref="SetNotNullOrEmpty(IValidatableProperty{string}, string)"
        ///                 path="/returns"/></returns>
        public static IValidatableProperty<string> SetNotNullOrEmpty(this IValidatableProperty<string> property)
        {
            return property.SetNotNullOrEmpty(ValidationMessages.EMPTY_MESSAGE);
        }

        /// <summary>
        /// Establece la validacion de que la propiedad no esta vacia o nula
        /// </summary>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="string"/></returns>
        public static IValidatableProperty<string> SetNotNullOrEmpty(this IValidatableProperty<string> property, string message)
        {
            return property.SetValidation(value => !string.IsNullOrEmpty(value), message);
        }

        /// <summary>
        ///     <inheritdoc cref="SetNotNullOrWhiteSpace(IValidatableProperty{string}, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.EMPTY_MESSAGE"/></para>
        /// </summary>
        /// <returns>
        ///     <inheritdoc cref="SetNotNullOrWhiteSpace(IValidatableProperty{string}, string)"
        ///                 path="/returns"/></returns>
        public static IValidatableProperty<string> SetNotNullOrWhiteSpace(this IValidatableProperty<string> property)
        {
            return property.SetNotNullOrWhiteSpace(ValidationMessages.EMPTY_MESSAGE);
        }

        /// <summary>
        /// Establece la validacion de que la propiedad no esta vacia, nula
        /// o contenga unicamente espacios vacios
        /// </summary>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="string"/></returns>
        public static IValidatableProperty<string> SetNotNullOrWhiteSpace(this IValidatableProperty<string> property, string message)
        {
            return property.SetValidation(value => !string.IsNullOrWhiteSpace(value), message);
        }

        /// <summary>
        ///     <inheritdoc cref="SetNotEmptyOrWhiteSpace(IValidatableProperty{string}, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.EMPTY_MESSAGE"/></para>
        /// </summary>
        /// <returns>
        ///     <inheritdoc cref="SetNotNullOrWhiteSpace(IValidatableProperty{string}, string)"
        ///                 path="/returns"/></returns>
        public static IValidatableProperty<string> SetNotEmptyOrWhiteSpace(this IValidatableProperty<string> property)
        {
            return property.SetNotEmptyOrWhiteSpace(ValidationMessages.EMPTY_MESSAGE);
        }

        /// <summary>
        /// Establece la validacion de que la propiedad no esta vacia o
        /// contenga unicamente espacios vacios
        /// </summary>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="string"/></returns>
        public static IValidatableProperty<string> SetNotEmptyOrWhiteSpace(this IValidatableProperty<string> property, string message)
        {
            return property.SetValidation(value => !string.IsNullOrWhiteSpace(value) || value == null, message);
        }
    }
}
