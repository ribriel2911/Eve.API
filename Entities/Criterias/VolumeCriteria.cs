using API.Entities.Inputs;
using Business.Abstractions.Entities.Criterias;
using Cross.Abstractions;

namespace API.Entities.Criterias
{
    public class VolumeModel : IVolumeCriteria
    {
        public int Volume { get; set; }
    }

    public class VolumeCriteria : VolumeModel, IMapFrom<VolumeInput> { }
}
