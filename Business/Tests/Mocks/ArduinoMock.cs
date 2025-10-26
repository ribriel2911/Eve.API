using Cross.Tests.Mocks;
using Resources.Abstractions;
using Business.Entities.Parameters;
using Moq;

namespace Business.Tests.Mocks
{
    public class ArduinoMock : SimpleMock<IArduinoResourceAccess>
    {
        #region Properties
        /// <inheritdoc cref="IArduinoResourceAccess.ExecuteAsync(ExecuteParameter)"/>
        public readonly ExecuteAsyncMock ExecuteAsync;

        /// <inheritdoc cref="IArduinoResourceAccess.ResetAsync"/>
        public readonly ResetAsyncMock ResetAsync;

        /// <inheritdoc cref="IArduinoResourceAccess.GetStatesAsync"/>
        public readonly GetStatesAsyncMock GetStatesAsync;
        #endregion

        #region Constructors
        /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock"/>
        public ArduinoMock() : base()
        {
            this.ExecuteAsync = new ExecuteAsyncMock(this);
            this.ResetAsync = new ResetAsyncMock(this);
            this.GetStatesAsync = new GetStatesAsyncMock(this);
        }
        #endregion

        #region Mocked Methods
        /// <inheritdoc cref="IArduinoResourceAccess.ExecuteAsync(ExecuteParameter)"/>
        public class ExecuteAsyncMock :
            AsyncSimpleMock<IArduinoResourceAccess, ExecuteParameter, bool>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public ExecuteAsyncMock(ArduinoMock parent)
                : base(parent.Mock, c => s => s.ExecuteAsync(It.Is(c))) { }
            #endregion
        }

        /// <inheritdoc cref="IArduinoResourceAccess.ResetAsync"/>
        public class ResetAsyncMock :
            AsyncSimpleOutputMock<IArduinoResourceAccess, string>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public ResetAsyncMock(ArduinoMock parent)
                : base(parent.Mock, c => s => s.ResetAsync()) { }
            #endregion
        }

        /// <inheritdoc cref="IArduinoResourceAccess.GetStatesAsync"/>
        public class GetStatesAsyncMock :
            AsyncSimpleOutputMock<IArduinoResourceAccess, bool[]>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public GetStatesAsyncMock(ArduinoMock parent)
                : base(parent.Mock, c => s => s.GetStatesAsync()) { }
            #endregion
        }
        #endregion
    }
}
