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
        string[] songs = new string[] { "shootingstars.wav", "Derezzed.wav","Onemoretime.wav" };    //Some music while playing snake
        Random random;

        public bool IsPlaying { get; private set; }

        public Music()
        {
            soundPlayer = new System.Media.SoundPlayer();
            random = new Random();
        }

        public void Play()                      //A function that sets a property that is checked when closing the gamewindow
        {                                       //and also playing music while the game is running
            IsPlaying = true;
            soundPlayer.Play();
        }

        public void ShuffleMusic()              //This is picking a random song from the list to play while the game is running
        {
            soundPlayer.SoundLocation = songs[random.Next(songs.Length)];
        }

        public void Stop()                      //Sets the property to false and stops the music
        {
            IsPlaying = false;
            soundPlayer.Stop();
        }
    }
}
