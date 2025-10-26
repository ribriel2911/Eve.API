using API.Entities.Inputs;
using Business.Abstractions.Entities.Criterias;
using Cross.Abstractions;

namespace API.Entities.Criterias
{
    public class PlayModel : ChangeModel, IPlayCriteria
    {
        /// <inheritdoc cref="IPlayCriteria.MediaId"/>
        public int? MediaId { get; set; }
    }

    public class PlayCriteria : PlayModel, IMapFrom<PlayInput> { }
}
