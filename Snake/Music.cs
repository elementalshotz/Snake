using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake 
{
    class Music
    {
        System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();

        public Music()
        {
            ShuffleMusic();
            Play();
        }

        public void Play()
        {
            soundPlayer.Play();
        }

        public void ShuffleMusic()
        {
            soundPlayer.SoundLocation = "shootingstars.wav";
            
        }

        public void Stop()
        {
            soundPlayer.Stop();
        }
    }
}
