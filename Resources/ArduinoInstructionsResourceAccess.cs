using AutoMapper;
using Resources.Abstractions;
using Resources.Abstractions.Entities.Parameters;
using Resources.Abstractions.Entities.Samples;
using Resources.Entities.ConfigSections;
using Resources.Entities.Parameters;
using Cross.Logic;

namespace Resources
{
    /// <inheritdoc cref="IArduinoInstructionsResourceAccess"/>
    public class ArduinoInstructionsResourceAccess : BaseConfigurableItemResourceAccess<ArduinoConfigSection>, IArduinoInstructionsResourceAccess
    {
        #region Constructors
        /// <inheritdoc cref="BaseEntityManager.BaseEntityManager(IMapper)"/>
        public ArduinoInstructionsResourceAccess(IMapper mapper) : base(mapper) { }
        #endregion

        #region Public Methods
        /// <inheritdoc cref="IArduinoInstructionsResourceAccess.GetInstructionByNameAsync(IGetByNameParameter)"/>
        public async Task<IArduinoInstructionSample> GetInstructionByNameAsync(IGetByNameParameter param)
        {
            this.Validate<IGetByNameParameter, GetByNameParameter>(param);

            var result = await this.GetBySectionAsync((section) =>
            {
                var instruction = section.Instructions.First(i => i.Name == param.Name);
                return instruction;
            });

            return result;
        }

        /// <inheritdoc cref="IArduinoInstructionsResourceAccess.GetInstructionsAsync()"/>
        public async Task<IEnumerable<IArduinoInstructionSample>> GetInstructionsAsync()
        {
            var result = await this.GetBySectionAsync((section) =>
            {
                var ordered = section.Instructions.OrderBy(x => x.Code);
                return ordered;
            });

            return result;
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
