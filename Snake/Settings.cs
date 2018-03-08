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
        public static int Width { get; set; }
        public static int Height { get; set; }

        static Random random = new Random();
        public static int FPS = 10;

        public static int EffectLengthCoffeeFood = 5000;
        public static int EffectLengthMagicMushroom = 3000;
        public static int SpeedChange = 2;

        public static int standardFood = 1;
        public static int valueableFood = 5;
        public static int magicMushroom = 10;

        public static int standardLength = 1;
        public static int valuableLength = 2;
        public static int mushroomLength = 5;

        public static int size = 15;

        static Keys[] PlayerOne = new Keys[4]
        {
            Keys.Up, Keys.Left, Keys.Down, Keys.Right //Player 1
        };

        static Keys[] PlayerTwo = new Keys[4]
        {
            Keys.I, Keys.J, Keys.K, Keys.L //Player 2
        };

        static Keys[] PlayerThree = new Keys[4]
        {
            Keys.W, Keys.A, Keys.S, Keys.D  //Player 3
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

        public static Brush[] playerColor = new Brush[3] { new SolidBrush(Color.Red), new SolidBrush(Color.Green), new SolidBrush(Color.Blue) };

        public static Point[] startLocations = new Point[3] { new Point(0, 30), new Point(0, 90), new Point(0, 150) };
    }
}
