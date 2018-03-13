using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public class MagicMushroom : Food
    {
        public MagicMushroom() : base()
        {
            //icon = new Icon("Mushroom.ico");
        }

        internal override void Draw(Graphics g)
        {
            //g.DrawIcon(icon, Pos.X, Pos.Y);
            g.FillRectangle(new SolidBrush(Color.Purple), Rect);
        }

        internal override void Hit(Collider collider)
        {
            collider.Collide(this);
        }

        internal override void AddEffect(List<Player> playerList)       //Call the player and activate the effect using a dynamic dispatch
        {
            if (playerList.Count > 1)
            {
                int player = new Random().Next(playerList.Count);
                playerList[player].ActivateEffect(this);
            } else
            {
                playerList.First().ActivateEffect(this);
            }
        }

        internal override void IncreaseLength(Player player)        //Adding parts to the snake is necessary since this doesn't spawn that often
        {                                                               // so it will add 5 parts beginning from the end of the snake
            player.AddParts(Settings.mushroomLength);
        }

        internal override void IncreaseScore(Player player) => player.Score += Settings.magicMushroom;
    }
}
