using Cross.Entities.Validations.Properties;
using Cross.Abstractions;
using System.Linq.Expressions;
using Cross.Entities.Helpers;

namespace Cross.Entities.Validations
{
    /// <summary>
    /// Constructor de validacion.
    /// </summary>
    /// <typeparam name="TEntity"><inheritdoc cref="IValidatable" path="/summary"/></typeparam>
    public class ValidationBuilder<TEntity> : IBuilder<ValidationResult> where TEntity : IValidatable
    {
        #region Fields
        private readonly TEntity entity;
        private readonly List<IValidatableProperty> properties;
        private readonly ValidationResult result;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="entity"><inheritdoc cref="IValidatable" path="/summary"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidationBuilder(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.entity = entity;
            this.properties = new List<IValidatableProperty>();
            this.result = new ValidationResult();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// <inheritdoc cref="ValidationBuilder{TEntity}.For{TProperty}(Expression{Func{TEntity, TProperty}}, string)"
        ///             path="/summary"/>
        /// </summary>
        /// <typeparam name="TProperty"><inheritdoc cref="ValidationBuilder{TEntity}.For{TProperty}(Expression{Func{TEntity, TProperty}}, string)" 
        ///                                         path="/typeparam"/></typeparam>
        /// <param name="expression">
        ///     <inheritdoc cref="ValidationBuilder{TEntity}.For{TProperty}(Expression{Func{TEntity, TProperty}}, string)" 
        ///                 path="/param[@name='expression']"/></param>
        /// <param name="condition">
        ///     <inheritdoc cref="ValidationBuilder{TEntity}.For{TProperty}(Expression{Func{TEntity, TProperty}}, Func{TEntity, bool}, string)"
        ///                 path="/param[@name='condition']"/></param>
        /// <returns></returns>
        public IValidatableProperty<TProperty> For<TProperty>(Expression<Func<TEntity, TProperty>> expression,
            Func<TEntity, bool> condition)
        {
            this.Validate(expression);

            var name = EntitiesHelper.GetPropertyName(expression);

            return this.For(expression, condition, name);
        }


        /// <summary>
        /// <inheritdoc cref="ValidationBuilder{TEntity}.For{TProperty}(Expression{Func{TEntity, TProperty}}, string)"
        ///             path="/summary"/>
        /// </summary>
        /// <typeparam name="TProperty"><inheritdoc cref="ValidationBuilder{TEntity}.For{TProperty}(Expression{Func{TEntity, TProperty}}, string)" 
        ///                                         path="/typeparam"/></typeparam>
        /// <param name="expression">
        ///     <inheritdoc cref="ValidationBuilder{TEntity}.For{TProperty}(Expression{Func{TEntity, TProperty}}, string)" 
        ///                 path="/param[@name='expression']"/></param>
        /// <param name="condition">
        ///     <inheritdoc cref="ConditionalValidatableProperty{TProperty}.
        ///                     ConditionalValidatableProperty(IValidatableProperty{TProperty}, Func{bool})"
        ///                 path="/param[@name='condition']"/></param>
        /// <param name="name">
        ///     <inheritdoc cref="ValidationBuilder{TEntity}.For{TProperty}(Expression{Func{TEntity, TProperty}}, string)" 
        ///                 path="/param[@name='name']"/></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IValidatableProperty<TProperty> For<TProperty>(
            Expression<Func<TEntity, TProperty>> expression, Func<TEntity, bool> condition, string name)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            var inner = this.CreateProperty(expression, name);
            var newProperty = new ConditionalValidatableProperty<TProperty>(inner, () => condition(this.entity));

            this.properties.Add(newProperty);

            return newProperty;
        }

        /// <summary>
        /// <inheritdoc cref="ValidationBuilder{TEntity}.For{TProperty}(Expression{Func{TEntity, TProperty}}, string)"
        ///             path="/summary"/>
        /// </summary>
        /// <typeparam name="TProperty"><inheritdoc cref="ValidationBuilder{TEntity}.For{TProperty}(Expression{Func{TEntity, TProperty}}, string)" 
        ///                                         path="/typeparam"/></typeparam>
        /// <param name="expression">
        ///     <inheritdoc cref="ValidationBuilder{TEntity}.For{TProperty}(Expression{Func{TEntity, TProperty}}, string)" 
        ///                 path="/param[@name='expression']"/></param>
        /// <returns><inheritdoc cref="IValidatableProperty" path="/summary"/></returns>
        public IValidatableProperty<TProperty> For<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            this.Validate(expression);

            return this.For(expression, EntitiesHelper.GetPropertyName(expression));
        }

        /// <summary>
        /// Permite configurar las validaciones para la propiedad especificada
        /// </summary>
        /// <typeparam name="TProperty">Propiedad</typeparam>
        /// <param name="expression">
        ///     <inheritdoc cref="ValidatableProperty{TEntity, TProperty}
        ///                     .ValidatableProperty(TEntity, Expression{Func{TEntity, TProperty}}, string)"
        ///                 path="/param[@name='expression']"/></param>
        /// <param name="name"><inheritdoc cref="IValidatableProperty.Name" path="/summary"/></param>
        /// <returns></returns>
        public IValidatableProperty<TProperty> For<TProperty>(Expression<Func<TEntity, TProperty>> expression, string name)
        {
            ValidatableProperty<TEntity, TProperty> property = this.CreateProperty(expression, name);
            this.properties.Add(property);
            return property;
        }

        /// <summary>
        /// Incluye las validaciones en el resultado final.
        /// </summary>
        /// <param name="result"><inheritdoc cref="ValidationResult" path="/summary"/></param>
        public void Include(IValidationResult result)
        {
            this.result.AddErrors(result);
        }

        /// <summary>
        /// Construye un <see cref="ValidationResult"/> en base a la validacion de las propiedades.
        /// </summary>
        /// <returns><inheritdoc cref="ValidationResult" path="/summary"/></returns>
        public ValidationResult Build()
        {
            this.properties.ForEach(pv => pv.Validate(this.result));
            return this.result;
        }
        #endregion

        #region Private Methods
        private void Validate<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            if(expression?.Body == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if(expression.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new ArgumentException("La expresión no es válida");
            }
        }

        private ValidatableProperty<TEntity, TProperty> CreateProperty<TProperty>(
            Expression<Func<TEntity, TProperty>> expression, string name)
        {
            this.Validate(expression);

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var property = new ValidatableProperty<TEntity, TProperty>(this.entity, expression, name);

            return property;
        }
        #endregion
    }
}
