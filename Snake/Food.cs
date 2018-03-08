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
        private int xCoordinate;
        private int yCoordinate;
        //protected Icon icon;

        public Food()
        {
            do
            {
                xCoordinate = foodRandom.Next(Settings.Width - Settings.size);
            } while (xCoordinate % 15 != 0);

            do
            {
                yCoordinate = foodRandom.Next(Settings.Height - Settings.size);
            } while (yCoordinate % 15 != 0);

            Pos = new Point(xCoordinate, yCoordinate);
        }
        
        private static Random foodRandom = new Random();
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
            return foodDict[(Type)foodRandom.Next(foodDict.Count)];
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
