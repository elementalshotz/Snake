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
        readonly Brush brush;
        public List<Timer> timerList = new List<Timer>();
        public int playerID;
        private Timer _timer;
        private int Ticks;

        public delegate void ScoreChangeDelegate(int id, int score);
        public event ScoreChangeDelegate scoreChangeEvent;

        public int Score
        {
            get => score;
            set {
                score = value;
                scoreChangeEvent.Invoke(playerID, score);
            }
        }

        public Player(Keys[] keys, Brush brush, Point startPoint, int ID) : base(startPoint)
        {
            playerKeys = keys;
            this.brush = brush;
            playerID = ID;
            _timer = new Timer();
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

        internal void AddParts(int length)
        {
            BodyPart bodyPart = default(BodyPart);
            Point point = new Point(snakeBody.Last().Part.X, snakeBody.Last().Part.Y);

            for (int i = 0; i < length; i++)
            {
                switch (moveDirection)
                {
                    case Direction.Up:
                        point.Y += Settings.size;
                        bodyPart = new BodyPart(point);
                        break;
                    case Direction.Down:
                        point.Y -= Settings.size;
                        bodyPart = new BodyPart(point);
                        break;
                    case Direction.Left:
                        point.X += Settings.size;
                        bodyPart = new BodyPart(point);
                        break;
                    case Direction.Right:
                        point.X -= Settings.size;
                        bodyPart = new BodyPart(point);
                        break;
                    default: break;
                }

                snakeBody.Add(bodyPart);
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

        public void ActivateEffect(MagicMushroom mushroom)
        {
            playerKeys = Settings.playerKeysInvert[playerID - 1];

            AddTimer(mushroom);     //Used to create a timer with a reasonable length that removes itself and reverts the effect on timer end
        }

        public void ActivateEffect(CoffeeFood coffee)
        {
            _timer = new Timer {Interval = 1000 / (Settings.FPS / 2)};
            _timer.Tick += _timer_Tick;
            _timer.Start();

            AddTimer(coffee);
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            Timer t = (Timer) sender;
            Ticks++;

            if (!(Ticks >= 50))
            {
                MoveSnake();
            }
            else
            {
                t.Stop();
                Ticks = 0;
            }
        }

        public void AddTimer(Food food)
        {
            Timer t = new Timer();

            if (food is MagicMushroom)
            {
                t.Interval = Settings.EffectLengthMagicMushroom;
                t.Tick += mushroom_TimerEvent;
            } 
            else if (food is CoffeeFood)
            {
                t.Interval = Settings.EffectLengthCoffeeFood;
                t.Tick += coffee_TimerEvent;
            }
            else
            {
                throw new NotSupportedException();
            }

            timerList.Add(t);
            t.Start();
        }

        public void mushroom_TimerEvent(object sender, EventArgs e)
        {
            playerKeys = Settings.playerKeys[playerID - 1];

            Timer t = (Timer)sender;
            t.Stop();
            timerList.Remove(t);
        }

        public void coffee_TimerEvent(object sender, EventArgs e)
        {
            _timer.Stop();
            _timer = new Timer();

            Timer t = (Timer)sender;
            t.Stop();
            timerList.Remove(t);
        }
    }
}