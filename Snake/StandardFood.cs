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
            random = new Random();
        }

        public void AddEffect(ref List<Player> playerList)
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics g)
        {
            g.DrawIcon(new Icon("Apple.ico"), Pos.X, Pos.Y);
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
            player.Score += Settings.standardFood;
        }

        public void Remove(Collider collider)
        {
            throw new NotImplementedException();
        }
    }
}
