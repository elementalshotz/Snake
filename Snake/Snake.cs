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
        public List<BodyPart> snakeBody;
        protected enum Direction { Up, Left, Down, Right }
        protected Direction moveDirection { get; set; }
        protected Point startPoint;
        protected int multiplier = 1;

        public Snake(Point point)
        {
            snakeBody = new List<BodyPart>();
            snakeBody.Clear();

            startPoint = point;
            snakeBody.Add(new BodyPart(startPoint));

            moveDirection = Direction.Right;
        }

        public void MoveSnake()
        {
            Rectangle part;
            Rectangle secondPart;

            for (int i = snakeBody.Count-1; i >= 0; i--)
            {
                part = snakeBody[i].Part;

                if (i == 0)
                {
                    switch (moveDirection)
                    {
                        case Direction.Up:
                            part.Y -= (part.Height * multiplier);
                            break;
                        case Direction.Left:
                            part.X -= (part.Width * multiplier);
                            break;
                        case Direction.Down:
                            part.Y += (part.Height * multiplier);
                            break;
                        case Direction.Right:
                            part.X += (part.Width * multiplier);
                            break;
                    }
                } else
                {
                    secondPart = snakeBody[i - 1].Part;

                    part.X = secondPart.X;
                    part.Y = secondPart.Y;

                    snakeBody[i - 1].Part = secondPart;
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

                snakeBody[i].Part = part;
            }
        }
    }
}
