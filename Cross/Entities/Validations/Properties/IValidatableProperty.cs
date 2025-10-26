namespace Cross.Entities.Validations.Properties
{
    /// <summary>
    /// Propiedad validable
    /// </summary>
    public interface IValidatableProperty
    {
        /// <summary>
        /// Nombre de la propiedad
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Valida la propiedad
        /// </summary>
        /// <param name="result"></param>
        void Validate(ValidationResult result);
    }

    ///<inheritdoc cref="IValidatableProperty"/>
    public interface IValidatableProperty<TProperty> : IValidatableProperty
    {
        /// <summary>
        /// Establece una validacion a la propiedad
        /// </summary>
        /// <param name="validation">Validacion</param>
        /// <param name="message">Mensaje de error</param>
        /// <param name="parameters">Parametros</param>
        /// <returns><inheritdoc cref="IValidatableProperty" path="/summary"/></returns>
        IValidatableProperty<TProperty> SetValidation(Func<TProperty, bool> validation, string message, params object[] parameters);

        /// <summary>
        /// Establece una validacion a la propiedad
        /// </summary>
        /// <param name="validation">Validacion</param>
        /// <returns><inheritdoc cref="IValidatableProperty" path="/summary"/></returns>
        IValidatableProperty<TProperty> SetValidation(Func<TProperty, ValidationResult, bool> validation);

        /// <summary>
        /// Determina como invalida una condicion preestablecida
        /// </summary>
        /// <param name="validation">Validacion</param>
        /// <param name="message">Mensaje de error</param>
        /// <returns><inheritdoc cref="IValidatableProperty" path="/summary"/></returns>
        IValidatableProperty<TProperty> SetInvalid(string message);
    }
}
