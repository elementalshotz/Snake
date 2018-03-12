using System;
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
        protected Point Pos;
        protected Rectangle Rect;
        
        private static readonly Random _r = new Random();
        
        public Point Position { get => Pos; internal set => Pos = value; }

        public MatrixPoint Matrix { get; protected set; }

        public Rectangle GetRectangle => Rect;

        private static readonly object syncLock = new object();
        private enum Type { Standard, Valuable, Coffee, MagicMushroom }

        public static Food Create()
        {
            return CreateFood();
        }

        private static Food CreateFood()
        {
            lock (syncLock)
            {
                int foodType = _r.Next(10);

                if (0 <= foodType && 4 >= foodType)
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

        internal abstract void Draw(Graphics g);
        internal abstract void Hit(Collider collider);
        internal abstract void AddEffect(ref List<Player> playerList);
        internal abstract void IncreaseLength(ref Player player);
        internal abstract void IncreaseScore(ref Player player);

        public void Update(Point point)
        {
            Position = point;
            Rect = new Rectangle(Position, new Size(Settings.size, Settings.size));
            Matrix = new MatrixPoint(Pos.X/15, Pos.Y/15);
        }
    }
}
