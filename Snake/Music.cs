using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake 
{
    class Music
    {
        System.Media.SoundPlayer soundPlayer;
        string[] songs = new string[4] { "Lasse.wav", "shootingstars.wav", "Derezzed.wav","Onemoretime.wav" };
        Random random;

        private bool playing;
        public bool IsPlaying
        {
            get { return playing; }
            set { playing = value; }
        }
        
        public Music()
        {
            soundPlayer = new System.Media.SoundPlayer();
            random = new Random();
        }

        public void Play()
        {
            IsPlaying = true;
            soundPlayer.Play();
        }

        public void ShuffleMusic()
        {
            soundPlayer.SoundLocation = songs[random.Next(4)];
        }

        public void Stop()
        {
            IsPlaying = false;
            soundPlayer.Stop();
        }

        public bool isPlaying()
        {
            return IsPlaying;
        }
    }
}
