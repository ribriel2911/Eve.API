using Cross.Extensions;

namespace Cross.Entities.Validations.Properties.Extensions
{
    /// <summary>
    /// Extension para <inheritdoc cref="IValidatableProperty" path="/summary"/><see cref="string"/> numerica
    /// </summary>
    public static class NumberExtensions
    {

        /// <summary>
        ///     <inheritdoc cref="SetIsNumeric(IValidatableProperty{string}, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.INVALID_MESSAGE"/></para>
        /// </summary>
        /// <param name="property"></param>
        /// <returns>
        ///     <inheritdoc cref="SetIsNumeric(IValidatableProperty{string}, string)"
        ///                 path="/returns"/></returns>
        public static IValidatableProperty<string> SetIsNumeric(this IValidatableProperty<string> property)
        {
            return property.SetIsNumeric(ValidationMessages.INVALID_MESSAGE);
        }

        /// <summary>
        /// Establece la validacion de que la propiedad sea numerica
        /// </summary>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="string"/></returns>
        public static IValidatableProperty<string> SetIsNumeric(this IValidatableProperty<string> property, string message)
        {
            return property.SetValidation(value => value.IsNumeric(), message);
        }


        /// <summary>
        ///     <inheritdoc cref="SetIsGreaterThan(IValidatableProperty{int}, int, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.INVALID_MESSAGE"/></para>
        /// </summary>
        /// <param name="compared">Valor comparado</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="int"/></returns>
        public static IValidatableProperty<int> SetIsGreaterThan(this IValidatableProperty<int> property, int compared)
        {
            return property.SetIsGreaterThan(compared, ValidationMessages.INVALID_MESSAGE);
        }


        /// <summary>
        /// Establece la validacion de que un entero sea mayor que
        /// <paramref name="compared"/>
        /// </summary>
        /// <param name="compared">Valor comparado</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="int"/></returns>
        public static IValidatableProperty<int> SetIsGreaterThan(this IValidatableProperty<int> property, int compared, string message)
        {
            return property.SetValidation(value => value > compared, message);
        }

        /// <summary>
        ///     <inheritdoc cref="SetIsGreaterOrEqualTo(IValidatableProperty{int}, int, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.INVALID_MESSAGE"/></para>
        /// </summary>
        /// <param name="compared">Valor comparado</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="int"/></returns>
        public static IValidatableProperty<int> SetIsGreaterOrEqualTo(this IValidatableProperty<int> property, int compared)
        {
            return property.SetIsGreaterOrEqualTo(compared, ValidationMessages.INVALID_MESSAGE);
        }

        /// <summary>
        ///     <inheritdoc cref="SetIsGreaterOrEqualTo(IValidatableProperty{int?}, int, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.INVALID_MESSAGE"/></para>
        /// </summary>
        /// <param name="compared">Valor comparado</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="int"/></returns>
        public static IValidatableProperty<int?> SetIsGreaterOrEqualTo(this IValidatableProperty<int?> property, int compared)
        {
            return property.SetIsGreaterOrEqualTo(compared, ValidationMessages.INVALID_MESSAGE);
        }

        /// <summary>
        /// Establece la validacion de que un entero sea mayor o igual que
        /// <paramref name="compared"/>
        /// </summary>
        /// <param name="compared">Valor comparado</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="int"/></returns>
        public static IValidatableProperty<int> SetIsGreaterOrEqualTo(this IValidatableProperty<int> property, int compared, string message)
        {
            return property.SetValidation(value => value >= compared, message);
        }

        /// <summary>
        /// Establece la validacion de que un entero nuleable sea 
        /// nulo, mayor o igual que
        /// <paramref name="compared"/>
        /// </summary>
        /// <param name="compared">Valor comparado</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="int"/></returns>
        public static IValidatableProperty<int?> SetIsGreaterOrEqualTo(this IValidatableProperty<int?> property, int compared, string message)
        {
            return property.SetValidation(value => value is null || value >= compared, message);
        }

        /// <summary>
        ///     <inheritdoc cref="SetIsLessThan(IValidatableProperty{int}, int, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.INVALID_MESSAGE"/></para>
        /// </summary>
        /// <param name="compared">Valor comparado</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="int"/></returns>
        public static IValidatableProperty<int> SetIsLessThan(this IValidatableProperty<int> property, int compared)
        {
            return property.SetIsLessThan(compared, ValidationMessages.INVALID_MESSAGE);
        }

        /// <summary>
        /// Establece la validacion de que un entero sea menor que
        /// <paramref name="compared"/>
        /// </summary>
        /// <param name="compared">Valor comparado</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="int"/></returns>
        public static IValidatableProperty<int> SetIsLessThan(this IValidatableProperty<int> property, int compared, string message)
        {
            return property.SetValidation(value => value < compared, message);
        }

        /// <summary>
        ///     <inheritdoc cref="SetIsLessOrEqualTo(IValidatableProperty{int}, int, string)"
        ///                 path="/summary"/> con mensaje generico
        ///     <para><see cref="ValidationMessages.INVALID_MESSAGE"/></para>
        /// </summary>
        /// <param name="compared">Valor comparado</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="int"/></returns>
        public static IValidatableProperty<int> SetIsLessOrEqualTo(this IValidatableProperty<int> property, int compared)
        {
            return property.SetIsLessOrEqualTo(compared, ValidationMessages.INVALID_MESSAGE);
        }

        /// <summary>
        /// Establece la validacion de que un entero sea menor o igual que
        /// <paramref name="compared"/>
        /// </summary>
        /// <param name="compared">Valor comparado</param>
        /// <param name="message">
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/param[@name='message']"/></param>
        /// <returns>
        ///     <inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"
        ///                 path="/returns"/> <see cref="int"/></returns>
        public static IValidatableProperty<int> SetIsLessOrEqualTo(this IValidatableProperty<int> property, int compared, string message)
        {
            return property.SetValidation(value => value <= compared, message);
        }
    }
}
