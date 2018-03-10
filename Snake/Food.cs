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
        protected static List<Food> foods = new List<Food>();
        protected Rectangle rect;
        
        public MatrixPoint Matrix { get; protected set; }

        public Rectangle GetRectangle
        {
            get => rect;
        }

        public static Random random = new Random();
        private static readonly object syncLock = new object();
        private enum Type { Standard, Valuable, Coffee, MagicMushroom }

        public static Point SpawnPoint()
        {
            lock (syncLock)
            {
                int x = random.Next(Settings.Width - Settings.size);
                while (x % 15 != 0)
                {
                    x = random.Next(Settings.Width - Settings.size);
                }

                int y = random.Next(Settings.Height - Settings.size);
                while (y % 15 != 0)
                {
                    y = random.Next(Settings.Height - Settings.size);
                }

                return new Point(x, y);
            }
        }

        protected bool CheckFoodPosition()
        {
            if (foods == null)
                return false;

            foreach (var eatable in foods)
            {
                if (eatable.Matrix.Equals(this.Matrix))
                    return true;
            }

            return false;
        }

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
                foods.Add(foodDict[food]);
                return foodDict[food];
            }
        }

        public Point Position { get => Pos; internal set => Pos = value; }

        internal abstract void Draw(Graphics g);
        internal abstract void Hit(Collider collider);
        internal abstract void AddEffect(ref List<Player> playerList);
        internal abstract void IncreaseLength(ref Player player);
        internal abstract void IncreaseScore(ref Player player);

        public void Update()
        {
            rect = new Rectangle(Pos, new Size(Settings.size, Settings.size));
            Matrix = new MatrixPoint(Pos.X / 15, Pos.Y / 15);
        }
    }
}
