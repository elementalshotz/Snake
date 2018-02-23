using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public abstract class Food
    {
        protected Point Pos;

        public Food(Point pos)
        {
            Pos = pos;
        }
    }
}
