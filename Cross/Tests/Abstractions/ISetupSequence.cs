using Moq.Language;
using System.Linq.Expressions;

namespace Cross.Tests.Abstractions
{
    public interface ISetupSequence<TInput, TOutput>
    {
        /// <inheritdoc cref="ISetupSequence{TOutput}.SetupSequence(Expression{Func{bool}})"/>
        ISetupSequentialResult<TOutput> SetupSequence(Expression<Func<TInput, bool>> match);
    }

    public interface ISetupSequence<TOutput>
    {
        /// <summary>
        /// Configura una secuencia de resultados a devolver 
        /// al coincidir el <paramref name="match"/>
        /// </summary>
        /// <param name="match">Condiciones indicadas</param>
        /// <returns></returns>
        ISetupSequentialResult<TOutput> SetupSequence(Expression<Func<bool>> match);
    }
}
