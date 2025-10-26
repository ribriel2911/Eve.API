using Business.Abstractions.Entities.Criterias;
using Cross.Abstractions;
using RepeatModes = Cross.Entities.Enums.RepeatMode;
using Cross.Entities.Validations;
using Cross.Entities.Validations.Properties;
using System.ComponentModel;
using Cross.Entities.Validations.Properties.Extensions;

namespace Business.Entities.Criterias
{
    ///<inheritdoc cref="IChangeCriteria"/>
    public class ChangeValidatable : VolumeValidatable, IChangeCriteria
    {
        #region Properties
        /// <inheritdoc cref="IChangeCriteria.Aleatory"/>
        public bool Aleatory { get; set; }

        /// <inheritdoc cref="IChangeCriteria.RepeatMode"/>
        [DisplayName("Modo de Repeticion")]
        public int RepeatMode { get; set; }
        #endregion

        #region Methods
        /// <inheritdoc cref="IValidatable.Validate"/>
        public override IValidationResult Validate()
        {
            var result = base.Validate();

            var builder = this.GetValidationBuilder();

            builder.Include(result);

            builder.For(e => e.RepeatMode)
                .SetIsDefined<int, RepeatModes>();

            result = builder.Build();

            return result;
        }
        #endregion
    }

    ///<inheritdoc cref="IChangeCriteria"/>
    public class ChangeCriteria : ChangeValidatable, IMapFrom<IChangeCriteria> { }
}
