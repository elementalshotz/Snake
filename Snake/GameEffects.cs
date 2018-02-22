using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Snake
{
    class GameEffects
    {
        SoundPlayer soundPlayer = new SoundPlayer();
        string Source;

        public GameEffects(string source)
        {
            Source = source;
            setSource();
        }

        void setSource()
        {
            soundPlayer.SoundLocation = Source;
        }

        public void Play()
        {
            soundPlayer.Play();
        }
    }
}
