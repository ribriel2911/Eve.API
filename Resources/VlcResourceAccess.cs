using AutoMapper;
using Cross.Logic;
using Resources.Abstractions;
using Resources.Abstractions.Entities.Parameters;
using Resources.Singletons;
using Vlc.DotNet.Core;

namespace Resources
{
    /// <inheritdoc cref="IVlcResourceAccess"/>
    public class VlcResourceAccess : BaseEntityManager, IVlcResourceAccess
    {
        #region Fields
        private VlcMediaPlayer Player = VlcConfiguration.getPlayer();
        #endregion

        #region Constructor
        /// <inheritdoc cref="BaseEntityManager(IMapper)"/>
        public VlcResourceAccess(IMapper mapper) : base(mapper) { }
        #endregion

        #region Public Methods
        /// <inheritdoc cref="IVlcResourceAccess.PauseAsync()"/>
        public Task PauseAsync()
        {
            if (this.Player.IsPausable())
            {
                this.Player.Pause();
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="IVlcResourceAccess.PlayAsync()"/>
        public Task PlayAsync()
        {
            this.Player.Play();

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="IVlcResourceAccess.PlayAsync(IFileInfoParameter)"/>
        public Task PlayAsync(IFileInfoParameter param)
        {
            //this.Validate(param);

            return this.Play(param.File.FullName, () => this.Player.SetMedia(param.File));
        }

        /// <inheritdoc cref="IVlcResourceAccess.PlayAsync(Uri)"/>
        public Task PlayAsync(Uri param)
        {
            return this.Play(param.AbsoluteUri, () => this.Player.SetMedia(param));
        }


        /// <inheritdoc cref="IVlcResourceAccess.PlayFileAsync(IUrlParameter)"/>
        public Task PlayFileAsync(IUrlParameter param)
        {
            //this.Validate(param);

            return this.Play(param.Url, () => this.Player.SetMedia(new FileInfo(param.Url)));
        }

        /// <inheritdoc cref="IVlcResourceAccess.PlayUriAsync(IUrlParameter)"/>
        public Task PlayUriAsync(IUrlParameter param)
        {
            //this.Validate(param);

            return this.Play(param.Url, () => this.Player.SetMedia(new Uri(param.Url)));
        }

        /// <inheritdoc cref="IVlcResourceAccess.SetVolumeAsync(IVolumeParameter)"/>
        public Task SetVolumeAsync(IVolumeParameter param)
        {
            //this.Validate(param);

            this.Player.Audio.Volume = param.Volume;

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="IVlcResourceAccess.StopAsync()"/>
        public Task StopAsync()
        {
            this.Player.Stop();

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="IVlcResourceAccess.IsNowPlayingAsync()"/>
        public async Task<bool> IsNowPlayingAsync()
        {
            var media = this.Player.GetMedia();

            return await Task.FromResult(this.Player.IsPlaying());
        }
        #endregion

        #region Private Methods
        private Task Play(string url, Action setMedia)
        {
            var media = this.Player.GetMedia();

            this.Player.Stop();

            if (media?.Mrl != url)
            {
                setMedia();
            }

            this.Player.Play();

            return Task.CompletedTask;
        }
    }
    #endregion
}