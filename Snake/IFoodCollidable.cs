using System.Collections.Generic;
using System.Drawing;

namespace Snake
{
    internal interface IFoodCollidable
    {
        void Hit(Collider collider, Food food);
        void Remove(Collider collider, Food food);
        void AddEffect(ref List<Player> playerList, Food food);
        void IncreaseLength(ref Player player, Food food);
        void IncreaseScore(ref Player player, Food food);
        void Draw(Graphics g, Food food);
    }
}