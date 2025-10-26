using API.Entities.Inputs;
using AutoMapper;
using Business.Abstractions.Entities.Criterias;
using Cross.Abstractions;
using Cross.Entities.Enums;

namespace API.Entities.Criterias
{
    public class ChangeModel : VolumeModel, IChangeCriteria
    {
        /// <inheritdoc cref="IChangeCriteria.Aleatory"/>
        public bool Aleatory { get; set; }

        /// <inheritdoc cref="IChangeCriteria.RepeatMode"/>
        public int RepeatMode { get; set; }
    }

    public class ChangeCriteria : ChangeModel, IMapFrom<ChangeInput>
    {
        #region Methods
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChangeInput, ChangeCriteria>()
                .ForMember(c => c.RepeatMode, opt => opt.MapFrom(i => (RepeatMode)i.RepeatMode));
        }
        #endregion
    }
}
