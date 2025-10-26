using Cross.Abstractions;
using Cross.Entities.Validations.Properties;
using Cross.Entities.Helpers;
using Cross.Tests.Extensions;
using System.Linq.Expressions;
using System.Reflection;

namespace Cross.Tests
{
    /// <summary>
    /// Clase base para tests unitarios sobre una entidad 
    /// <typeparamref name="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity"><inheritdoc cref="IValidatable" path="/summary"/></typeparam>
    public abstract class EntityTestBase<TEntity> : UnitTestBase<TEntity>
        where TEntity : class, IValidatable, new()
    {
        #region Public Methods
        /// <summary>
        /// Test de caso optimo
        /// </summary>
        public abstract void Ok();
        #endregion

        #region Protected Methods
        /// <inheritdoc cref="UnitTestBase{T}.Init"/>
        protected void Test_Initializer() => this.Target = this.GetTarget();

        /// <summary>
        /// Ejecuta la validacion de <inheritdoc cref="IValidatable"/>
        /// </summary>
        /// <returns><inheritdoc cref="ValidationResult" path="/summary"/></returns>
        protected IValidationResult Validate() => this.Target.Validate();

        /// <summary>
        /// Genera una nueva instancia
        /// </summary>
        /// <returns><inheritdoc cref="IValidatable" path="/summary"/></returns>
        protected virtual TEntity GetTarget() => new TEntity();

        protected void TestOk()
        {
            var result = this.Validate();

            result.AssertSuccess();
        }

        protected void TestOk<TProperty>(Expression<Func<TEntity, TProperty>> expression, TProperty value)
        {
            this.SetPropertyValue(expression, value);

            this.TestOk();
        }

        protected void TestFault(string faultMessage)
        {
            var result = this.Validate();

            result.AssertFailure(faultMessage);
        }

        protected void TestFormatableFault(string formatableFaultMessage, string propertyName)
            => this.TestFault(string.Format(formatableFaultMessage, propertyName));

        protected void TestFormatableFault<TProperty>(string formatableFaultMessage, Expression<Func<TEntity, TProperty>> expression)
            => this.TestFormatableFault(formatableFaultMessage, EntitiesHelper.GetPropertyName(expression));

        protected void TestFormatableFault<TProperty>(string formatableFaultMessage, Expression<Func<TEntity, TProperty>> expression, TProperty value)
        {
            this.SetPropertyValue(expression, value);

            this.TestFormatableFault(formatableFaultMessage, expression);
        }
        protected void TestInvalid(string propertyName)
            => this.TestFormatableFault(ValidationMessages.INVALID_MESSAGE, propertyName);

        protected void TestInvalid<TProperty>(Expression<Func<TEntity, TProperty>> exp)
            => this.TestFormatableFault(ValidationMessages.INVALID_MESSAGE, exp);

        protected void TestInvalid<TProperty>(Expression<Func<TEntity, TProperty>> expression, TProperty value)
        {
            this.SetPropertyValue(expression, value);

            this.TestInvalid(expression);
        }

        protected void TestInvalidFemale(string propertyName)
            => this.TestFormatableFault(ValidationMessages.INVALID_MESSAGE_FEMALE, propertyName);

        protected void TestInvalidFemale<TProperty>(Expression<Func<TEntity, TProperty>> expression)
            => this.TestFormatableFault(ValidationMessages.INVALID_MESSAGE_FEMALE, expression);

        protected void TestNullOrEmpty(string propertyName)
            => this.TestFormatableFault(ValidationMessages.EMPTY_MESSAGE, propertyName);

        protected void TestNullOrEmpty<TProperty>(Expression<Func<TEntity, TProperty>> expression)
            => this.TestFormatableFault(ValidationMessages.EMPTY_MESSAGE, expression);

        protected void TestNull<TProperty>(Expression<Func<TEntity, TProperty>> expression)
            where TProperty : class
        {
            this.SetPropertyValue(expression, null);

            this.TestNullOrEmpty(expression);
        }

        protected void TestEmptyString(Expression<Func<TEntity, string>> expression)
        {
            this.SetPropertyValue(expression, string.Empty);

            this.TestNullOrEmpty(expression);
        }

        protected void TestEmptyWhiteSpaceString(Expression<Func<TEntity, string>> expression)
        {
            this.SetPropertyValue(expression, " ");

            this.TestNullOrEmpty(expression);
        }
        #endregion

        private void SetPropertyValue<TProperty>(Expression<Func<TEntity, TProperty>> expression, TProperty nuevoValor)
        {
            if (expression.Body is MemberExpression miembro)
            {
                var propiedadInfo = miembro.Member as PropertyInfo;
                if (propiedadInfo != null)
                {
                    propiedadInfo.SetValue(Target, nuevoValor);
                }
            }
        }

    }
}
