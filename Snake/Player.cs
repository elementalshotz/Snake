using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    public class Player
    {
        Keys[] playerKeys;
        protected int score;
        Color color;

        public int Score
        {
            get => score;
            set => score = value;
        }

        public Player(Keys[] keys, Color color)
        {
            playerKeys = keys;
            this.color = color;
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
                score += Settings.magicMushroom;
                //Code to go left
            }
            else if (e.KeyCode == playerKeys[2])
            {
                score += Settings.valueableFood;
                //Code to go down
            }
            else if (e.KeyCode == playerKeys[3])
            {
                score += Settings.standardFood;
                //Code to go right
            }
        }
    }
}