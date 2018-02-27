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
        protected List<Rectangle> snakeBody;
        protected enum Direction { Up, Left, Down, Right }
        protected Direction moveDirection { get; set; }

        public Snake()
        {
            snakeBody = new List<Rectangle>();
            snakeBody.Clear();

            snakeBody.Add(new Rectangle(new Point(420, 420), new Size(10, 10)));
            snakeBody.Add(new Rectangle(new Point(410, 420), new Size(10, 10)));
            snakeBody.Add(new Rectangle(new Point(400, 420), new Size(10, 10)));
        }

        public void MoveSnake()
        {
            Rectangle part;

            for (int i = snakeBody.Count; i < 0; i--)
            {
                part = snakeBody[i];

                switch (moveDirection)
                {
                    case Direction.Up:
                        part.Y--;
                        break;
                    case Direction.Left:
                        part.X--;
                        break;
                    case Direction.Down:
                        part.Y++;
                        break;
                    case Direction.Right:
                        part.X++;
                        break;
                }

                snakeBody[i] = part;
            }
        }
    }
}
