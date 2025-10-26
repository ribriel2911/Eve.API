using Business.Abstractions.Entities.Criterias;
using Cross.Abstractions;
using Cross.Entities.Validations;
using Cross.Entities.Validations.Properties.Extensions;
using System.ComponentModel;

namespace Business.Entities.Criterias
{
    /// <inheritdoc cref="IVolumeCriteria"/>
    public class VolumeValidatable : IValidatable, IVolumeCriteria
    {
        #region Properties
        /// <inheritdoc cref="IVolumeCriteria.Volume"/>
        [DisplayName("Volumen")]
        public int Volume { get; set; }
        #endregion

        #region Methods
        /// <inheritdoc cref="IValidatable.Validate"/>
        public virtual IValidationResult Validate()
        {
            var builder = this.GetValidationBuilder();

            builder.For(e => e.Volume)
                .SetIsGreaterOrEqualTo(0)
                .SetIsLessOrEqualTo(100);

            var result = builder.Build();

            return result;
        }
        #endregion
    }

    /// <inheritdoc cref="IVolumeCriteria"/>
    public class VolumeCriteria : VolumeValidatable, IMapFrom<IVolumeCriteria> { }
}
