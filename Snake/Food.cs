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

        public MatrixPoint Matrix { get; protected set; }

        public Rectangle GetRectangle => Rect;

        private static readonly object syncLock = new object();
        private enum Type { Standard, Valuable, Coffee, MagicMushroom }

        private static Dictionary<Type, Food> foodDict = new Dictionary<Type, Food>()
        {
            { Type.Standard, new StandardFood() },
            { Type.Valuable, new ValuableFood() },
            { Type.Coffee, new CoffeeFood() },
            { Type.MagicMushroom, new MagicMushroom() }
        };

        public static Food Create()
        {
            return CreateFood();
        }

        private static Food CreateFood()
        {
            lock (syncLock)
            {
                Type food = (Type)new Random().Next(foodDict.Count);
                return foodDict[food];
            }
        }

        public Point Position { get => Pos; internal set => Pos = value; }

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
