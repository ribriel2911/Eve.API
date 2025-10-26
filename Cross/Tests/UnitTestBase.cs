using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cross.Tests
{
    /// <summary>
    /// Clase base para tests unitarios sobre <typeparamref name="TObject"/>
    /// </summary>
    /// <typeparam name="TObject"><inheritdoc cref="Target" path="/summary"></inheritdoc>/></typeparam>
    public abstract class UnitTestBase<TObject> where TObject : class
    {
        #region Properties
        /// <summary>
        /// Objeto sobre el cual se realizaran los tests.
        /// </summary>
        protected TObject Target { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        protected UnitTestBase() { }
        #endregion

        #region Initialize
        /// <summary>
        /// Metodo a ejecutarse antes de cada prueba para asignar
        /// y configurar los recursos necesarios para la misma.
        /// </summary>
        public abstract void Init();
        #endregion

        #region Protected Methods
        /// <inheritdoc cref="Assert.ThrowsExceptionAsync{T}(Func{Task})"/>
        protected Task<TException> AssertThrowsAsync<TException>(Func<Task> action) 
            where TException : Exception 
            => Assert.ThrowsExceptionAsync<TException>(action);

        /// <inheritdoc cref="Assert.ThrowsException{TException}(Action)"/>
        protected TException AssertThrows<TException>(Action action)
            where TException : Exception
            => Assert.ThrowsException<TException>(action);
        #endregion
    }
}
