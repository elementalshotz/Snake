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

        public delegate void GameOverDelegate(int id);
        public event GameOverDelegate GameOverEvent;

        public Collider(List<Player> playerList, List<Food> foodList)
        {

            Players = playerList;
            Eatables = foodList;
            //Any constructor that we can use to initialize the collider class with
        }

        public void Collide(Player player)
        {
            for (int i = 1; i < player.snakeBody.Count; i++)
            {
                var head = player.snakeBody.First();
                if (head.Part.Equals(player.snakeBody[i].Part))
                {
                    Players.Remove(player);

                    if (Players.Count < 1)
                        GameOverEvent?.Invoke(player.playerID);

                    break;
                }
            }
        }

        public void CollideWithPlayers(Player player)
        {
            int index = 0;

            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Equals(player))
                {
                    index = i;
                }
            }

            for (int i = 0; i < Players.Count; i++)
            {
                if (i != index)
                {
                    if (player.snakeBody.First().Equals(Players[i].snakeBody.First()))
                    {
                        Players.Remove(player);
                        break;
                    }
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
