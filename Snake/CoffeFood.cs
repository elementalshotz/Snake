using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class CoffeFood : Food, ICollidable
    {
        Random random;

        public CoffeFood(Point point) : base(point) => random = new Random();

        public override void AddEffect(ref List<Player> playerList)
        {
            int snakeToGiveEffect = random.Next(playerList.Count);
            playerList[snakeToGiveEffect]?.ToString();
        }

        public void Draw(Graphics g)
        {
            g.DrawIcon(new Icon("CoffieCup.ico"), 50, 50);
        }

        public void Hit(Food food)
        {
            //food.collider.Remove(this);
        }

        public override void IncreaseLength(ref Player player)
        {
            throw new NotImplementedException();
        }

        public override void IncreaseScore(ref Player player)
        {
            throw new NotImplementedException();
        }

        public void Remove(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
