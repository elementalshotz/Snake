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
            soundPlayer.SoundLocation = "shootingstars.wav";
            soundPlayer.Play();
        }
    }
}
