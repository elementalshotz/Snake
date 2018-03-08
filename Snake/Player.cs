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
        public List<Timer> timerList;
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

        public Player(Keys[] keys, Brush brush, Point startPoint) : base(startPoint)
        {
            playerKeys = keys;
            this.brush = brush;
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

        public void activateEffect(MagicMushroom mushroom)      //The variable that is going in here is only used to separate the code of what the two functions do.
        {
            switch (playerID)
            {
                case 1: playerKeys = Settings.playerKeysInvert[0]; break;
                case 2: playerKeys = Settings.playerKeysInvert[1]; break;
                case 3: playerKeys = Settings.playerKeysInvert[2]; break;
            }

            addTimer(mushroom);
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
            switch (playerID)
            {
                case 1: playerKeys = Settings.playerKeys[0]; break;
                case 2: playerKeys = Settings.playerKeys[1]; break;
                case 3: playerKeys = Settings.playerKeys[2]; break;
            }

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