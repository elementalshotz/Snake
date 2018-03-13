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

        ICollidable[,] collidables;

        public Collider(List<Player> playerList, List<Food> foodList)
        {
            collidables = new ICollidable[Settings.Width / Settings.size, Settings.Height / Settings.size];
            Players = playerList;
            Eatables = foodList;
            //Any constructor that we can use to initialize the collider class with
        }

        public void updateMatrix()
        {
            collidables = new ICollidable[Settings.Width / Settings.size, Settings.Height / Settings.size];

            foreach (var player in Players)
            {
                foreach (var part in player.snakeBody)
                {
                    collidables[part.X, part.Y] = player;
                }
            }
        }

        public void Collide(Player player)          //Check if the player collides with itself.
        {
            if (collidables[player.snakeBody.First().X, player.snakeBody.First().Y] != null)
            {
                if (collidables[player.snakeBody.First().X, player.snakeBody.First().Y] is Player)
                {
                    player.Remove(this);

                    Player playerFromMatrix = (Player)collidables[player.snakeBody.First().X, player.snakeBody.First().Y];

                    if (playerFromMatrix.playerID != player.playerID)
                        playerFromMatrix.Score += 5;

                    if (Players.Count < 1)
                        GameOverEvent.Invoke(player.playerID);
                }
            }
        }

        internal void Remove(Snake snake, Snake.Direction direction)      //Only happens if the snake is crashing into the wall...
        {
            switch (direction)
            {
                case Snake.Direction.Down: snake.snakeBody.First().Y -= 1; break;
                case Snake.Direction.Up: snake.snakeBody.First().Y += 1; break;
                case Snake.Direction.Left: snake.snakeBody.First().X += 1; break;
                case Snake.Direction.Right: snake.snakeBody.First().X -= 1; break;
            }

            Player p = (Player)collidables[snake.snakeBody.First().X, snake.snakeBody.First().Y];
            p?.Remove(this);
        }

        internal void Remove(Food food)         //Remove the food from the list of eatables which is a reference to the list found in Form1
        {
            Eatables.Remove(food);
        }

        public void Collide(Food food)      //Check if anyplayer in the matrix is colliding with the food
        {
            if (collidables[food.Matrix.X, food.Matrix.Y] != null)
            {
                Player player = (Player)collidables[food.Matrix.X, food.Matrix.Y];

                food.IncreaseLength(player);
                food.IncreaseScore(player);
                food.AddEffect(Players);

                food.Remove(this);
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
