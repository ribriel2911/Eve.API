namespace Cross.Entities.Validations.Properties
{
    /// <summary>
    /// <inheritdoc cref="IValidatableProperty{TProperty}" path="/summary"/> condicional
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    internal class ConditionalValidatableProperty<TProperty> : IValidatableProperty<TProperty>
    {
        #region Fields
        private readonly IValidatableProperty<TProperty> inner;
        private readonly Func<bool> condition;
        #endregion

        #region Properties
        ///<inheritdoc cref="IValidatableProperty.Name"/>
        public string Name { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="inner"><inheritdoc cref="IValidatableProperty{TProperty}" path="/summary"/> base</param>
        /// <param name="condition">Condicion a cumplir para la validacion</param>
        public ConditionalValidatableProperty(IValidatableProperty<TProperty> inner, Func<bool> condition)
        {
            this.inner = inner;
            this.condition = condition;
        }
        #endregion

        #region Public Methods
        ///<inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"/>
        public IValidatableProperty<TProperty> SetValidation(
            Func<TProperty, bool> validation, string message, params object[] parameters)
        {
            return inner.SetValidation(validation, message, parameters);
        }
        ///<inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, ValidationResult, bool})"/>
        public IValidatableProperty<TProperty> SetValidation(
            Func<TProperty, ValidationResult, bool> validation)
        {
            return inner.SetValidation(validation);
        }

        public IValidatableProperty<TProperty> SetInvalid(string message)
        {
            return inner.SetInvalid(message);
        }

        /// <summary>
        /// <inheritdoc cref="IValidatableProperty.Validate(ValidationResult)" path="/summary"/>
        /// si se cumple la condicion.
        /// </summary>
        /// <param name="result"></param>
        public void Validate(ValidationResult result)
        {
            if (condition())
            {
                inner.Validate(result);
            }
        }
        #endregion
    }
}
