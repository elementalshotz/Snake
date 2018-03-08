using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public class CoffeeFood : Food, IFoodCollidable
    {
        public CoffeeFood() : base()
        {
            //icon = new Icon("CoffieCup.ico");
        }

        internal override void AddEffect(ref List<Player> playerList)
        {
            //Settings.AddEffect(ref playerList);
        }

        internal override void Draw(Graphics g)
        {
            //g.DrawIcon(icon, Pos.X, Pos.Y);
            g.FillRectangle(new SolidBrush(Color.RosyBrown), new Rectangle(Position, new Size(Settings.size, Settings.size)));
        }

        internal override void Hit(Collider collider)
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

        internal override void Remove(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
