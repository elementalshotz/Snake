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
        public void Draw(Graphics g)
        {
            PointF[] point = new PointF[4];
            point[0] = new PointF(20, 50);
            point[1] = new PointF(30, 70);
            point[2] = new PointF(10, 70);
            point[3] = new PointF(20, 100);
            g.DrawPolygon(new Pen(Color.Green), point);
        }
    }
}
