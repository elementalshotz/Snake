using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Collider
    {
        List<Player> Players;       //Save away the reference to the list of players and the list of foods spawned
        List<Food> Eatables;

        public delegate void GameOverDelegate(int id);
        public event GameOverDelegate GameOverEvent;

        public Collider(List<Player> playerList, List<Food> foodList)
        {

            Players = playerList;
            Eatables = foodList;
            //Any constructor that we can use to initialize the collider class with
        }

        public void Collide(Player player)          //Check if the player collides with itself.
        {
            for (int i = 1; i < player.snakeBody.Count; i++)
            {
                var head = player.snakeBody.First();
                if (head.Equals(player.snakeBody[i]))
                {
                    Players.Remove(player);

                    if (Players.Count < 1)
                        GameOverEvent?.Invoke(player.playerID);

                    break;
                }
            }
        }

        public void CollideWithPlayers(Player player)       //Check if the player collides with other players and add a score of 5 to the player collided with
        {
            foreach (var PLAYER in Players)
            {
                if (PLAYER != player)
                {
                    for (int i = 0; i < PLAYER.snakeBody.Count; i++)
                    {
                        if (PLAYER.snakeBody[i].Equals(player.snakeBody.First()))
                        {
                            player.Remove(this);
                            PLAYER.Score += Settings.CollisionScore;
                            break;
                        }
                    }

                    break;
                }
            }
        }

        internal void Remove(Food food)
        {
            Eatables.Remove(food);
        }

        public void Collide(Food food)      //Check if anyplayer in the matrix is colliding with the food
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].snakeBody.First().Equals(food.Matrix))
                {
                    Player player = Players[i];
                    food.IncreaseLength(player);
                    food.IncreaseScore(player);
                    food.AddEffect(Players);
                    Players[i] = player;

                    food.Remove(this);
                }
            }
        }

        public bool CheckFood(Food food)        //Used to check if the food is on the same coordinates as any other type of food
        {
            if (Eatables == null)
                return false;

            foreach (var eatable in Eatables)
            {
                if (eatable.Matrix.Equals(food.Matrix))
                    return true;
            }

            return false;
        }

        public void Remove(Player player)       //Removing the player from the list of players
        {
            Players.Remove(player);
        }
    }
}
