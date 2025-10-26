using Cross.Tests.Mocks;
using Moq;
using Resources.Abstractions;
using Resources.Abstractions.Entities.Parameters;

namespace Business.Tests.Mocks
{
    public class VlcMock : SimpleMock<IVlcResourceAccess>
    {
        #region Properties
        public readonly IsNowPlayingAsyncMock IsNowPlayingAsync;
        public readonly PauseAsyncMock PauseAsync;
        public readonly PlayAsyncFileInfoMock PlayAsyncFileInfo;
        public readonly PlayAsyncUriMock PlayAsyncUri;
        public readonly PlayFileAsyncMock PlayFileAsync;
        public readonly PlayUriAsyncMock PlayUriAsync;
        public readonly SetVolumeAsyncMock SetVolumeAsync;
        public readonly StopAsyncMock StopAsync;
        #endregion

        #region Constructors
        /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock"/>
        public VlcMock() : base() 
        {
            this.IsNowPlayingAsync = new IsNowPlayingAsyncMock(this);
            this.PauseAsync = new PauseAsyncMock(this);
            this.PlayAsyncFileInfo = new PlayAsyncFileInfoMock(this);
            this.PlayAsyncUri = new PlayAsyncUriMock(this);
            this.PlayFileAsync = new PlayFileAsyncMock(this);
            this.PlayUriAsync = new PlayUriAsyncMock(this);
            this.SetVolumeAsync = new SetVolumeAsyncMock(this);
            this.StopAsync = new StopAsyncMock(this);
        }
        #endregion

        #region Mocked Methods
        /// <inheritdoc cref="IVlcResourceAccess.IsNowPlayingAsync"/>
        public class IsNowPlayingAsyncMock :
            AsyncSimpleOutputMock<IVlcResourceAccess, bool>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public IsNowPlayingAsyncMock(VlcMock parent)
                : base(parent.Mock, c => s => s.IsNowPlayingAsync()) { }
            #endregion
        }

        /// <inheritdoc cref="IVlcResourceAccess.PauseAsync"/>
        public class PauseAsyncMock :
            AsyncSimpleMock<IVlcResourceAccess>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public PauseAsyncMock(VlcMock parent)
                : base(parent.Mock, c => s => s.PauseAsync()) { }
            #endregion
        }

        /// <inheritdoc cref="IVlcResourceAccess.PlayAsync(IFileInfoParameter)"/>
        public class PlayAsyncFileInfoMock :
            AsyncSimpleMock<IVlcResourceAccess, IFileInfoParameter>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public PlayAsyncFileInfoMock(VlcMock parent)
                : base(parent.Mock, c => s => s.PlayAsync(It.IsAny<IFileInfoParameter>())) { }
            #endregion
        }

        /// <inheritdoc cref="IVlcResourceAccess.PlayAsync(Uri)"/>
        public class PlayAsyncUriMock :
            AsyncSimpleMock<IVlcResourceAccess, Uri>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public PlayAsyncUriMock(VlcMock parent)
                : base(parent.Mock, c => s => s.PlayAsync(It.IsAny<Uri>())) { }
            #endregion
        }

        /// <inheritdoc cref="IVlcResourceAccess.PlayFileAsync(IUrlParameter)"/>
        public class PlayFileAsyncMock :
            AsyncSimpleMock<IVlcResourceAccess, IUrlParameter>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public PlayFileAsyncMock(VlcMock parent)
                : base(parent.Mock, c => s => s.PlayFileAsync(It.IsAny<IUrlParameter>())) { }
            #endregion
        }

        /// <inheritdoc cref="IVlcResourceAccess.PlayUriAsync(IUrlParameter)"/>
        public class PlayUriAsyncMock :
            AsyncSimpleMock<IVlcResourceAccess, IUrlParameter>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public PlayUriAsyncMock(VlcMock parent)
                : base(parent.Mock, c => s => s.PlayUriAsync(It.IsAny<IUrlParameter>())) { }
            #endregion
        }

        /// <inheritdoc cref="IVlcResourceAccess.SetVolumeAsync(IVolumeParameter)"/>
        public class SetVolumeAsyncMock :
            AsyncSimpleMock<IVlcResourceAccess, IVolumeParameter>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public SetVolumeAsyncMock(VlcMock parent)
                : base(parent.Mock, c => s => s.SetVolumeAsync(It.IsAny<IVolumeParameter>())) { }
            #endregion
        }

        /// <inheritdoc cref="IVlcResourceAccess.StopAsync"/>
        public class StopAsyncMock :
            AsyncSimpleMock<IVlcResourceAccess>
        {
            #region Constructors
            /// <inheritdoc cref="SimpleMock{TInterface}.SimpleMock(Mock{TInterface})"/>
            public StopAsyncMock(VlcMock parent)
                : base(parent.Mock, c => s => s.StopAsync()) { }
            #endregion
        }
        #endregion
    }
}
