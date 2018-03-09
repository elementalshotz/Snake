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

        public delegate void GameOverDelegate();
        public event GameOverDelegate GameOverEvent;
        int[,] gameMatrix = new int[34,34];

        public Collider(List<Player> PlayerList, List<Food> FoodList)
        {

            Players = PlayerList;
            Eatables = FoodList;
            //Any constructor that we can use to initialize the collider class with
        }

        public void PutIntoMatrix()
        {
            gameMatrix = new int[34, 34];

            foreach (var player in Players)
            {
                int id = player.playerID;
                foreach (var bodyPart in player.snakeBody)
                {
                    gameMatrix[bodyPart.matrixPoint.X, bodyPart.matrixPoint.Y] = id;
                }
            }
        }

        public void Collide(Player player)
        {
            for (int i = 1; i < player.snakeBody.Count; i++)
            {
                var head = player.snakeBody.First();
                if (head.Part.Equals(player.snakeBody[i].Part))
                {
                    Players.Remove(player);

                    if (Players.Count == 0)
                        GameOverEvent.Invoke();

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
