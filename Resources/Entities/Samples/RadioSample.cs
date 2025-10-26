using AutoMapper;
using Cross.Abstractions;
using Cross.Entities.Enums;
using Cross.Extensions;
using Resources.Abstractions.Entities.Samples;
using Resources.Entities.DTOs;

namespace Resources.Entities.Samples
{
    public class RadioSample : IRadioSample, IMapFrom<MediaDTO>
    {
        #region Properties

        /// <inheritdoc cref="IMediaSample.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="IMediaSample.Name"/>
        public string Name { get; set; }

        /// <inheritdoc cref="IMediaSample.Url"/>
        public string Url { get; set; }

        /// <inheritdoc cref="IRadioSample.Frequency"/>
        public decimal? Frequency { get; set; }

        /// <inheritdoc cref="IRadioSample.Wave"/>
        public Wave Wave { get; set; }
        #endregion

        #region Public Methods
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MediaDTO, RadioSample>()
                .ForMember(s => s.Frequency, opt => opt.MapFrom((d, src) => d.Radio?.Frequency))
                .ForMember(s => s.Wave, opt => opt.MapFrom((d, src) => d.Radio?.Wave?.Name.ToEnum(Wave.FM)));

            profile.CreateMap<RadioDTO, RadioSample>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.Medias.FirstOrDefault(m => m.Status).Id))
                .ForMember(s => s.Name, opt => opt.MapFrom(d => d.Medias.FirstOrDefault(m => m.Status).Name))
                .ForMember(s => s.Url, opt => opt.MapFrom(d => d.Medias.FirstOrDefault(m => m.Status).Url))
                .ForMember(s => s.Wave, opt => opt.MapFrom(d => d.Wave.Name.ToEnum(Wave.FM)));
        }
        #endregion
    }
}
