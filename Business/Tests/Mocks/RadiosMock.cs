using Cross.Tests.Mocks;
using Resources.Abstractions;
using Resources.Abstractions.Entities.Samples;
using Moq;
using Resources.Abstractions.Entities.Parameters;

namespace Business.Tests.Mocks
{
    public class RadiosMock : SimpleMock<IRadiosResourceAccess>
    {
        #region Properties
        public readonly GetRadiosAsyncMock GetRadiosAsync;
        public readonly GetByIdParameterAsyncMock GetByIdParameterAsync;
        public readonly SetStatusAsyncMock SetStatusAsync;
        #endregion

        #region Constructors
        /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock"/>
        public RadiosMock() : base()
        {
            this.GetRadiosAsync = new GetRadiosAsyncMock(this);
            this.GetByIdParameterAsync = new GetByIdParameterAsyncMock(this);
            this.SetStatusAsync = new SetStatusAsyncMock(this);
        }
        #endregion

        #region Mocked Methods
        /// <inheritdoc cref="IRadiosResourceAccess.GetRadiosAsync"/>
        public class GetRadiosAsyncMock :
            AsyncSimpleOutputMock<IRadiosResourceAccess, IEnumerable<IRadioSample>>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public GetRadiosAsyncMock(RadiosMock parent)
                : base(parent.Mock, c => s => s.GetRadiosAsync()) { }
            #endregion
        }

        /// <inheritdoc cref="IMediaUrlsResourceAccess{ITMedia, TParam}.GetByParameterAsync(IGetByIdParameter)"/>
        public class GetByIdParameterAsyncMock :
            AsyncSimpleMock<IRadiosResourceAccess, IGetByIdParameter, IRadioSample>
        {
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public GetByIdParameterAsyncMock(RadiosMock parent)
                : base(parent.Mock, c => s => s.GetByParameterAsync(It.Is(c))) { }
        }

        public class SetStatusAsyncMock :
            AsyncSimpleMock<IRadiosResourceAccess, ISetStatusParameter>
        {
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public SetStatusAsyncMock(RadiosMock parent)
                : base(parent.Mock, c => s => s.SetStatusAsync(It.Is(c))) { }
        }
        #endregion
    }
}
