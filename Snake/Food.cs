using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Snake;

namespace Snake
{
    public abstract class Food
    {
        protected Point Pos;
        protected static List<Food> foods = new List<Food>();
        protected Rectangle rect;

        public Rectangle GetRectangle
        {
            get => rect;
        }

        private static Random foodRandom = new Random();
        private enum Type { Standard, Valuable, Coffee, MagicMushroom }

        public static Point SpawnPoint()
        {
            int x = foodRandom.Next(Settings.Width - Settings.size);
            while (x % 15 != 0)
            {
                x = foodRandom.Next(Settings.Width - Settings.size);
            }

            int y = foodRandom.Next(Settings.Height - Settings.size);
            while (y % 15 != 0)
            {
                y = foodRandom.Next(Settings.Height - Settings.size);
            }

            return new Point(x, y);
        }

        protected bool CheckFoodPosition()
        {
            bool isSamePos = false;

            foreach (var food in foods)
            {
                if (this != food)
                {
                    if (this.rect.IntersectsWith(food.rect))
                    {
                        isSamePos = true;
                        break;
                    } else
                    {
                        isSamePos = false;
                    }
                }
                else
                {
                    isSamePos = false;
                }
            }

            return isSamePos;
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
            Type food = (Type)foodRandom.Next(foodDict.Count);
            foods.Add(foodDict[food]);
            return foodDict[food];
        }

        public Point Position { get => Pos; internal set => Pos = value; }

        internal abstract void Draw(Graphics g);
        internal abstract void Hit(Collider collider);
        internal abstract void AddEffect(ref List<Player> playerList);
        internal abstract void IncreaseLength(ref Player player);
        internal abstract void IncreaseScore(ref Player player);
    }
}
