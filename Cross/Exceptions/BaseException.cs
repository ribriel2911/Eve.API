namespace Cross.Exceptions
{
    /// <summary>
    /// Logica base de excepciones controladas
    /// </summary>
    public abstract class BaseException : Exception
    {
        #region Properties
        /// <summary>
        /// Metodo en el que ocurre el error
        /// </summary>
        public List<string> Tracker { get; }

        /// <summary>
        /// Descripcion del error
        /// </summary>
        public string DescriptionError { get; }

        ///<inheritdoc cref="Exception.Message"/>
        public override string Message => this.DescriptionError;
        #endregion

        #region Constructors
        /// <summary>
        /// <inheritdoc cref="BaseException(string, string, Exception)"
        ///             path="/summary"/>
        /// </summary>
        /// <param name="method"><inheritdoc cref="Method" path="/summary"/></param>
        /// <param name="descriptionError"><inheritdoc cref="DescriptionError" path="/summary"/></param>
        /// <param name="inner">Error que genera esta excepcion</param>
        protected BaseException(string method, string descriptionError, string inner)
            : this(method, descriptionError, new Exception(inner)) { }

        /// <summary>
        /// <inheritdoc cref="BaseException(string, string, Exception)"
        ///             path="/summary"/>
        /// </summary>
        /// <param name="method"><inheritdoc cref="Method" path="/summary"/></param>
        /// <param name="descriptionError"><inheritdoc cref="DescriptionError" path="/summary"/></param>
        protected BaseException(string method, string descriptionError)
            : this(method, descriptionError, (Exception)null) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="method"><inheritdoc cref="Method" path="/summary"/></param>
        /// <param name="descriptionError"><inheritdoc cref="DescriptionError" path="/summary"/></param>
        /// <param name="inner"><see cref="Exception"/> que genera esta excepcion</param>
        protected BaseException(string method, string descriptionError, Exception inner)
            : base(descriptionError, inner)
        {
            this.Tracker = new List<string> { method };
            this.DescriptionError = descriptionError;
        }
        #endregion
    }
}
