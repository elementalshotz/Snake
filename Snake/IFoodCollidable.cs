using System.Collections.Generic;
using System.Drawing;

namespace Snake
{
    interface IFoodCollidable : ICollidable
    {
        void AddEffect(ref List<Player> playerList);
        void IncreaseLength(ref Player player);
        void IncreaseScore(ref Player player);
        void Draw(Graphics g, Food food);
    }
}