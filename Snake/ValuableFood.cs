﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class ValuableFood : Food, IFoodCollidable
    {
        public ValuableFood(Point pos) : base(pos)
        {
        }

        internal override void AddEffect(ref List<Player> playerList)
        {
            throw new NotImplementedException();
        }

        internal override void Draw(Graphics g)
        {
            g.DrawIcon(new Icon("CoffieCup.ico"), Pos.X, Pos.Y);
        }

        internal override void Hit(Collider collider)
        {
            //collider.Collide(this);
            throw new NotImplementedException();
        }

        internal override void IncreaseLength(ref Player player)
        {
            throw new NotImplementedException();
        }

        internal override void IncreaseScore(ref Player player)
        {
            throw new NotImplementedException();
        }

        internal override void Remove(Food food)
        {
            throw new NotImplementedException();
        }
    }
}