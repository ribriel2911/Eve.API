namespace Cross.Exceptions
{
    public class BusinessException : BaseException
    {
        #region Constants
        private const string errorDefault = "@ERROR_BUSINESS";
        #endregion

        #region Constructors
        /// <inheritdoc cref="BaseException(string, string)"/>
        public BusinessException(string method)
            : base(method, errorDefault) 
        { }

        /// <inheritdoc cref="BaseException(string, string)"/>
        public BusinessException(string method, string descriptionError)
            : base(method, descriptionError)
        { }

        /// <inheritdoc cref="BaseException(string, string, string)"/>
        public BusinessException(string method, string descriptionError, string inner)
            : base(method, descriptionError, inner)
        { }

        /// <inheritdoc cref="BaseException(string, string, Exception)"/>
        public BusinessException(string method, string descriptionError, Exception inner)
            : base(method, descriptionError, inner)
        { }

        /// <inheritdoc cref="BaseException(string, string, Exception)"/>
        public BusinessException(string method, Exception inner)
            : base(method, errorDefault, inner)
        { }
        #endregion
    }
}
