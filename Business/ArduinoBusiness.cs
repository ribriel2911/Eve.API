using AutoMapper;
using Business.Abstractions;
using Microsoft.Extensions.Logging;
using Resources.Abstractions;

namespace Business
{
    /// <summary>
    /// Logica para componentes logicos arduino
    /// </summary>
    internal class ArduinoBusiness : SwitchableArduinoBaseBusiness
    {
        #region Constructor
        /// <inheritdoc cref="SwitchableArduinoBaseBusiness.SwitchableArduinoBaseBusiness(IArduinoResourceAccess, IArduinoInstructionsResourceAccess, string)"/>
        internal ArduinoBusiness(
            IMapper mapper,
            IArduinoResourceAccess arduinoAcceess,
            IArduinoInstructionsResourceAccess instructionsResourceAccess,
            string name)
        : base(mapper, arduinoAcceess, instructionsResourceAccess, name) { }
        #endregion

        #region Public Methods
        /// <inheritdoc cref="ISwitchableBusiness.GetStateAsync()"/>
        public override async Task<bool> GetStateAsync()
        {
            return await TryAsync(async () =>
            {
                return await GetAndExecuteAsync($"GetState{Name}");

            }, nameof(GetStateAsync));
        }
        #endregion
    }
}
