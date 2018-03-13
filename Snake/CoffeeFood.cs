using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    public class CoffeeFood : Food
    {
        public CoffeeFood() : base()
        {
            //icon = new Icon("CoffieCup.ico");
        }

        internal override void AddEffect(List<Player> playerList)   //Adds the speedup effect to the snake 
        {                                                               //that either ate it if it is one or adding to a random if it exists more than one
            if (playerList.Count > 1)
            {
                int player = new Random().Next(playerList.Count);
                playerList[player].ActivateEffect(this);
            }
            else
            {
                playerList.First().ActivateEffect(this);
            }
        }

        internal override void Draw(Graphics g)
        {
            //g.DrawIcon(icon, Pos.X, Pos.Y);
            g.FillRectangle(new SolidBrush(Color.RosyBrown), Rect);
        }

        internal override void Hit(Collider collider)
        {
            collider.Collide(this);
        }

        internal override void IncreaseLength(Player player)
        {
            return; //Implemented on the other food types but since coffee food is just gonna speed up a snake we just return this call
        }

        internal override void IncreaseScore(Player player)
        {
            return; //Implemented on the other food types but since coffee food is just gonna speed up a snake we just return this call
        }
    }
}
