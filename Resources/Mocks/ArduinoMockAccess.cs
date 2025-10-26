using Resources.Abstractions;
using Resources.Abstractions.Entities.Parameters;

namespace Resources.Mocks
{
    public class ArduinoMockAccess : IArduinoResourceAccess
    {
        #region Fields
        private bool[] _states { get; set; }
        #endregion

        #region Constructors
        public ArduinoMockAccess()
        {
            _states = new bool[] { false, false, false };
        }
        #endregion

        #region Public Methods
        /// <inheritdoc cref="IArduinoResourceAccess.ExecuteAsync(IExecuteParameter)"/>
        public Task<bool> ExecuteAsync(IExecuteParameter param)
        {
            bool result = false;

            switch (param.Code)
            {
                case "1": _states[0] = false; result = false; break;
                case "2": _states[1] = false; result = false; break;
                case "3": _states[2] = false; result = false; break;
                case "4": _states[0] = true; result = true; break;
                case "5": _states[1] = true; result = true; break;
                case "6": _states[2] = true; result = true; break;
                case "7": result = _states[0]; break;
                case "8": result = _states[1]; break;
                case "9": result = _states[2]; break;
                case "10": _states = new bool[] { false, false, false }; result = false; break;
                case "11": _states = new bool[] { true, true, true }; result = true; break;
            }

            return Task.FromResult(result);
        }

        public Task<string> ResetAsync()
        {
            var taskSource = new TaskCompletionSource<string>();

            _states = new bool[] { false, false, false };

            taskSource.SetResult("Arduino reiniciandose...");

            return taskSource.Task;
        }

        public Task<bool[]> GetStatesAsync()
        {
            return Task.FromResult(_states);
        }
        #endregion
    }
}
