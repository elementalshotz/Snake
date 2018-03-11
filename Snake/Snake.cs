﻿using System;
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
                    //Controls the movement of the head
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

                    snakeBody[i].matrixPoint = new MatrixPoint(part.X / 15, part.Y / 15);
                } else
                {
                    //Controls the movement of the rest of the body
                    secondPart = snakeBody[i - 1].Part;
                    
                    part.X = secondPart.X;
                    part.Y = secondPart.Y;
                    snakeBody[i].matrixPoint = snakeBody[i - 1].matrixPoint;

                    snakeBody[i - 1].Part = secondPart;
                }

                //Transports the snake to the otherside so if travelling outside in x axis it will be reset to 0
                if (part.X > Settings.Width)
                {
                    part.X = 0;
                    snakeBody[i].matrixPoint.X = 0;
                }
                else if (part.X < 0)
                {
                    part.X = Settings.Width;
                    snakeBody[i].matrixPoint.X = Settings.Width / 15;
                }
                else if (part.Y > Settings.Height)
                {
                    part.Y = 0;
                    snakeBody[i].matrixPoint.Y = 0;
                }
                else if (part.Y < 0)
                {
                    part.Y = Settings.Height;
                    snakeBody[i].matrixPoint.Y = Settings.Height / 15;
                }

                snakeBody[i].Part = part;
            }
        }
    }
}
