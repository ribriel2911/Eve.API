using Business.Abstractions.Entities.Views;

namespace Business.Entities.Views
{
    ///<inheritdoc cref="IPlayerStateView"/>
    public class PlayerStateView : IPlayerStateView
    {
        ///<inheritdoc cref="IPlayerStateView.Media"/>
        public IMediaView Media { get; set; }

        ///<inheritdoc cref="IPlayerStateView.Volume"/>
        public int Volume { get; set; }

        ///<inheritdoc cref="IPlayerStateView.Aleatory"/>
        public bool Aleatory { get; set; }

        ///<inheritdoc cref="IPlayerStateView.RepeatMode"/>
        public int RepeatMode { get; set; }
    }
}
