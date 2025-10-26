using Cross.Abstractions;
using Cross.Entities.Enums;
using Cross.Entities.Validations;
using Cross.Entities.Validations.Properties;
using Cross.Entities.Validations.Properties.Extensions;
using Resources.Abstractions.Entities.Parameters;
using System.ComponentModel;

namespace Resources.Entities.Parameters
{
    ///<inheritdoc cref="IGetByRadioParameter"/>
    public class GetByRadioValidatable : GetByNameValidatable
    {
        ///<inheritdoc cref="IGetByRadioParameter.Frequency"/>
        [DisplayName("Frecuencia")]
        public decimal? Frequency { get; set; }

        ///<inheritdoc cref="IGetByRadioParameter.Wave"/>
        [DisplayName("Banda")]
        public Wave Wave { get; set; }

        public override IValidationResult Validate()
        {
            var builder = this.GetValidationBuilder();

            builder.For(e => e.Name)
                .SetNotEmptyOrWhiteSpace();

            builder.For(e => e.Frequency,
                e => e.Name is null 
                  && e.Frequency is null).SetInvalid("No ha ingresado parametros de busqueda suficientes.");

            builder.For(e => e.Wave)
                .SetNotNull();


            return builder.Build();
        }
    }

    public class GetByRadioParameter : GetByRadioValidatable, IMapFrom<IGetByRadioParameter> { }
}
