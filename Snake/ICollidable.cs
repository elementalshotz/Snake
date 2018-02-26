using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public interface ICollidable : IDrawable
    {
        void Hit(Collider collider);
        void Remove(Collider collider);
    }
}
