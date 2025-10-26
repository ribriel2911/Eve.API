using Cross.Tests.Abstractions;
using Moq;
using Moq.Language;
using Moq.Language.Flow;
using System.Linq.Expressions;
using System.Text.RegularExpressions;


namespace Cross.Tests.Mocks
{
    /// <summary>
    /// Clase base para mocks.
    /// Permite crear un mock de una funcionalidad asincronica de <typeparamref name="TInterface"/>
    /// que recibe un <typeparamref name="TInput"/>
    /// </summary>
    /// <typeparam name="TInterface">Objeto</typeparam>
    /// <typeparam name="TInput">Parametro de entrada</typeparam>
    public abstract class AsyncSimpleMock<TInterface, TInput> : 
        SimpleMock<TInterface>, ISetupError<TInput>, IVerify<TInput>, ISetupSequence<TInput, Task>
        where TInterface : class
    {
        #region Fields
        private readonly Func<Expression<Func<TInput, bool>>, Expression<Func<TInterface, Task>>> expression;
        private readonly Func<Expression<Func<TInput, bool>>, ISetup<TInterface, Task>> setup;
        #endregion

        #region Constructors
        protected AsyncSimpleMock(Func<Expression<Func<TInput, bool>>, Expression<Func<TInterface, Task>>> expression)
            : this(new Mock<TInterface>(), expression){ }

        protected AsyncSimpleMock(
            Mock<TInterface> parent,
            Func<Expression<Func<TInput, bool>>, Expression<Func<TInterface, Task>>> expression) : base(parent)
        {
            this.expression = expression;
            this.setup = c => this.Mock.Setup(this.expression(c));
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Establece la salida del mock como una <seealso cref="Task.CompletedTask"/>
        /// </summary>
        public void Setup()
        {
            this.Setup(c => true);
        }

        /// <summary>
        /// Establece la salida del mock como una <seealso cref="Task.CompletedTask"/>
        /// al coincidir el <paramref name="match"/>
        /// </summary>
        /// <param name="match">Condiciones indicadas</param>
        public void Setup(Expression<Func<TInput, bool>> match)
        {
            this.setup(match).Returns(Task.CompletedTask);
        }

        public void SetupError(Expression<Func<TInput, bool>> match, Exception ex)
        {
            this.setup(match).Throws(ex);
        }

        public ISetupSequentialResult<Task> SetupSequence(Expression<Func<TInput, bool>> match)
        {
            return this.Mock.SetupSequence(this.expression(match));
        }

        public void Verify(Expression<Func<TInput, bool>> match, int times)
        {
            this.Mock.Verify(this.expression(match), Times.Exactly(times));
        }
        #endregion
    }

    /// <summary>
    /// Clase base para mocks.
    /// Permite crear un mock de una funcionalidad asincronica de <typeparamref name="TInterface"/>
    /// que recibe un <typeparamref name="TInput"/>
    /// y retorna un <typeparamref name="TOutput"/>
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    /// <typeparam name="TInput">Parametro de entrada</typeparam>
    /// <typeparam name="TOutput">Parametro de salida</typeparam>
    public abstract class AsyncSimpleMock<TInterface, TInput, TOutput> :
        SimpleMock<TInterface>, ISetupError<TInput>, IVerify<TInput>, ISetupSequence<TInput, Task<TOutput>>
        where TInterface : class
    {
        #region Fields
        private readonly Func<Expression<Func<TInput, bool>>, Expression<Func<TInterface, Task<TOutput>>>> expression;
        private readonly Func<Expression<Func<TInput, bool>>, ISetup<TInterface, Task<TOutput>>> setup;
        #endregion

        #region Constructors
        protected AsyncSimpleMock(Func<Expression<Func<TInput, bool>>, Expression<Func<TInterface, Task<TOutput>>>> expression)
            : this(new Mock<TInterface>(), expression) { }

        protected AsyncSimpleMock(
            Mock<TInterface> parent,
            Func<Expression<Func<TInput, bool>>, Expression<Func<TInterface, Task<TOutput>>>> expression) : base(parent)
        {
            this.expression = expression;
            this.setup = c => this.Mock.Setup(this.expression(c));
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Establece el <paramref name="output"/> 
        /// </summary>
        /// <param name="output">Valor a devolver al invocar el mock</param>
        public void Setup(TOutput output)
        {
            this.Setup(c => true, output);
        }

        /// <summary>
        /// <inheritdoc cref="Setup(TOutput)"/> 
        /// al coincidir el <paramref name="match"/>
        /// </summary>
        /// <param name="match">Condiciones indicadas</param>
        /// <param name="output"><inheritdoc cref="Setup(TOutput)" path="/param[@name='output']"/></param>
        public void Setup(Expression<Func<TInput, bool>> match, TOutput output)
        {
            this.setup(match).ReturnsAsync(output);
        }

        /// <summary>
        /// <inheritdoc cref="Setup(TOutput)"/> 
        /// en base a <paramref name="func"/>
        /// </summary>
        /// <param name="func">
        ///     Funcion que devuelve <typeparamref name="TOutput"/> 
        ///     en base a <typeparamref name="TInput"/>
        /// </param>
        public void Setup(Func<TInput, TOutput> func)
        {
            this.Setup(c => true, func);
        }

        /// <summary>
        /// <inheritdoc cref="Setup(TOutput)"/> 
        /// al coincidir el <paramref name="match"/>
        /// en base a <paramref name="func"/>
        /// </summary>
        /// <param name="match"><inheritdoc cref="Setup(Expression{Func{TInput, bool}}, TOutput)" path="/param[@name='match']"/></param>
        /// <param name="func"><inheritdoc cref="Setup(Func{TInput, TOutput})" path="/param[@name='func']"/></param>
        public void Setup(Expression<Func<TInput, bool>> match, Func<TInput, TOutput> func)
        {
            this.setup(match).ReturnsAsync(func);
        }

        /// <summary>
        /// Establece el <paramref name="sequence"/> 
        /// </summary>
        /// <param name="sequence">Secuencia de valores a devolver al invocar el mock</param>
        public void SetupSequence(IEnumerable<TOutput> sequence)
        {
            this.SetupSequence(c => true, sequence);
        }

        /// <summary>
        /// <inheritdoc cref="SetupSequence(IEnumerable{TOutput})"/> 
        /// al coincidir el <paramref name="match"/>
        /// </summary>
        /// <param name="match">Condiciones indicadas</param>
        /// <param name="sequence">Secuencia de valores a devolver al invocar el mock</param>
        public void SetupSequence(Expression<Func<TInput, bool>> match, IEnumerable<TOutput> sequence)
        {
            var setup = this.Mock.SetupSequence(this.expression(match));

            foreach (var output in sequence)
            {
                setup.ReturnsAsync(output);
            }
        }

        public void SetupError(Expression<Func<TInput, bool>> match, Exception ex)
        {
            this.setup(match).Throws(ex);
        }

        public ISetupSequentialResult<Task<TOutput>> SetupSequence(Expression<Func<TInput, bool>> match)
        {
            return this.Mock.SetupSequence(this.expression(match));
        }

        public void Verify(Expression<Func<TInput, bool>> match, int times)
        {
            this.Mock.Verify(this.expression(match), Times.Exactly(times));
        }
        #endregion
    }

    /// <summary>
    /// Clase base para mocks.
    /// Permite crear un mock de una funcionalidad asincronica de <typeparamref name="TInterface"/>
    /// que retorna un <typeparamref name="TOutput"/>
    /// </summary>
    /// <typeparam name="TInterface">Objeto</typeparam>
    /// <typeparam name="TOutput">Parametro de salida</typeparam>
    public abstract class AsyncSimpleOutputMock<TInterface, TOutput> :
        SimpleMock<TInterface>, ISetupError, IVerify, ISetupSequence<Task<TOutput>>
        where TInterface : class
    {
        #region Fields
        private readonly Func<Expression<Func<bool>>, Expression<Func<TInterface, Task<TOutput>>>> expression;
        private readonly Func<Expression<Func<bool>>, ISetup<TInterface, Task<TOutput>>> setup;
        #endregion

        #region Constructors
        protected AsyncSimpleOutputMock(Func<Expression<Func<bool>>, Expression<Func<TInterface, Task<TOutput>>>> expression)
            : this(new Mock<TInterface>(), expression) { }

        protected AsyncSimpleOutputMock(
            Mock<TInterface> parent,
            Func<Expression<Func<bool>>, Expression<Func<TInterface, Task<TOutput>>>> expression) : base(parent)
        {
            this.expression = expression;
            this.setup = c => this.Mock.Setup(this.expression(c));
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Establece el <paramref name="output"/> 
        /// </summary>
        /// <param name="output">Valor a devolver al invocar el mock</param>
        public void Setup(TOutput output)
        {
            this.Setup(() => true, output);
        }

        /// <summary>
        /// <inheritdoc cref="Setup(TOutput)"/> 
        /// al coincidir el <paramref name="match"/>
        /// </summary>
        /// <param name="match">Condiciones indicadas</param>
        /// <param name="output">Valor a devolver al invocar el mock</param>
        public void Setup(Expression<Func<bool>> match, TOutput output)
        {
            this.setup(match).ReturnsAsync(output);
        }

        /// <summary>
        /// Establece el <paramref name="sequence"/> 
        /// </summary>
        /// <param name="sequence">Secuencia de valores a devolver al invocar el mock</param>
        public void SetupSequence(IEnumerable<TOutput> sequence)
        {
            this.SetupSequence(() => true, sequence);
        }

        /// <summary>
        /// <inheritdoc cref="SetupSequence(IEnumerable{TOutput})"/> 
        /// al coincidir el <paramref name="match"/>
        /// </summary>
        /// <param name="match">Condiciones indicadas</param>
        /// <param name="sequence">Secuencia de valores a devolver al invocar el mock</param>
        public void SetupSequence(Expression<Func<bool>> match, IEnumerable<TOutput> sequence)
        {
            var setup = this.Mock.SetupSequence(this.expression(match));

            foreach (var output in sequence)
            {
                setup.ReturnsAsync(output);
            }
        }

        public void SetupError(Expression<Func<bool>> match, Exception ex)
        {
            this.setup(match).Throws(ex);
        }

        public ISetupSequentialResult<Task<TOutput>> SetupSequence(Expression<Func<bool>> match)
        {
            return this.Mock.SetupSequence(this.expression(match));
        }

        public void Verify(Expression<Func<bool>> match, int times)
        {
            this.Mock.Verify(this.expression(match), Times.Exactly(times));
        }
        #endregion
    }

    /// <summary>
    /// Clase base para mocks.
    /// Permite crear un mock de una funcionalidad asincronica de <typeparamref name="TInterface"/>
    /// sin retorno
    /// </summary>
    /// <typeparam name="TInterface">Objeto</typeparam>
    public abstract class AsyncSimpleMock<TInterface> :
        SimpleMock<TInterface>, ISetupError, IVerify, ISetupSequence<Task>
        where TInterface : class
    {
        #region Fields
        private readonly Func<Expression<Func<bool>>, Expression<Func<TInterface, Task>>> expression;
        private readonly Func<Expression<Func<bool>>, ISetup<TInterface, Task>> setup;
        #endregion

        #region Constructors
        protected AsyncSimpleMock(Func<Expression<Func<bool>>, Expression<Func<TInterface, Task>>> expression)
            : this(new Mock<TInterface>(), expression) { }

        protected AsyncSimpleMock(
            Mock<TInterface> parent,
            Func<Expression<Func<bool>>, Expression<Func<TInterface, Task>>> expression) : base(parent)
        {
            this.expression = expression;
            this.setup = c => this.Mock.Setup(this.expression(c));
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Establece el <paramref name="output"/> 
        /// </summary>
        /// <param name="output">Valor a devolver al invocar el mock</param>
        public void Setup()
        {
            this.Setup(() => true);
        }

        /// <summary>
        /// <inheritdoc cref="Setup(TOutput)"/> 
        /// al coincidir el <paramref name="match"/>
        /// </summary>
        /// <param name="match">Condiciones indicadas</param>
        /// <param name="output">Valor a devolver al invocar el mock</param>
        public void Setup(Expression<Func<bool>> match)
        {
            this.setup(match);
        }

        /// <summary>
        /// Establece el <paramref name="sequence"/> 
        /// </summary>
        /// <param name="sequence">Secuencia de valores a devolver al invocar el mock</param>
        public void SetupSequence()
        {
            this.SetupSequence(() => true);
        }

        /// <summary>
        /// <inheritdoc cref="SetupSequence(IEnumerable{TOutput})"/> 
        /// al coincidir el <paramref name="match"/>
        /// </summary>
        /// <param name="match">Condiciones indicadas</param>
        /// <param name="sequence">Secuencia de valores a devolver al invocar el mock</param>
        public void SetupSequence(Expression<Func<bool>> match)
        {
            var setup = this.Mock.SetupSequence(this.expression(match));
        }

        public void SetupError(Expression<Func<bool>> match, Exception ex)
        {
            this.setup(match).Throws(ex);
        }

        public void Verify(Expression<Func<bool>> match, int times)
        {
            this.Mock.Verify(this.expression(match), Times.Exactly(times));
        }

        ISetupSequentialResult<Task> ISetupSequence<Task>.SetupSequence(Expression<Func<bool>> match)
        {
            return this.Mock.SetupSequence(this.expression(match));
        }
        #endregion
    }
}
