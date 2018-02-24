using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class MagicMushroom : Food, ICollidable
    {
        public MagicMushroom(Point point) : base(point) => Pos = point;

        public void Draw(Graphics g)
        {
            g.DrawIcon(new Icon("Mushroom.ico"), 50, 50);
        }

        public Point Position
        {
            get => Pos;
            set => Pos = value;
        }

        public void Hit(Food food)
        {
            throw new NotImplementedException();
        }

        public void Remove(Food food)
        {
            throw new NotImplementedException();
        }

        public override void IncreaseScore(ref Player player)
        {
            player.Score += Settings.magicMushroom;
        }

        public override void IncreaseLength(ref Player player)
        {
            throw new NotImplementedException();
        }

        public override void AddEffect(ref List<Player> playerList)
        {

        }
    }
}
