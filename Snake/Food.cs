﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;
using Snake;

namespace Snake
{
    public abstract class Food
    {
        protected Point Pos;            //Used to set the point of the rectangle and to minimize the length of the code on one line
        protected Rectangle Rect;       //A rectangle used to draw the food
        
        private static readonly Random _r = new Random();   //Used to spawn food at a random location
        
        public Point Position { get => Pos; internal set => Pos = value; }      //Set the point internally but only access it with a public getter

        public MatrixPoint Matrix { get; protected set; }                       //Same as the point just that the setter is protected

        public Rectangle GetRectangle => Rect;                                  //A get-only property

        private static readonly object syncLock = new object();                 //To lock the thread during randomization of food type because Random is not thread safe

        public static Food Create()                 //Only calls the createFood method, but is public due to spawntimer from outside
        {
            return CreateFood();
        }

        private static Food CreateFood()
        {
            lock (syncLock)
            {
                int foodType = _r.Next(10);         //Randomize a value between 0 and 10

                if (0 <= foodType && 4 >= foodType) //Spawn standard at a higher rate than the other types of food.
                {
                    return new StandardFood();
                } else if (5 <= foodType && 6 >= foodType)
                {
                    return new ValuableFood();
                } else if (7 <= foodType && 8 >= foodType)
                {
                    return new CoffeeFood();
                } else
                {
                    return new MagicMushroom();
                }
            }
        }

        public void Update(Point point)             //When spawning food the point is generated from outside of the class and then sent to the food object via this function
        {
            Position = point;
            Rect = new Rectangle(Position, new Size(Settings.size, Settings.size));
            Matrix = new MatrixPoint(Pos.X / 15, Pos.Y / 15);
        }

        /*The class is abstract due to we never use it in initialization and therefore never need to implement following methods */
        internal abstract void Draw(Graphics g);
        internal abstract void Hit(Collider collider);
        internal abstract void AddEffect(List<Player> playerList);
        internal abstract void IncreaseLength(Player player);
        internal abstract void IncreaseScore(Player player);
    }
}
