using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    static class Settings
    {
        public static int FPS = 1;
        public static int EffectLength = 3000;

        public static int standardFood = 1;
        public static int valueableFood = 5;
        public static int magicMushroom = 10;

        public static int standardLength = 1;
        public static int valuableLength = 2;
        public static int mushroomLength = 5;

        static Keys[] PlayerOne = new Keys[4]
        {
            Keys.W, Keys.A, Keys.S, Keys.D
        };

        static Keys[] PlayerTwo = new Keys[4]
        {
            Keys.Up, Keys.Left, Keys.Down, Keys.Right
        };

        static Keys[] PlayerThree = new Keys[4]
        {
            Keys.I, Keys.J, Keys.K, Keys.L
        };

        public static Keys[][] playerKeys = new Keys[3][] { PlayerOne, PlayerTwo, PlayerThree };
    }
}
