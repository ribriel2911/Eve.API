using Cross.Abstractions;

namespace Cross.Entities.Validations
{
    /// <inheritdoc cref="IValidationResult"/>
    public class ValidationResult : IValidationResult
    {
        #region Fields
        private readonly List<string> errors;
        #endregion

        #region Properties
        /// <inheritdoc cref="IValidationResult.Errors"/>
        public IReadOnlyCollection<string> Errors => errors.AsReadOnly();

        /// <inheritdoc cref="IValidationResult.IsValid"/>
        public bool IsValid => !errors.Any();
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public ValidationResult()
        {
            errors = new List<string>();
        }
        #endregion

        #region Public Methods
        /// <inheritdoc cref="IValidationResult.AddError(string)"/>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddError(string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                throw new ArgumentNullException(nameof(error));
            }

            errors.Add(error);
        }

        /// <inheritdoc cref="IValidationResult.AddErrors(IEnumerable{string})"/>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddErrors(IEnumerable<string> errors)
        {
            if (errors == null || errors.Any(e => string.IsNullOrEmpty(e)))
            {
                throw new ArgumentNullException(nameof(errors));
            }

            this.errors.AddRange(errors);
        }

        /// <inheritdoc cref="IValidationResult.AddErrors(IValidationResult)"/>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddErrors(IValidationResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            AddErrors(result.Errors);
        }
        #endregion
    }
}
