using Cross.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cross.Tests.Extensions
{
    /// <summary>
    /// Extensiones de validadores
    /// </summary>
    public static class ValidationAssertExtensions
    {
        /// <summary>
        /// Valida que el <inheritdoc cref="ValidationResult"/> 
        /// no contenga errores
        /// </summary>
        public static void AssertSuccess(this IValidationResult result)
        {
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(0, result.Errors.Count);
        }

        /// <summary>
        /// Valida que el <inheritdoc cref="ValidationResult"/> 
        /// contenga el <inheritdoc cref="AssertFailure(ValidationResult, string)" path="/param[@name='error']"/>
        /// </summary>
        /// <param name="error">Error esperado</param>
        public static void AssertFailure(this IValidationResult result, string error)
        {
            result.AssertFailure(new[] { error });
        }

        /// <summary>
        /// Valida que el <inheritdoc cref="ValidationResult"/> 
        /// contenga los <inheritdoc cref="AssertFailure(ValidationResult, string[])" path="/param[@name='errors']"/>
        /// </summary>
        /// <param name="errors">Errores esperados</param>
        public static void AssertFailure(this IValidationResult result, string[] errors)
        {
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsValid);
            CollectionAssert.AreEquivalent(errors, result.Errors.ToArray());
        }
    }
}
