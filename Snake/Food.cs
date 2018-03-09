using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Snake;

namespace Snake
{
    public abstract class Food : IFoodCollidable
    {
        protected Point Pos;
        protected static List<Food> foods = new List<Food>();

        private static Random foodRandom = new Random();
        private enum Type { Standard, Valuable, Coffee, MagicMushroom }

        protected static Point SpawnPoint()
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
        
        public void Draw(Graphics g, Food food) => food.Draw(g);

        public void Hit(Collider collider, Food food)
        {
            food.Hit(collider);
        }

        public void Remove(Collider collider, Food food)
        {
            //collider.Remove(food);
        }

        public void AddEffect(ref List<Player> playerList, Food food)
        {
            food.AddEffect(ref playerList);
        }

        public void IncreaseLength(ref Player player, Food food)
        {
            food.IncreaseLength(ref player);
        }

        public void IncreaseScore(ref Player player, Food food)
        {
            food.IncreaseScore(ref player);
        }

        public Point Position { get => Pos; internal set => Pos = value; }

        internal abstract void Draw(Graphics g);
        internal abstract void Hit(Collider collider);
        internal abstract void AddEffect(ref List<Player> playerList);
        internal abstract void IncreaseLength(ref Player player);
        internal abstract void IncreaseScore(ref Player player);
    }
}
