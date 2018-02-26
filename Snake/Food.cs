using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Snake;

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
            { Type.Standard, new StandardFood(new Point(random.Next(447), random.Next(389))) },
            { Type.Valuable, new ValuableFood(new Point(random.Next(447), random.Next(389))) },
            { Type.Coffe, new CoffeFood(new Point(random.Next(447), random.Next(389))) },
            { Type.MagicMushroom, new MagicMushroom(new Point(random.Next(447), random.Next(389))) }
        };

        public static Food Create()
        {
            return CreateFood();
        }

        private static Food CreateFood()
        {
            return foodDict.ElementAt(random.Next(foodDict.Count)).Value;
        }
        
        public void Draw(Graphics g, Food food) => food.Draw(g);

        public void Hit(Collider collider, Food food)
        {
            food.Hit(collider);
        }

        public void Remove(Collider collider, Food food)
        {
            //collider.Remove(food);
            food.Remove(food);
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

        public Point Position { get; internal set; }

        internal abstract void Draw(Graphics g);
        internal abstract void Hit(Collider collider);
        internal abstract void Remove(Food food);
        internal abstract void AddEffect(ref List<Player> playerList);
        internal abstract void IncreaseLength(ref Player player);
        internal abstract void IncreaseScore(ref Player player);
    }
}
