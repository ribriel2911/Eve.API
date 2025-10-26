namespace Cross.Exceptions
{
    /// <summary>
    /// Excepcion de validacion
    /// </summary>
    public class ValidationException : BaseException
    {
        #region Constants
        private const string errorDefault = "@ERROR_VALIDATION";
        #endregion

        #region Constructors
        /// <inheritdoc cref="BaseException(string, string, string)"/>
        public ValidationException(string method, string inner)
            : base(method, errorDefault, inner) { }

        /// <inheritdoc cref="BaseException(string, string, Exception)"/>
        public ValidationException(string method, Exception inner)
            : base(method, errorDefault, inner) { }
        #endregion
    }
}
