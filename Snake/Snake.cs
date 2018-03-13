using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public class Snake
    {
        public List<MatrixPoint> snakeBody;
        protected enum Direction { Up, Left, Down, Right }
        protected Direction moveDirection { get; set; }
        protected Point startPoint;

        public Snake(Point point)
        {
            snakeBody = new List<MatrixPoint>();
            snakeBody.Clear();

            startPoint = point;
            snakeBody.Add(new MatrixPoint(startPoint.X / Settings.size, startPoint.Y / Settings.size));

            moveDirection = Direction.Right;
        }

        public void MoveSnake()
        {
            for (int i = snakeBody.Count-1; i >= 0; i--)
            {
                if (i == 0)
                {
                    //Controls the movement of the head
                    switch (moveDirection)
                    {
                        case Direction.Up:
                            snakeBody[i].Y -= 1;
                            break;
                        case Direction.Left:
                            snakeBody[i].X -= 1;
                            break;
                        case Direction.Down:
                            snakeBody[i].Y += 1;
                            break;
                        case Direction.Right:
                            snakeBody[i].X += 1;
                            break;
                    }
                } else
                {
                    //Controls the movement of the rest of the body
                    snakeBody[i - 1] = snakeBody[i];
                }

                //Transports the snake to the otherside so if travelling outside in x axis it will be reset to 0
                if (snakeBody[i].X > Settings.Width / Settings.size)
                {
                    snakeBody[i].X = 0;
                }
                else if (snakeBody[i].X < 0)
                {
                    snakeBody[i].X = Settings.Width / Settings.size;
                }
                else if (snakeBody[i].Y > Settings.Height / Settings.size)
                {
                    snakeBody[i].Y = 0;
                }
                else if (snakeBody[i].Y < 0)
                {
                    snakeBody[i].Y = Settings.Height / Settings.size;
                }
            }
        }
    }
}
