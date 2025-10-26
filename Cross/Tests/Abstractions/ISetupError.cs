using System.Linq.Expressions;

namespace Cross.Tests.Abstractions
{
    public interface ISetupError<TInput>
    {
        /// <inheritdoc cref="ISetupError.SetupError(Expression{Func{bool}}, Exception)"/>
        void SetupError(Expression<Func<TInput, bool>> match, Exception error);
    }

    public interface ISetupError
    {
        /// <summary>
        /// Establece el <paramref name="error"/>
        /// al coincidir el <paramref name="match"/>
        /// </summary>
        /// <param name="match"></param>
        /// <param name="error">Error a devolver</param>
        void SetupError(Expression<Func<bool>> match, Exception error);
    }
}
