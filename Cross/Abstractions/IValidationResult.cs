namespace Cross.Abstractions
{
    /// <summary>
    /// Resultado de validacion
    /// </summary>
    public interface IValidationResult
    {
        #region Properties
        /// <summary>
        /// Errores de validacion
        /// </summary>
        IReadOnlyCollection<string> Errors { get; }

        /// <summary>
        /// Determina si el resultado de la validacion fue exitoso
        /// </summary>
        bool IsValid { get; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Agrega un error
        /// </summary>
        /// <param name="error">Descripcion del error</param>
        public void AddError(string error);

        /// <summary>
        /// Agrega una coleccion de errores
        /// </summary>
        /// <param name="errors">Coleccion de errores a agregar</param>
        public void AddErrors(IEnumerable<string> errors);

        /// <summary>
        /// Agrega los errores de un <see cref="IValidationResult"/>
        /// </summary>
        /// <param name="result"><inheritdoc cref="IValidationResult" path="/summary"/></param>
        public void AddErrors(IValidationResult result);
        #endregion
    }
}
