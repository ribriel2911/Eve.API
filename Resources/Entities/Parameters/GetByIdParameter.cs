using Cross.Entities.Validations;
using Cross.Entities.Validations.Properties.Extensions;
using Cross.Abstractions;
using Resources.Abstractions.Entities.Parameters;

namespace Resources.Entities.Parameters
{
    /// <inheritdoc cref="IGetByIdParameter"/>
    public class GetByIdValidatable : IGetByIdParameter, IValidatable
    {
        #region Properties
        /// <inheritdoc cref="IGetByIdParameter.Id"/>
        public int Id { get; set; }
        #endregion

        #region Methods
        ///<inheritdoc cref="IValidatable.Validate"/>
        public virtual IValidationResult Validate()
        {
            var builder = this.GetValidationBuilder();

            builder.For(e => e.Id)
                .SetIsGreaterThan(0);

            return builder.Build();
        }
        #endregion
    }

    /// <inheritdoc cref="IGetByIdParameter"/>
    public class GetByIdParameter : GetByIdValidatable, IMapFrom<IGetByIdParameter> { }
}
