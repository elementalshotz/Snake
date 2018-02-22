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
        Image image;
        Point point;

        public MagicMushroom(Point point) : base(point)
        {
            this.point = point;
        }

        new public void Draw(Graphics g)
        {
            g.DrawIcon(new Icon("Mushroom.jpg"), new Rectangle(point, new Size(100, 100)));
        }

        public void Hit(Food food)
        {
            throw new NotImplementedException();
        }

        public void Remove(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
