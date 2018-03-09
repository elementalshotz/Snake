﻿using System;
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
        public int playerID;

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

            for (int i = 0; i < length; i++)
            {
                switch (moveDirection)
                {
                    case Direction.Up:
                        bodyPart = new BodyPart(new Point(snakeBody.Last().Part.X, snakeBody.Last().Part.Y + Settings.size));
                        break;
                    case Direction.Down:
                        bodyPart = new BodyPart(new Point(snakeBody.Last().Part.X, snakeBody.Last().Part.Y - Settings.size));
                        break;
                    case Direction.Left:
                        bodyPart = new BodyPart(new Point(snakeBody.Last().Part.X + Settings.size, snakeBody.Last().Part.Y));
                        break;
                    case Direction.Right:
                        bodyPart = new BodyPart(new Point(snakeBody.Last().Part.X - Settings.size, snakeBody.Last().Part.Y));
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

        public void activateEffect(MagicMushroom mushroom)
        {
            playerKeys = Settings.playerKeysInvert[playerID - 1];

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
            playerKeys = Settings.playerKeys[playerID - 1];

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