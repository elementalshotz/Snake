using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Collider
    {
        List<Player> Players;
        List<Food> Eatables;

        public Collider()
        {
            //Any constructor that we can use to initialize the collider class with
        }

        public void Collide(Player player)
        {

        }

        public void Collide(Food food)
        {
            //Some if statement
            //Remove code
            //foodList.Remove(food);
        }
    }
}
