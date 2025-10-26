using System.Linq.Expressions;

namespace Cross.Tests.Abstractions
{
    public interface IVerify<TInput>
    {

        /// <inheritdoc cref="IVerify.Verify(Expression{Func{bool}}, int)"/>
        void Verify(Expression<Func<TInput, bool>> match, int times);
    }

    public interface IVerify
    {
        /// <summary>
        /// Verifica que el mock haya sido invocado exactamente <paramref name="times"/> veces
        /// </summary>
        /// <param name="match"></param>
        /// <param name="times"></param>
        void Verify(Expression<Func<bool>> match, int times);
    }
}
