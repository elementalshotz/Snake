using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public class BodyPart
    {
        Rectangle rectangle;
        Point PartPoint;

        public Rectangle Part
        {
            get => rectangle;
            set => rectangle = value;
        }
        
        public BodyPart(Point point)
        {
            PartPoint = point;
            rectangle = new Rectangle(PartPoint, new Size(10, 10));
        }
    }
}
