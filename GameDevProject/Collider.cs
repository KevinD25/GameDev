using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    public class Collider
    {
        public Collider()
        {

        }

        public bool CheckCollider(ICollide source, ICollide target)
        {
            if (source.CollisionRectangle.Intersects(target.CollisionRectangle))
                return true;
            return false;
        }
    }
}
