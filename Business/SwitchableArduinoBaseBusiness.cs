using Resources.Abstractions;
using Business.Entities.Parameters;
using Business.Abstractions;
using AutoMapper;

namespace Business
{
    /// <summary>
    /// Logica base para componentes logicos arduino
    /// </summary>
    public abstract class SwitchableArduinoBaseBusiness : BaseBusiness, ISwitchableBusiness
    {
        #region Fields
        private readonly IArduinoInstructionsResourceAccess instructionsResourceAccess;

        /// <inheritdoc cref="IArduinoResourceAccess" path="/summary"/>
        protected readonly IArduinoResourceAccess ArduinoAccess;

        /// <summary>
        /// Nombre del componente conmutable
        /// </summary>
        protected readonly string Name;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="arduinoAcceess"><inheritdoc cref="IArduinoResourceAccess" path="/summary"/></param>
        /// <param name="instructionsResourceAccess"><inheritdoc cref="IArduinoInstructionsResourceAccess" path="/summary"/></param>
        /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
        protected SwitchableArduinoBaseBusiness(
            IMapper mapper,
            IArduinoResourceAccess arduinoAcceess,
            IArduinoInstructionsResourceAccess instructionsResourceAccess,
            string name = null) : base(mapper)
        {
            ArduinoAccess = arduinoAcceess;
            this.instructionsResourceAccess = instructionsResourceAccess;
            Name = name ?? string.Empty;
        }
        #endregion

        #region Public Methods
        /// <inheritdoc cref="ISwitchableBusiness.GetStateAsync()"/>
        public abstract Task<bool> GetStateAsync();

        /// <inheritdoc cref="ISwitchableBusiness.TurnOnAsync(IBaseCriteria)"/>
        public async Task<bool> TurnOnAsync()
        {
            return await TryAsync(async () =>
            {
                return await GetAndExecuteAsync($"TurnOn{Name}");

            }, nameof(TurnOnAsync));
        }

        /// <inheritdoc cref="ISwitchableBusiness.TurnOffAsync()"/>
        public async Task<bool> TurnOffAsync()
        {
            return await TryAsync(async () =>
            {
                return await GetAndExecuteAsync($"TurnOff{Name}");

            }, nameof(TurnOffAsync));
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Obtiene el codigo y ejecuta la instruccion a partir del nombre
        /// </summary>
        /// <param name="instructionName">Nombre de instruccion</param>
        /// <returns></returns>
        protected async Task<bool> GetAndExecuteAsync(string instructionName)
        {
            return await TryAsync(async () =>
            {
                var instruction = await instructionsResourceAccess
                .GetInstructionByNameAsync(new GetByNameParameter
                {
                    Name = instructionName
                });

                return await ArduinoAccess.ExecuteAsync(new ExecuteParameter
                {
                    Code = instruction.Code
                });

            }, nameof(GetAndExecuteAsync));
        }
        #endregion
    }
}
