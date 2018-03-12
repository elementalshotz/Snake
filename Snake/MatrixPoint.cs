using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class MatrixPoint    //A class to disguise everything as a matrix while not really using a matrix
    {
        int x;      //The X point in the matrix
        int y;      //The Y point in the matrix

        public MatrixPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get => this.x;
            set => this.x = value;
        }

        public int Y
        {
            get => this.y;
            set => this.y = value;
        }

        public override bool Equals(object obj)
        {                                           //A function to check the point against other points, it is required to check both x and y.
            MatrixPoint matrix = (MatrixPoint)obj;

            bool xEquals = matrix.x == this.x;
            bool yEquals = matrix.y == this.y;

            return xEquals && yEquals;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
