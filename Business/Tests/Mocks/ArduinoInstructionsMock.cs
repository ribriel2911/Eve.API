using Business.Entities.Parameters;
using Business.Tests.Samples;
using Cross.Tests.Mocks;
using Moq;
using Resources.Abstractions;
using Resources.Abstractions.Entities.Parameters;
using Resources.Abstractions.Entities.Samples;

namespace Business.Tests.Mocks
{
    /// <summary>
    /// <inheritdoc cref="IArduinoInstructionsResourceAccess"/>
    /// mockeadas
    /// </summary>
    public class ArduinoInstructionsMock : SimpleMock<IArduinoInstructionsResourceAccess>
    {
        #region Properties
        /// <inheritdoc cref="IArduinoInstructionsResourceAccess.GetInstructionsAsync(BaseEntity)"/>
        public GetInstructionsAsyncMock GetInstructionsAsync { get; }

        /// <inheritdoc cref="IArduinoInstructionsResourceAccess.GetInstructionByNameAsync(GetByNameParameter)"/>
        public GetInstructionByNameAsyncMock GetInstructionByNameAsync { get; }
        #endregion

        #region Constructors
        /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock"/>
        public ArduinoInstructionsMock() : base()
        {
            this.GetInstructionsAsync = new GetInstructionsAsyncMock(this);
            this.GetInstructionByNameAsync = new GetInstructionByNameAsyncMock(this);
        }
        #endregion

        #region Public Methods
        public static IArduinoInstructionSample GetView(string code, string name)
            => new InstructionSample { Code = code , Name = name};
        #endregion

        #region Mocked Methods
        /// <inheritdoc cref="IArduinoInstructionsResourceAccess.GetInstructionsAsync()"/>
        public class GetInstructionsAsyncMock :
            AsyncSimpleMock<IArduinoInstructionsResourceAccess, IEnumerable<IArduinoInstructionSample>>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public GetInstructionsAsyncMock(ArduinoInstructionsMock parent)
                : base(parent.Mock, c => s => s.GetInstructionsAsync()) { }
            #endregion
        }

        /// <inheritdoc cref="IArduinoInstructionsResourceAccess.GetInstructionByNameAsync(IGetByNameParameter)"/>
        public class GetInstructionByNameAsyncMock :
            AsyncSimpleMock<IArduinoInstructionsResourceAccess, GetByNameParameter, IArduinoInstructionSample>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public GetInstructionByNameAsyncMock(ArduinoInstructionsMock parent)
                : base(parent.Mock, 
                      c => 
                        s => 
                            s.GetInstructionByNameAsync(It.Is(c))) { }
            #endregion        
        }
        #endregion
    }
}
