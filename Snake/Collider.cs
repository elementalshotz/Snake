using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Collider
    {
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
            food.Remove(this, food);
        }
    }
}
