using Cross.Entities.Helpers;

namespace Cross.Entities.Validations.Properties.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Establece la validacion de que el parametro ingresado pertenezca a la enumeracion
        /// <typeparamref name="TEnum"/>
        /// </summary>
        /// <typeparam name="TProperty">Tipo de propiedad enumerable</typeparam>
        /// <typeparam name="TEnum">Tipo de enumeracion</typeparam>
        /// <param name="property">Propiedad enumerable</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/>
        /// </param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/>
        ///     <typeparamref name="TEnum"/>
        /// </returns>
        public static IValidatableProperty<TProperty> SetIsDefined<TProperty, TEnum>(
            this IValidatableProperty<TProperty> property, string message)
            where TProperty : struct
        {
            return property.SetValidation(value => Enum.IsDefined(typeof(TEnum), value), message);
        }

        /// <summary>
        /// <inheritdoc cref="SetIsDefined{TProperty, TEnum}(IValidatableProperty{TProperty}, string)"/>
        /// con mensaje generico
        /// </summary>
        /// <typeparam name="TProperty">
        ///     <inheritdoc cref="SetIsDefined{TProperty, TEnum}(IValidatableProperty{TProperty}, string)"
        ///                 path="/typeparam[@name='TProperty']"/>
        /// </typeparam>
        /// <typeparam name="TEnum">
        ///     <inheritdoc cref="SetIsDefined{TProperty, TEnum}(IValidatableProperty{TProperty}, string)"
        ///                 path="/typeparam[@name='TEnum']"/>
        /// </typeparam>
        /// <param name="property">
        ///     <inheritdoc cref="SetIsDefined{TProperty, TEnum}(IValidatableProperty{TProperty}, string)"
        ///                 path="/param[@name='property']"/>
        /// </param>
        /// <returns></returns>
        public static IValidatableProperty<TProperty> SetIsDefined<TProperty, TEnum>(
            this IValidatableProperty<TProperty> property)
            where TProperty : struct
        {
            return property.SetIsDefined<TProperty, TEnum>(ValidationMessages.INVALID_MESSAGE);
        }
    }
}
