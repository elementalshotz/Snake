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

        public Point PartPoint => point;

        public BodyPart(Point point)
        {
            this.point = point;
            matrixPoint = new MatrixPoint(0, 0);
            rectangle = new Rectangle(PartPoint, new Size(Settings.size, Settings.size));
        }

        public static bool operator ==(BodyPart p1, BodyPart p2)
        {
            bool rect = p1.rectangle.Equals(p2.rectangle);
            bool point = p1.point.Equals(p2.point);
            bool matrix = p1.matrixPoint.Equals(p2.matrixPoint);

            return rect && point && matrix;
        }

        public static bool operator !=(BodyPart p1, BodyPart p2)
        {
            bool rect = p1.rectangle.X != p2.rectangle.X && p1.rectangle.Y != p2.rectangle.Y;
            bool point = p1.point.X != p2.point.X && p1.point.Y != p2.point.Y;
            bool matrix = p1.matrixPoint.X != p2.matrixPoint.X && p1.matrixPoint.Y != p2.matrixPoint.Y;

            return rect && point && matrix;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
