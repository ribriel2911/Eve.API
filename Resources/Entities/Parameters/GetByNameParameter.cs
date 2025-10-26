using Cross.Entities.Validations;
using Cross.Entities.Validations.Properties.Extensions;
using Cross.Abstractions;
using Resources.Abstractions.Entities.Parameters;
using System.ComponentModel;

namespace Resources.Entities.Parameters
{
    /// <inheritdoc cref="IGetByNameParameter"/>
    public class GetByNameValidatable : IGetByNameParameter, IValidatable
    {
        #region Properties
        /// <inheritdoc cref="IGetByNameParameter.Name"/>
        [DisplayName("Nombre del recurso")]
        public string Name { get; set; }
        #endregion

        #region Methods
        ///<inheritdoc cref="IValidatable.Validate"/>
        public virtual IValidationResult Validate()
        {
            var builder = this.GetValidationBuilder();

            builder.For(e => e.Name)
                .SetNotEmptyOrWhiteSpace()
                .SetNotNull();           

            return builder.Build();
        }
        #endregion
    }

    /// <inheritdoc cref="IGetByNameParameter"/>
    public class GetByNameParameter : GetByNameValidatable, IMapFrom<IGetByNameParameter> { }
}
