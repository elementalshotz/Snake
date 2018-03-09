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

        public Collider(ref List<Player> PlayerList,ref List<Food> FoodList)
        {

            Players = PlayerList;
            Eatables = FoodList;
            //Any constructor that we can use to initialize the collider class with
        }

        public void Collide(Player player)
        {
            
            int i = 0;
            foreach (var Player in Players)
            {
                if (i == 0)
                {
                    if (player.snakeBody[0].Part.IntersectsWith(Player.snakeBody[0].Part))
                    {

                    }
                }
                foreach(var Bodypart in Player.snakeBody)
                {
                    if (player.snakeBody[0].Part.IntersectsWith(Player.snakeBody[i].Part))
                    {

                    }
                }
               
                i++;
               
            }
        }

        public void Collide(Food food)
        {
            //Some if statement
            //Remove code
            //foodList.Remove(food);
        }
    }
}
