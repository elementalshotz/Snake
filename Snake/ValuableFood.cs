using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class ValuableFood : Food
    {
        public ValuableFood() : base()
        {
            Pos = Food.SpawnPoint();
            rect = new Rectangle(Position, new Size(Settings.size, Settings.size));

            while (CheckFoodPosition())
            {
                Pos = Food.SpawnPoint();
                rect = new Rectangle(Position, new Size(Settings.size, Settings.size));
            }
            
            Matrix = new MatrixPoint(Pos.X/15, Pos.Y/15);
        }

        internal override void AddEffect(ref List<Player> playerList)
        {
            return;                 //Absolutely do nothing about this code, no effect is supposed to be added from the valuable type
        }

        internal override void Draw(Graphics g)
        {
            //g.DrawIcon(new Icon("CoffieCup.ico"), Pos.X, Pos.Y);
            g.FillRectangle(new SolidBrush(Color.SlateGray), rect);
        }

        internal override void Hit(Collider collider)
        {
            collider.Collide(this);
        }

        internal override void IncreaseLength(ref Player player)
        {
            player.AddParts(Settings.valuableLength);
        }

        internal override void IncreaseScore(ref Player player) => player.Score += Settings.valueableFood;
    }
}
