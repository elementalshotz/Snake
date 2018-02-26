using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class MagicMushroom : Food, IFoodCollidable
    {
        public MagicMushroom(Point point) : base(point) => Pos = point;

        internal override void Draw(Graphics g)
        {
            g.DrawIcon(new Icon("Mushroom.ico"), Pos.X, Pos.Y);
        }

        internal override void Hit(Collider collider)
        {
            throw new NotImplementedException();
        }

        internal override void Remove(Food food)
        {
            throw new NotImplementedException();
        }

        internal override void AddEffect(ref List<Player> playerList)
        {
            throw new NotImplementedException();
        }

        internal override void IncreaseLength(ref Player player)
        {
            throw new NotImplementedException();
        }

        internal override void IncreaseScore(ref Player player)
        {
            throw new NotImplementedException();
        }

        public Point Position
        {
            get => Pos;
            set => Pos = value;
        }
    }
}
