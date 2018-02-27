using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    static class Settings
    {
        static Random random = new Random();
        public static int FPS = 20;
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

        static Keys[] PlayerOneInvert = new Keys[4]
        {
            PlayerOne[2], PlayerOne[3], PlayerOne[0], PlayerOne[1]
        };

        static Keys[] PlayerTwoInvert = new Keys[4]
        {
            PlayerTwo[2], PlayerTwo[3], PlayerTwo[0], PlayerTwo[1]
        };

        static Keys[] PlayerThreeInvert = new Keys[4]
        {
            PlayerThree[2], PlayerThree[3], PlayerThree[0], PlayerThree[1]
        };

        public static Keys[][] playerKeysInvert = new Keys[3][] { PlayerOneInvert, PlayerTwoInvert, PlayerThreeInvert };

        public static Color[] playerColor = new Color[3] { Color.Red, Color.Green, Color.Blue };
    }
}
