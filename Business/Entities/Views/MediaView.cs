using AutoMapper;
using Business.Abstractions.Entities.Views;
using Cross.Abstractions;
using Resources.Abstractions.Entities.Samples;

namespace Business.Entities.Views
{
    public class MediaView : IMediaView, IMapFrom<IMediaView>
    {
        #region Properties

        /// <inheritdoc cref="IMediaView.Frequency"/>
        public decimal? Frequency { get; set; }

        /// <inheritdoc cref="IMediaView.Wave"/>
        public string Wave { get; set; }

        /// <inheritdoc cref="IMediaView.Name"/>
        public string Name { get; set; }

        /// <inheritdoc cref="IMediaView.Type"/>
        public string Type { get; set; }

        /// <inheritdoc cref="IMediaView.Duration"/>
        public TimeSpan? Duration { get; set; }

        /// <inheritdoc cref="IMediaView.Played"/>
        public TimeSpan? Played { get; set; }

        /// <inheritdoc cref="IMediaView.Playing"/>
        public bool Playing { get; set; }
        #endregion

        #region Methods
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IRadioSample, MediaView>()
                .ForMember(v => v.Wave, opt => opt.MapFrom(r => r.Wave.ToString("g")))
                .ForMember(v => v.Playing, opt => opt.UseDestinationValue())
                .ForMember(v => v.Type, opt => opt.MapFrom(r => "Radio"))
                .ForMember(v => v.Duration, opt => opt.Ignore())
                .ForMember(v => v.Played, opt => opt.Ignore());
        }
        #endregion
    }
}
