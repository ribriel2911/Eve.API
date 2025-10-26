using Cross.Entities.Validations;
using Cross.Entities.Validations.Properties.Extensions;
using Cross.Abstractions;
using Resources.Entities.Identifiers;
using Resources.Abstractions.Entities.Parameters;
using System.ComponentModel;

namespace Resources.Entities.Parameters
{
    /// <inheritdoc cref="IExecuteParameter"/>
    public class ExecuteValidatable : IExecuteParameter, IValidatable
    {
        #region Properties
        /// <inheritdoc cref="IExecuteParameter.Code"/>
        [DisplayName("Codigo de instruccion")]
        public string Code { get; set; }
        #endregion

        #region Methods
        ///<inheritdoc cref="IValidatable.Validate"/>
        public IValidationResult Validate()
        {
            var builder = this.GetValidationBuilder();

            builder.For(e => e.Code)
                .SetNotNullOrWhiteSpace()
                .SetIsNumeric()
                .SetNotIn(new[] { Arduino.ResetInstruction, Arduino.GetStatesInstruction });

            var result = builder.Build();

            return result;
        }
        #endregion
    }

    /// <inheritdoc cref="IExecuteParameter"/>
    public class ExecuteParameter : ExecuteValidatable, IMapFrom<IExecuteParameter> { }
}
