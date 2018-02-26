using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class ValuableFood : Food, IFoodCollidable
    {
        public ValuableFood(Point pos) : base(pos)
        {
        }

        public void AddEffect(ref List<Player> playerList)
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics g)
        {
            g.DrawIcon(new Icon("CoffieCup.ico"), Pos.X, Pos.Y);
        }

        public void Hit(Collider collider)
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

        public void Remove(Collider collider)
        {
            throw new NotImplementedException();
        }
    }
}
