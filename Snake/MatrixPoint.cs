using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class MatrixPoint
    {
        int x;
        int y;

        public MatrixPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
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
