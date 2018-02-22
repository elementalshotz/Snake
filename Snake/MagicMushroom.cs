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
        Point point;

        public MagicMushroom(Point point) : base(point)
        {
            this.point = point;
            
        }

        new public void Draw(Graphics g)
        {
            g.DrawIcon(new Icon("Apple.ico"), 50, 50);
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
