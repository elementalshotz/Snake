using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class ValuableFood : Food, IFoodCollidable
    {
        public ValuableFood(Point pos) : base(pos)
        {
        }

        internal override void AddEffect(ref List<Player> playerList)
        {
            throw new NotImplementedException();
        }

        internal override void Draw(Graphics g)
        {
            g.DrawIcon(new Icon("CoffieCup.ico"), Pos.X, Pos.Y);
        }

        internal override void Hit(Collider collider)
        {
            collider.Collide(this);
        }

        internal override void IncreaseLength(ref Player player)
        {
            for (int i = 0; i < Settings.valuableLength; i++)
            {
                player.snakeBody.Add(player.snakeBody.Last());
            }
        }

        internal override void IncreaseScore(ref Player player) => player.Score += Settings.valueableFood;

        internal override void Remove(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
