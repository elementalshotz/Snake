using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Player
    {
        Keys[] playerKeys;
        int score;

        public int Score
        {
            get => score;
        }

        public Player(Keys[] keys)
        {
            playerKeys = keys;
        }

        public void Player_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == playerKeys[0])
            {
                score += 100;
                //Code to go up
            }
            else if (e.KeyCode == playerKeys[1])
            {
                score += Settings.valueableFood;
                //Code to go left
            }
            else if (e.KeyCode == playerKeys[2])
            {
                score += Settings.standardFood;
                //Code to go down
            }
            else if (e.KeyCode == playerKeys[3])
            {
                score += Settings.magicMushroom;
                //Code to go right
            }
        }
    }
}
