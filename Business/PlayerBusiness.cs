using AutoMapper;
using Business.Abstractions;
using Business.Abstractions.Entities.Criterias;
using Business.Abstractions.Entities.Views;
using Business.Entities.Criterias;
using Business.Entities.Parameters;
using Business.Entities.Views;
using Cross.Entities.Enums;
using Resources.Abstractions;
using Resources.Abstractions.Entities.Samples;

namespace Business
{
    public class PlayerBusiness : BaseBusiness, IPlayerBusiness
    {
        #region Fields
        private readonly IVlcResourceAccess _vlcService;
        private readonly IRadiosResourceAccess _radiosService;

        private IEnumerable<IRadioSample> _radios = new List<IRadioSample>();
        private List<IRadioSample> _playlist = new List<IRadioSample>();
        private IRadioSample _media;
        private int _index;
        private int _volume = 50;
        private bool _aleatory;
        private RepeatMode _repeatMode;
        private bool _playlistFull => _playlist.Count() >= _radios.Count();
        #endregion

        #region Constructors
        /// <summary>
        /// <inheritdoc cref="BaseBusiness(IMapper)" path="/summary"/>
        /// </summary>
        /// <param name="mapper">
        ///     <inheritdoc cref="BaseBusiness(IMapper)"
        ///                 path="/param[@name='mapper']"/>
        /// </param>
        /// <param name="vlcService">
        ///     <inheritdoc cref="IVlcResourceAccess"
        ///                 path="/summary"/>
        /// </param>
        /// <param name="radioService">
        ///     <inheritdoc cref="IRadiosResourceAccess"
        ///                 path="/summary"/>
        /// </param>
        public PlayerBusiness(
            IMapper mapper,
            IVlcResourceAccess vlcService,
            IRadiosResourceAccess radioService) : base(mapper)
        {
            _vlcService = vlcService;
            _radiosService = radioService;
        }
        #endregion

        #region Public Methods
        /// <inheritdoc cref="IPlayerBusiness.GetPlaying"/>
        public async Task<IPlayerStateView> GetPlaying()
            => await TryAsync(async () =>
                {
                    var playing = await _vlcService.IsNowPlayingAsync();

                    var media = Mapper.Map(_media, new MediaView
                    {
                        Playing = playing
                    });

                    return new PlayerStateView
                    {
                        Media = media,
                        Volume = _volume,
                        Aleatory = _aleatory,
                        RepeatMode = (int)_repeatMode
                    };

                }, nameof(GetPlaying));

        /// <inheritdoc cref="IPlayerBusiness.PauseAsync"/>
        public Task PauseAsync() => TryAsync(_vlcService.PauseAsync, nameof(PauseAsync));

        /// <inheritdoc cref="IPlayerBusiness.PlayAsync(IPlayCriteria)"/>
        public async Task<IMediaView> PlayAsync(IPlayCriteria criteria)
            =>  await TryAsync<PlayCriteria, IPlayCriteria, IMediaView>(async criteria =>
                {
                    await this.SetVolumeAsync(criteria);

                    _repeatMode = (RepeatMode)criteria.RepeatMode;
                    _aleatory = criteria.Aleatory;

                    var result = true;

                    if (criteria.MediaId != null)
                    {
                        var radio = await _radiosService.GetByParameterAsync(
                            new GetByIdParameter(criteria.MediaId ?? 0));

                        _media = radio;

                        result = await playAsync();
                    }
                    else if (!await _vlcService.IsNowPlayingAsync())
                    {
                        if (_media is null)
                            await setFirst(_aleatory);

                        result = await playAsync();
                    }

                    return Mapper.Map(_media, new MediaView
                    {
                        Playing = result
                    });

                }, criteria, nameof(PlayAsync));

        /// <inheritdoc cref="IPlayerBusiness.NextAsync(IChangeCriteria)"/>
        public async Task<IMediaView> NextAsync(IChangeCriteria criteria)
            => await TryAsync<ChangeCriteria, IChangeCriteria, IMediaView>(async criteria =>
                {
                    await this.SetVolumeAsync(criteria);

                    _repeatMode = (RepeatMode)criteria.RepeatMode;
                    _aleatory = criteria.Aleatory;

                    if (_media != null)
                    {
                        if (_repeatMode != RepeatMode.RepeatOne)
                        {
                            if (_aleatory)
                            {
                                if (_index + 1 >= _playlist.Count)
                                {
                                    if (_playlistFull)
                                    {
                                        if (_repeatMode == RepeatMode.RepeatAll)
                                            _media = _playlist.First();
                                        else
                                            setAleatoryNext();
                                    }
                                    else
                                        setAleatoryNext();

                                    _playlist.Add(_media);
                                }
                                else
                                    _media = _playlist.ElementAt(_index + 1);
                            }
                            else
                            {
                                var index = _radios.ToList().IndexOf(_media);

                                if (index + 1 >= _radios.Count())
                                    index = 0;
                                else
                                    index++;

                                _media = _radios.ElementAt(index);

                                _playlist = _playlist.Take(_index + 1).ToList();
                                _playlist.Add(_media);
                            }

                            while (_playlist.Count() > _radios.Count())
                                _playlist.RemoveAt(0);

                            if (_index + 1 < _radios.Count())
                                _index++;
                            else
                                _index = _radios.Count() - 1;
                        }
                    }
                    else
                        await setFirst(_aleatory);

                    var playing = await playAsync();

                    if (!playing)
                        _index--;

                    return Mapper.Map(_media, new MediaView
                    {
                        Playing = playing
                    });

                }, criteria, nameof(NextAsync));

        /// <inheritdoc cref="IPlayerBusiness.PreviousAsync(IChangeCriteria)"/>
        public async Task<IMediaView> PreviousAsync(IChangeCriteria criteria)
            => await TryAsync<ChangeCriteria, IChangeCriteria, IMediaView>(async criteria =>
                {
                    await this.SetVolumeAsync(criteria);

                    _repeatMode = (RepeatMode)criteria.RepeatMode;
                    _aleatory = criteria.Aleatory;

                    if (_media != null)
                    {
                        if (_repeatMode != RepeatMode.RepeatOne)
                        {
                            if (_aleatory)
                            {
                                if (_index - 1 < 0)
                                {
                                    if (_playlistFull
                                    && _repeatMode == RepeatMode.RepeatAll)
                                        _media = _playlist.Last();
                                    else
                                        setAleatoryPrevious();

                                    _playlist = _playlist.Prepend(_media).ToList();
                                }
                                else
                                {
                                    _index--;
                                    _media = _playlist.ElementAt(_index);
                                }
                            }
                            else
                            {
                                var index = _radios.ToList().IndexOf(_media);

                                if (index == 0)
                                    index = _radios.Count() - 1;
                                else
                                    index--;

                                _media = _radios.ElementAt(index);
                                _playlist = _playlist.TakeLast(_playlist.Count() - _index).ToList();

                                _index = 0;
                                _playlist = _playlist.Prepend(_media).ToList();
                            }

                            while (_playlist.Count() > _radios.Count())
                                _playlist.RemoveAt(_playlist.Count() - 1);
                        }
                    }
                    else
                        await setFirst(_aleatory);

                    var playing = await playAsync();

                    if (!playing)
                        _index++;

                    return Mapper.Map(_media, new MediaView
                    {
                        Playing = playing
                    });
                }, criteria, nameof(PreviousAsync));

        /// <inheritdoc cref="IPlayerBusiness.SetVolumeAsync(IVolumeCriteria)"/>
        public async Task SetVolumeAsync(IVolumeCriteria criteria)
            => await TryAsync<VolumeCriteria, IVolumeCriteria>(async criteria =>
                {
                    _volume = criteria.Volume;

                    var param = Mapper.Map<VolumeParameter>(criteria);

                    await _vlcService.SetVolumeAsync(param);

                }, criteria, nameof(SetVolumeAsync));

        /// <inheritdoc cref="IPlayerBusiness.StopAsync"/>
        public Task StopAsync() => TryAsync(_vlcService.StopAsync, nameof(StopAsync));
        #endregion

        #region Private Methods
        private async Task<IEnumerable<IRadioSample>> getRadiosAsync()
            => await TryAsync(async () =>
                {
                    var radios = await _radiosService.GetRadiosAsync();

                    return radios;

                }, nameof(getRadiosAsync));

        private async Task<bool> playAsync()
            => await TryAsync(async () =>
                {
                    var urlParam = new UrlParameter(_media.Url);

                    await _vlcService.PlayUriAsync(urlParam);

                    int attempts = 10;

                    var result = await _vlcService.IsNowPlayingAsync();

                    while (!result && attempts > 0)
                    {
                        await Task.Delay(1000);
                        result = await _vlcService.IsNowPlayingAsync();

                        attempts--;
                    }

                    if (!result)
                    {
                        await _radiosService.SetStatusAsync(new SetStatusParameter
                        {
                            Id = _media.Id,
                            Status = false
                        });

                        _playlist.RemoveAll(r => r == _media);
                        _radios = await getRadiosAsync();
                    }

                    return result;

                }, nameof(playAsync));

        private void setAleatory(bool next)
            => Try(() =>
                {
                    var random = new Random();

                    var randomList = _radios
                        .Where(r => !_playlist.Contains(r))
                        .OrderBy(order => random.Next()).ToList();

                    var limit = _playlist.Count() / 2 - randomList.Count();

                    if (limit > 0)
                    {
                        var firsts = next ? _playlist.Take(limit) : _playlist.TakeLast(limit);

                        randomList = randomList.Concat(firsts.OrderBy(order => random.Next())).ToList();
                    }

                    _media = randomList.ElementAt(random.Next(randomList.Count()));

                }, nameof(setAleatory));

        private void setAleatoryNext() => Try(() => setAleatory(true), nameof(setAleatoryNext));

        private void setAleatoryPrevious() => Try(() => setAleatory(false), nameof(setAleatoryPrevious));

        private async Task setFirst(bool aleatory)
            => await TryAsync(async () =>
                {
                    if (_radios.Count() == 0)
                        _radios = await getRadiosAsync();

                    if (aleatory)
                    {
                        var random = new Random();

                        _media = _radios.ElementAt(random.Next(_radios.Count()));
                    }
                    else
                        _media = _radios.First();

                    _index = 0;
                    _playlist = new List<IRadioSample> { _media };

                }, nameof(setFirst));
        #endregion
    }
}
