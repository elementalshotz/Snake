﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public abstract class Food : IDrawable
    {
        PointF Pos;

        public Food(PointF pos)
        {
            Pos = pos;
        }

        public void Draw(Graphics g)
        {
            
        }
    }
}
