using Cross.Entities.Helpers;
using System.Linq.Expressions;

namespace Cross.Entities.Validations.Properties
{
    ///<inheritdoc cref="IValidatableProperty"/>
    internal class ValidatableProperty<TEntity, TProperty> : IValidatableProperty<TProperty>
    {
        #region Fields
        private readonly TEntity entity;
        private readonly Expression<Func<TEntity, TProperty>> expression;
        private readonly List<Func<TProperty, ValidationResult, bool>> validations;
        #endregion

        #region Properties
        ///<inheritdoc cref="IValidatableProperty.Name"/>
        public string Name { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entity"><inheritdoc cref="IValidatable" path="/summary"/> a la que pertenece</param>
        /// <param name="expression">Expresion lamda de validacion</param>
        /// <param name="name"><inheritdoc cref="IValidatableProperty.Name" path="/summary"/></param>
        public ValidatableProperty(
            TEntity entity,
            Expression<Func<TEntity, TProperty>> expression,
            string name)
        {
            this.entity = entity;
            this.expression = expression;
            Name = name;
            validations = new List<Func<TProperty, ValidationResult, bool>>();
        }
        #endregion

        #region Public Methods
        ///<inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, bool}, string, object[])"/>
        public IValidatableProperty<TProperty> SetValidation(Func<TProperty, bool> validation, string message, params object[] parameters)
        {
            return SetValidation((value, result) =>
            {
                var isValid = validation(value);

                if (!isValid)
                {
                    var errorMessage = string.Format(message, new object[] { Name, value }.Concat(parameters).ToArray());
                    result.AddError(errorMessage);
                }

                return isValid;
            });
        }

        ///<inheritdoc cref="IValidatableProperty{TProperty}.SetValidation(Func{TProperty, ValidationResult, bool})"/>
        public IValidatableProperty<TProperty> SetValidation(Func<TProperty, ValidationResult, bool> validation)
        {
            validations.Add(validation);
            return this;
        }

        public IValidatableProperty<TProperty> SetInvalid(string message)
        {
            return SetValidation((value, result) =>
            {
                var errorMessage = string.Format(message, new object[] { Name, value });
                result.AddError(errorMessage);

                return false;
            });
        }

        ///<inheritdoc cref="IValidatableProperty.Validate(ValidationResult)"/>
        public void Validate(ValidationResult result)
        {
            var value = expression.Compile()(entity);

            foreach (var validation in validations)
            {
                var isValid = validation(value, result);

                if (!isValid) break;
            }
        }
        #endregion
    }
}
