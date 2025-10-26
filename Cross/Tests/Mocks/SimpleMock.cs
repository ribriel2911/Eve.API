using Cross.Tests.Abstractions;
using Moq;
using Moq.Language;
using Moq.Language.Flow;
using System.Linq.Expressions;

namespace Cross.Tests.Mocks
{
    /// <summary>
    /// Clase base para mocks.
    /// Permite crear mocks de <typeparamref name="TInterface"/> con varias funcionalidades expuestas
    /// </summary>
    /// <typeparam name="TInterface">Objeto</typeparam>
    public abstract class SimpleMock<TInterface> where TInterface : class
    {
        #region Properties
        /// <summary>
        /// Mock del objeto
        /// </summary>
        protected Mock<TInterface> Mock { get; }

        /// <summary>
        /// Instancia mockeada
        /// </summary>
        public TInterface Object => this.Mock.Object;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        protected SimpleMock() : this(new Mock<TInterface>()) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent"></param>
        protected SimpleMock(Mock<TInterface> parent)
        {
            this.Mock = parent;
        }
        #endregion
    }

    /// <summary>
    /// Clase base para mocks.
    /// Permite crear mocks de una funcionalidad especifica que recibe un <typeparamref name="TInput"/>
    /// </summary>
    /// <typeparam name="TInterface">Objeto</typeparam>
    /// <typeparam name="TInput">Parametro de entrada</typeparam>
    public abstract class SimpleMock<TInterface, TInput> : 
        SimpleMock<TInterface>, ISetupError<TInput>, IVerify<TInput>
        where TInterface : class
    {
        #region Fields
        private readonly Func<Expression<Func<TInput, bool>>, Expression<Action<TInterface>>> expression;
        private readonly Func<Expression<Func<TInput, bool>>, ISetup<TInterface>> setup;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="expression">Target</param>
        protected SimpleMock(
            Func<Expression<Func<TInput, bool>>, Expression<Action<TInterface>>> expression) :
            this(new Mock<TInterface>(), expression) { }
       
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="expression">Target</param>
        protected SimpleMock(
            Mock<TInterface> parent,
            Func<Expression<Func<TInput, bool>>, Expression<Action<TInterface>>> expression)
        {
            this.expression = expression;
            this.setup = c => this.Mock.Setup(this.expression(c));
        }
        #endregion

        #region Public Methods
        public void SetupError(Expression<Func<TInput, bool>> match, Exception ex)
        {
            this.setup(match).Throws(ex);
        }

        public void Verify(Expression<Func<TInput, bool>> match, int times)
        {
            this.Mock.Verify(this.expression(match), Times.Exactly(times));
        }
        #endregion
    }

    /// <summary>
    /// Clase base para mocks.
    /// Permite crear mocks de una funcionalidad especifica 
    /// que recibe un <typeparamref name="TInput"/>
    /// y retorna un <typeparamref name="TOutput"/>
    /// </summary>
    /// <typeparam name="TInterface">Objeto</typeparam>
    /// <typeparam name="TInput">Parametro de entrada</typeparam>
    /// <typeparam name="TOutput">Parametro de salida</typeparam>
    public abstract class SimpleMock<TInterface, TInput, TOutput> : 
        SimpleMock<TInterface>, ISetupError<TInput>, IVerify<TInput>, ISetupSequence<TInput, TOutput>
    where TInterface : class
    {
        #region Fields
        private readonly Func<Expression<Func<TInput, bool>>, Expression<Func<TInterface, TOutput>>> expression;
        private readonly Func<Expression<Func<TInput, bool>>, ISetup<TInterface, TOutput>> setup;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="expression">Target</param>
        protected SimpleMock(
            Func<Expression<Func<TInput, bool>>, Expression<Func<TInterface, TOutput>>> expression) :
            this(new Mock<TInterface>(), expression)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="expression">Target</param>
        protected SimpleMock(
            Mock<TInterface> parent,
            Func<Expression<Func<TInput, bool>>, Expression<Func<TInterface, TOutput>>> expression) : base(parent)
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
        /// <param name="output">Valor a devolver al invocar el mock</param>
        public void Setup(Expression<Func<TInput, bool>> match, TOutput output)
        {
            this.setup(match).Returns(output);
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

            foreach(var output in sequence)
            {
                setup.Returns(output);
            }
        }

        public ISetupSequentialResult<TOutput> SetupSequence(Expression<Func<TInput, bool>> match)
        {
            return this.Mock.SetupSequence(this.expression(match));
        }

        public void SetupError(Expression<Func<TInput, bool>> match, Exception ex)
        {
            this.setup(match).Throws(ex);
        }

        public void Verify(Expression<Func<TInput, bool>> match, int times)
        {
            this.Mock.Verify(this.expression(match), Times.Exactly(times));
        }


        #endregion
    }
}
