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
        Rectangle rectangle; //The rectangle that is drawn
        Point point;        //The rectangle uses this to set it's location

        public MatrixPoint matrixPoint; //The same purpose as the comment is saying in the class MatrixPoint to disguise as a matrix but not really use one

        public Rectangle Part           //A getter and setter if you need to update the Part otherwise the part is private
        {
            get => rectangle;
            set => rectangle = value;
        }

        public Point PartPoint => point; //A getter to only compare the points

        public BodyPart(Point point)     //A constructor to set all the variables in this class
        {
            this.point = point;
            matrixPoint = new MatrixPoint(0, 0);
            rectangle = new Rectangle(PartPoint, new Size(Settings.size, Settings.size));
        }

        public static bool operator ==(BodyPart p1, BodyPart p2) //Comparing each bodypart to one another and saying that it is equal
        {
            bool rect = p1.rectangle.Equals(p2.rectangle);
            bool point = p1.point.Equals(p2.point);
            bool matrix = p1.matrixPoint.Equals(p2.matrixPoint);

            return rect && point && matrix;
        }

        public static bool operator !=(BodyPart p1, BodyPart p2) //Comparing each bodypart to one another and saying that it is not equal
        {
            bool rect = p1.rectangle.X != p2.rectangle.X && p1.rectangle.Y != p2.rectangle.Y;
            bool point = p1.point.X != p2.point.X && p1.point.Y != p2.point.Y;
            bool matrix = p1.matrixPoint.X != p2.matrixPoint.X && p1.matrixPoint.Y != p2.matrixPoint.Y;

            return rect && point && matrix;
        }

        public override bool Equals(object obj) //If we implement the functions for == and  != you also need Equals and GetHashCode() even if you're not gonna use them
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
