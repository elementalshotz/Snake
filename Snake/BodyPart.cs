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
        Point point;

        public MatrixPoint matrixPoint;

        public Rectangle Part
        {
            get => rectangle;
            set => rectangle = value;
        }

        public Point PartPoint
        {
            get => point;
        }
        
        public BodyPart(Point point)
        {
            this.point = point;
            matrixPoint = new MatrixPoint(0, 0);
            rectangle = new Rectangle(PartPoint, new Size(Settings.size, Settings.size));
        }
    }
}
