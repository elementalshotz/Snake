using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public class Food : IDrawable
    {
        PointF Pos;
        RectangleF rectangle;

        public Food(PointF pos)
        {
            Pos = pos;
            rectangle = new RectangleF(pos, new Size(100, 100));
        }

        public void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.White), rectangle);
        }
    }
}
