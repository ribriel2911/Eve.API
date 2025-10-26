using Cross.Tests.Abstractions;

namespace Cross.Tests.Extensions
{
    /// <summary>
    /// Extensiones de verificacion
    /// </summary>
    public static class VerifyExtensions
    {
        /// <inheritdoc cref="IVerify{TInput}.Verify(System.Linq.Expressions.Expression{Func{TInput, bool}}, int)"/>
        public static void Verify<TInput>(this IVerify<TInput> setup, int times)
        {
            setup.Verify(c => true, times);
        }

        public static void Verify(this IVerify setup, int times)
        {
            setup.Verify(() => true, times);
        }
    }
}
