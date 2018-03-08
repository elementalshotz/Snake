using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public class MagicMushroom : Food, IFoodCollidable
    {
        Random random;

        public MagicMushroom() : base()
        {
            random = new Random();
            Position = GeneratePosition(Settings.size);
            //icon = new Icon("Mushroom.ico");
        }

        private Point GeneratePosition(int multipleOf)
        {
            int x = random.Next(Settings.Width - Settings.size);

            while (x % multipleOf != 0)
            {
                x = random.Next(Settings.Width - multipleOf);
            }

            int y = random.Next(Settings.Height - Settings.size);

            while (y % multipleOf != 0)
            {
                y = random.Next(Settings.Height - Settings.size);
            }

            return new Point(x, y);
        }

        internal override void Draw(Graphics g)
        {
            //g.DrawIcon(icon, Pos.X, Pos.Y);
            g.FillRectangle(new SolidBrush(Color.Purple), new Rectangle(Position, new Size(Settings.size, Settings.size)));
        }

        internal override void Hit(Collider collider)
        {
            collider.Collide(this);
        }

        internal override void AddEffect(ref List<Player> playerList)
        {
            int player = random.Next(playerList.Count);
            playerList[player].activateEffect(this);
        }

        internal override void IncreaseLength(ref Player player)
        {
            for (int i = 0; i < Settings.mushroomLength; i++)
            {
                player.snakeBody.Add(player.snakeBody.Last());
            }
        }

        internal override void IncreaseScore(ref Player player) => player.Score += Settings.magicMushroom;
    }
}
