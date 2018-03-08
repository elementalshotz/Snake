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
        public List<Timer> timerList = new List<Timer>();
        int playerID;

        public delegate void ScoreChangeDelegate();
        public event ScoreChangeDelegate scoreChangeEvent;

        public int Score
        {
            get => score;
            set {
                score = value;
                scoreChangeEvent.Invoke();
            }
        }

        public Player(Keys[] keys, Brush brush, Point startPoint, int ID) : base(startPoint)
        {
            playerKeys = keys;
            this.brush = brush;
            playerID = ID;
        }

        public void Player_KeyDown(object sender, KeyEventArgs e)
        {
            Direction oldDirection = moveDirection;

            if (e.KeyCode == playerKeys[0])
            {
                if (oldDirection != Direction.Down)
                    moveDirection = Direction.Up;
            }
            else if (e.KeyCode == playerKeys[1])
            {
                if (oldDirection != Direction.Right)
                    moveDirection = Direction.Left;
            }
            else if (e.KeyCode == playerKeys[2])
            {
                if (oldDirection != Direction.Up)
                    moveDirection = Direction.Down;
            }
            else if (e.KeyCode == playerKeys[3])
            {
                if (oldDirection != Direction.Left)
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
            foreach (var bodyPart in snakeBody)
            {
                g.FillRectangle(brush, bodyPart.Part);
            }
        }

        public void activateEffect(MagicMushroom mushroom)
        {
            playerKeys = Settings.playerKeysInvert[playerID];

            addTimer(mushroom);     //Used to create a timer with a reasonable length that removes itself and reverts the effect on timer end
        }

        public void activateEffect(CoffeeFood coffee)
        {
            multiplier = Settings.SpeedChange;

            addTimer(coffee);
        }

        public void addTimer(Food food)
        {
            Timer t = new Timer();

            if (food is MagicMushroom)
            {
                t.Interval = Settings.EffectLengthMagicMushroom;
                t.Tick += mushroom_TimerEvent;
            } else if (food is CoffeeFood)
            {
                t.Interval = Settings.EffectLengthCoffeeFood;
                t.Tick += coffee_TimerEvent;
            }

            t.Start();
            timerList.Add(t);
        }

        public void mushroom_TimerEvent(object sender, EventArgs e)
        {
            playerKeys = Settings.playerKeys[playerID];

            Timer t = (Timer)sender;
            t.Stop();
            timerList.Remove(t);
        }

        public void coffee_TimerEvent(object sender, EventArgs e)
        {
            multiplier = 1;

            Timer t = (Timer)sender;
            t.Stop();
            timerList.Remove(t);
        }
    }
}