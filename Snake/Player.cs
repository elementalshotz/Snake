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

        public int Score        //When the score changes send the id and score to a function that uses the get and updates the score on screen.
        {
            get => score;
            set {
                score = value;
                scoreChangeEvent.Invoke(playerID, score);
            }
        }

        public Player(Keys[] keys, Brush brush, Point startPoint, int ID, Collider c) : base(startPoint, c)    //Initializes the player and adds a body that only has a head
        {
            playerKeys = keys;
            this.brush = brush;
            playerID = ID;
            _timer = new Timer();
        }

        public void Player_KeyDown(object sender, KeyEventArgs e)       //Controlls what happens when the player presses a key on the keyboard
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

        internal void AddParts(int length)  //Adds parts to the snake in the opposite direction of the movement of the snake.
        {                                   //Adds so many parts that is defined in the int length
            MatrixPoint point = new MatrixPoint(snakeBody.Last().X, snakeBody.Last().Y);

            for (int i = 0; i < length; i++)
            {
                switch (moveDirection)
                {
                    case Direction.Up:
                        point.Y += 1;
                        break;
                    case Direction.Down:
                        point.Y -= 1;
                        break;
                    case Direction.Left:
                        point.X += 1;
                        break;
                    case Direction.Right:
                        point.X -= 1;
                        break;
                    default: break;
                }

                snakeBody.Add(point);
            }
        }

        public void Hit(Collider collider)
        {
            collider.Collide(this);
        }

        public void Remove(Collider collider)
        {
            collider.Remove(this);
        }

        public void Draw(Graphics g)
        {
            foreach (var bodyPart in snakeBody)
            {
                Size size = new Size(Settings.size, Settings.size);
                Point point = new Point(bodyPart.X * Settings.size, bodyPart.Y * Settings.size);
                Rectangle r = new Rectangle(point, size);
                g.FillRectangle(brush, r);
            }
        }

        public void ActivateEffect(MagicMushroom mushroom)
        {
            playerKeys = Settings.playerKeysInvert[playerID - 1];

            AddTimer(mushroom);     //Used to create a timer with a reasonable length that removes itself and reverts the effect on timer end
        }

        public void ActivateEffect(CoffeeFood coffee)   //Adds a timer for speeding up the snake during that time
        {
            _timer = new Timer {Interval = 1000 / (Settings.FPS / 2)};
            _timer.Tick += _timer_Tick;
            _timer.Start();

            AddTimer(coffee);
        }

        private void _timer_Tick(object sender, EventArgs e)    //runs the moveSnake while Ticks is less than 50 else we stop even if the other timer has not ended
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

        public void AddTimer(Food food)                 //Adds a timer with the correct function and length depending on if it is MagicMushroom or CoffeeFood else we just throw an exception
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

        private void mushroom_TimerEvent(object sender, EventArgs e)    //Reset keys to their original state and remove the timer from the list of timers
        {
            playerKeys = Settings.playerKeys[playerID - 1];

            Timer t = (Timer)sender;
            t.Stop();
            timerList.Remove(t);
        }

        private void coffee_TimerEvent(object sender, EventArgs e)      //Stop the speedup effect and remove the timer that is controlling the speed timer
        {
            _timer.Stop();
            _timer = new Timer();

            Timer t = (Timer)sender;
            t.Stop();
            timerList.Remove(t);
        }
    }
}