using Business.Abstractions.Entities.Criterias;
using Cross.Abstractions;
using Cross.Entities.Validations.Properties.Extensions;
using Cross.Entities.Validations;
using System.ComponentModel;

namespace Business.Entities.Criterias
{
    public class PlayValidatable : ChangeValidatable, IPlayCriteria
    {
        #region Properties
        /// <inheritdoc cref="IPlayCriteria.MediaId"/>
        [DisplayName("Id de Medio")]
        public int? MediaId { get; set; }
        #endregion

        #region Methods
        /// <inheritdoc cref="IValidatable.Validate"/>
        public override IValidationResult Validate()
        {
            var result = base.Validate();

            var builder = this.GetValidationBuilder();

            builder.Include(result);

            builder.For(e => e.MediaId)
                .SetIsGreaterOrEqualTo(1);

            result = builder.Build();

            return result;
        }
        #endregion
    }

    public class PlayCriteria : PlayValidatable, IMapFrom<IPlayCriteria> { }
}