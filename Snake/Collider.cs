using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Collider
    {
        List<Player> Players;
        List<Food> Eatables;

        public Collider(ref List<Player> PlayerList, ref List<Food> FoodList)
        {

            Players = PlayerList;
            Eatables = FoodList;
            //Any constructor that we can use to initialize the collider class with
        }

        public void Collide(Player player)
        {
            foreach (var bodyPart in player.snakeBody)
            {
                bool bodypart = bodyPart != player.snakeBody.First();
                if (player.snakeBody.First().matrixPoint.Equals(bodyPart.matrixPoint) && bodypart)
                {
                    Players.Remove(player);
                    break;
                }
            }
        }

        public void Collide(Food food)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].snakeBody.First().Part.Equals(food.GetRectangle))
                {
                    Player player = Players[i];

                    food.IncreaseLength(ref player);
                    food.IncreaseScore(ref player);
                    food.AddEffect(ref Players);

                    Players[i] = player;

                    Eatables.Remove(food);
                }
            }
        }
    }
}
