using Cross.Logic;
using Resources.Entities.Identifiers;
using Resources.Abstractions;
using System.IO.Ports;
using Resources.Singletons;
using Resources.Abstractions.Entities.Parameters;
using AutoMapper;
using Resources.Entities.Parameters;

namespace Resources
{
    /// <summary>
    /// <inheritdoc cref="IArduinoResourceAccess" path="/summary"/> Nano
    /// </summary>
    public class ArduinoNanoResourceAccess : BaseEntityManager, IArduinoResourceAccess
    {
        #region Fields
        private readonly SerialPort serialPort;
        #endregion

        #region Constructor
        /// <inheritdoc cref="BaseEntityManager.BaseEntityManager(IMapper)"/>
        public ArduinoNanoResourceAccess(IMapper mapper) : base(mapper)
        {
            serialPort = SerialConnection.GetInstance(Arduino.Port);
        }
        #endregion

        #region Public Methods
        ///<inheritdoc cref="IArduinoResourceAccess.ExecuteAsync(IExecuteParameter)"/>
        public Task<bool> ExecuteAsync(IExecuteParameter param)
        {
            this.Validate<IExecuteParameter, ExecuteParameter>(param);

            return this.ExecuteInstruction(param.Code);
        }

        /// <inheritdoc cref="IArduinoResourceAccess.GetStatesAsync(IBaseEntity)"/>
        public Task<bool[]> GetStatesAsync()
        {
            string result = this.SerialOperation(() =>
            {
                this.serialPort.WriteLine(Arduino.GetStatesInstruction);

                return serialPort.ReadLine().Trim();
            });

            var results = result.Split(',')
                .Select(str => bool.Parse(str)).ToArray();

            Thread.Sleep(1000);

            return Task.FromResult(results);
        }

        /// <inheritdoc cref="IArduinoResourceAccess.ResetAsync(IBaseEntity)"/>
        public Task<string> ResetAsync()
        {
            var result = this.SerialOperation(() =>
            {
                this.serialPort.WriteLine(Arduino.ResetInstruction);

                return serialPort.ReadLine().Trim();
            });

            Thread.Sleep(1000);

            return Task.FromResult(result);
        }
        #endregion

        #region Private Methods
        private TResult SerialOperation<TResult>(Func<TResult> operation)
        {
            try
            {
                while (this.serialPort.IsOpen)
                {
                    Thread.Sleep(5000);
                }

                this.serialPort.Open();

                var result = operation();

                this.serialPort.Close();

                return result;
            }
            catch
            {
                this.serialPort.Close();
                throw;
            }
        }

        private void SerialOperation(Action action)
        {
            try
            {
                while (this.serialPort.IsOpen)
                {
                    Thread.Sleep(5000);
                }

                this.serialPort.Open();

                action();

                this.serialPort.Close();
            }
            catch (Exception ex)
            {
                this.serialPort.Close();
                throw;
            }
        }

        private Task<bool> ExecuteInstruction(string instruction)
        {
            try
            {
                string stateStr = string.Empty;

                this.SerialOperation(() =>
                {
                    this.serialPort.WriteLine(instruction);

                    stateStr = this.serialPort.ReadLine().Trim();
                });

                Thread.Sleep(1000);

                return Task.FromResult(bool.Parse(stateStr));
            }
            catch (Exception ex)
            {
                return Task.FromException<bool>(ex);
            }
        }
        #endregion
    }
}
