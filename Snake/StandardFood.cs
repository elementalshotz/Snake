using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public class StandardFood : Food
    {

        internal override void AddEffect(List<Player> playerList)
        {
            return;                 //Absolutely do nothing about this code, no effect is supposed to be added from the standard type
        }

        internal override void Draw(Graphics g)
        {
            //g.DrawIcon(new Icon("Apple.ico"), Pos.X, Pos.Y);
            Point point = new Point(Matrix.X * Settings.size, Matrix.Y * Settings.size);
            Size size = new Size(Settings.size, Settings.size);
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(point, size));
        }

        internal override void Hit(Collider collider)
        {
            collider.Collide(this);
        }

        internal override void IncreaseLength(Player player)
        {
            player.AddParts(Settings.standardLength);
        }

        internal override void IncreaseScore(Player player) => player.Score += Settings.standardFood;
    }
}
