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

        public abstract void IncreaseScore(ref Player player);
        public abstract void IncreaseLength(ref Player player);
        public abstract void AddEffect(ref List<Player> playerList);
    }
}
