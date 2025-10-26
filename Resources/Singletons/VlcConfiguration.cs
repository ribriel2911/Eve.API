using Vlc.DotNet.Core;

namespace Resources.Singletons
{
    public class VlcConfiguration
    {
        private static VlcMediaPlayer VlcPlayer;

        internal static VlcMediaPlayer getPlayer()
        {
            if(VlcPlayer == null)
            {
                var source = new DirectoryInfo(@"C:\Program Files\VideoLAN\VLC");
                VlcPlayer = new VlcMediaPlayer(source, new[] { "--qt-start-minimized", "--no-video" });

                VlcPlayer.Audio.Volume = 100;
            }

            return VlcPlayer;
        }
    }
}
