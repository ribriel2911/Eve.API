using Business.Abstractions.Entities.Criterias;
using Cross.Abstractions;
using Resources.Abstractions.Entities.Parameters;

namespace Business.Entities.Parameters
{
    public class VolumeParameter : IVolumeParameter, IMapFrom<IVolumeCriteria>
    {
        #region Properties
        /// <inheritdoc cref="IVolumeParameter.Volume"/>
        public int Volume { get; set; }
        #endregion
    }
}
