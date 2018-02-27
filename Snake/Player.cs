using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    public class Player : Snake, ICollidable
    {
        Keys[] playerKeys;
        protected int score;
        Brush brush;
        Pen pen;
        public List<Timer> timerList;

        public int Score
        {
            get => score;
            set => score = value;
        }

        public Player(Keys[] keys, Brush brush) : base()
        {
            playerKeys = keys;
            this.brush = brush;
        }

        public void Player_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == playerKeys[0])
            {
                moveDirection = Direction.Up;
            }
            else if (e.KeyCode == playerKeys[1])
            {
                moveDirection = Direction.Left;
            }
            else if (e.KeyCode == playerKeys[2])
            {
                moveDirection = Direction.Down;
            }
            else if (e.KeyCode == playerKeys[3])
            {
                moveDirection = Direction.Right;
            }
        }

        public void Hit(Collider collider)
        {
            collider.Collide(this);
        }

        public void Remove(Collider collider)
        {
            for(int i = 0; i < 5; i++)
            {
                snakeBody.Add(snakeBody.Last());
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var rectangle in snakeBody)
            {
                g.FillRectangle(brush, rectangle);
            }
        }

        public void Player_TimerEvent(object sender, EventArgs e)
        {
            //timer.Stop();
        }
    }
}