﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class CoffeFood : Food, ICollidable
    {
        public CoffeFood(Point point) : base(point) => Pos = point;

        public override void AddEffect(ref List<Player> playerList, ref Player player)
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics g)
        {
            g.DrawIcon(new Icon("CoffieCup.ico"), 50, 50);
        }

        public void Hit(Food food)
        {
            throw new NotImplementedException();
        }

        public override void IncreaseLength(ref Player player)
        {
            throw new NotImplementedException();
        }

        public override void IncreaseScore(ref Player player)
        {
            throw new NotImplementedException();
        }

        public void Remove(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
