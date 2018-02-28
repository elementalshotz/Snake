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
        public List<Rectangle> snakeBody;
        protected enum Direction { Up, Left, Down, Right }
        protected Direction moveDirection { get; set; }

        public Snake()
        {
            snakeBody = new List<Rectangle>();
            snakeBody.Clear();

            snakeBody.Add(new Rectangle(new Point(50, 50), new Size(10, 10)));

            moveDirection = Direction.Right;
        }

        public void MoveSnake()
        {
            Rectangle part;
            Rectangle secondPart;

            for (int i = snakeBody.Count-1; i >= 0; i--)
            {
                part = snakeBody[i];

                if (i == 0)
                {
                    switch (moveDirection)
                    {
                        case Direction.Up:
                            part.Y -= part.Height;
                            break;
                        case Direction.Left:
                            part.X -= part.Width;
                            break;
                        case Direction.Down:
                            part.Y += part.Height;
                            break;
                        case Direction.Right:
                            part.X += part.Width;
                            break;
                    }
                } else
                {
                    secondPart = snakeBody[i - 1];

                    part.X = secondPart.X;
                    part.Y = secondPart.Y;

                    snakeBody[i - 1] = secondPart;
                }

                if (part.X > Settings.Width)
                {
                    part.X = 0;
                } else if (part.X < 0)
                {
                    part.X = Settings.Width;
                } else if (part.Y > Settings.Height)
                {
                    part.Y = 0;
                } else if (part.Y < 0)
                {
                    part.Y = Settings.Height;
                }

                snakeBody[i] = part;
            }
        }
    }
}
