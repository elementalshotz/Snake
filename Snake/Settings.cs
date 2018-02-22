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
        static int standardFood = 1;
        static int valueableFood = 5;
        static int magicMushroom = 10;

        static Keys[] PlayerOne = new Keys[4]
        {
            Keys.W, Keys.A, Keys.S, Keys.D
        };

        static Keys[] PlayerTwo = new Keys[4]
        {
            Keys.Up, Keys.Down, Keys.Left, Keys.Right
        };

        static Keys[] PlayerThree = new Keys[4]
        {
            Keys.I, Keys.J, Keys.K, Keys.L
        };
    }
}
