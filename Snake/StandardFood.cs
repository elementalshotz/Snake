using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class StandardFood : Food, ICollidable
    {
        Random random;

        public StandardFood(Point point) : base(point)
        {
            Pos = point;
            random = new Random();
        }

        public override void AddEffect(ref List<Player> playerList)
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics g)
        {
            g.DrawIcon(new Icon("Apple.ico"), 50, 50);
        }

        public void Hit(Food food)
        {
            throw new NotImplementedException();
        }

        public override void IncreaseLength(ref Player player)
        {
            throw new NotImplementedException();
        }

        public override void IncreaseScore(ref Player player)
        {
            player.Score += Settings.standardFood;
        }

        public void Remove(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
