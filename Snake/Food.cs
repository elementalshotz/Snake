using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    abstract class Food : IFoodCollidable
    {
        protected Point Pos;

        public Food(Point pos)
        {
            Pos = pos;
        }

        private static Random random = new Random();
        private enum Type { Standard, Valuable, Coffe, MagicMushroom }

        private static Dictionary<Type, Food> foodDict = new Dictionary<Type, Food>()
        {
            { Type.Standard, new StandardFood(new Point(random.Next(), random.Next())) },
            { Type.Valuable, new ValuableFood(new Point(random.Next(), random.Next())) },
            { Type.Coffe, new CoffeFood(new Point(random.Next(), random.Next())) },
            { Type.MagicMushroom, new MagicMushroom(new Point(random.Next(), random.Next())) }
        };

        public static Food Create()
        {
            return CreateFood();
        }

        private static Food CreateFood()
        {
            return foodDict.ElementAt(random.Next(foodDict.Count)).Value;
        }

        public void AddEffect(ref List<Player> playerList)
        {
            throw new NotImplementedException();
        }

        public void IncreaseLength(ref Player player)
        {
            throw new NotImplementedException();
        }

        public void IncreaseScore(ref Player player)
        {
            throw new NotImplementedException();
        }

        public void Hit(Collider collider)
        {
            throw new NotImplementedException();
        }

        public void Remove(Collider collider)
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics g, Food food)
        {
            food.Draw(g);
        }

        public Point Position { get; internal set; }
    }
}
