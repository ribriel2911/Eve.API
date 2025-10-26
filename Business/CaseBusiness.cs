using AutoMapper;
using Business.Abstractions;
using Resources.Abstractions;

namespace Business
{
    ///<inheritdoc cref="ICaseBusiness"/>
    public class CaseBusiness : SwitchableArduinoBaseBusiness, ICaseBusiness
    {
        #region Fields
        private readonly ArduinoBusiness LightsBusiness;
        private readonly ArduinoBusiness FansBusiness;
        private readonly ArduinoBusiness ScreenBusiness;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="arduinoAcceess"><inheritdoc cref="IArduinoResourceAccess" path="/summary"/></param>
        /// <param name="instructionsResourceAccess"><inheritdoc cref="IArduinoInstructionsResourceAccess" path="/summary"/></param>
        public CaseBusiness(
            IMapper mapper,
            IArduinoResourceAccess arduinoAcceess,
            IArduinoInstructionsResourceAccess instructionsResourceAccess)
        : base(mapper, arduinoAcceess, instructionsResourceAccess)
        {
            LightsBusiness = new ArduinoBusiness(mapper, arduinoAcceess, instructionsResourceAccess, "Lights");
            FansBusiness = new ArduinoBusiness(mapper, arduinoAcceess, instructionsResourceAccess, "Fans");
            ScreenBusiness = new ArduinoBusiness(mapper, arduinoAcceess, instructionsResourceAccess, "Screen");
        }
        #endregion

        #region Public Methods
        /// <inheritdoc cref="ISwitchableBusiness.GetStateAsync"/>
        public override async Task<bool> GetStateAsync()
        {
            return await TryAsync(async () =>
            {
                var result = await ArduinoAccess.GetStatesAsync();

                return result.Any(state => state);

            }, nameof(GetStateAsync));
        }

        ///<inheritdoc cref="ICaseBusiness.GetStateFansAsync"/>
        public async Task<bool> GetStateFansAsync()
        {
            return await TryAsync(FansBusiness.GetStateAsync, nameof(GetStateFansAsync));
        }

        ///<inheritdoc cref="ICaseBusiness.TurnOnFansAsync"/>
        public async Task<bool> TurnOnFansAsync()
        {
            return await TryAsync(FansBusiness.TurnOnAsync, nameof(TurnOnFansAsync));
        }

        ///<inheritdoc cref="ICaseBusiness.TurnOffFansAsync"/>
        public async Task<bool> TurnOffFansAsync()
        {
            return await TryAsync(FansBusiness.TurnOffAsync, nameof(TurnOffFansAsync));
        }

        ///<inheritdoc cref="ICaseBusiness.GetStateLightsAsync"/>
        public async Task<bool> GetStateLightsAsync()
        {
            return await TryAsync(LightsBusiness.GetStateAsync, nameof(GetStateLightsAsync));
        }

        ///<inheritdoc cref="ICaseBusiness.TurnOnLightsAsync"/>
        public async Task<bool> TurnOnLightsAsync()
        {
            return await TryAsync(LightsBusiness.TurnOnAsync, nameof(TurnOnLightsAsync));
        }

        ///<inheritdoc cref="ICaseBusiness.TurnOffLightsAsync"/>
        public async Task<bool> TurnOffLightsAsync()
        {
            return await TryAsync(LightsBusiness.TurnOffAsync, nameof(TurnOffLightsAsync));
        }

        ///<inheritdoc cref="ICaseBusiness.GetStateScreenAsync"/>
        public async Task<bool> GetStateScreenAsync()
        {
            return await TryAsync(ScreenBusiness.GetStateAsync, nameof(GetStateScreenAsync));
        }

        ///<inheritdoc cref="ICaseBusiness.TurnOnScreenAsync"/>
        public async Task<bool> TurnOnScreenAsync()
        {
            return await TryAsync(ScreenBusiness.TurnOnAsync, nameof(TurnOnScreenAsync));
        }

        ///<inheritdoc cref="ICaseBusiness.TurnOffScreenAsync"/>
        public async Task<bool> TurnOffScreenAsync()
        {
            return await TryAsync(ScreenBusiness.TurnOffAsync, nameof(TurnOnScreenAsync));
        }
        #endregion
    }
}
