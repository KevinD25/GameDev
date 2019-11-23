using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    class LevelBase
    {

        public Vector2 beginPositie = new Vector2(0, 0);

        // collision detection variable
        public int collisionMargin = 0;

        public virtual void CreateWorld()
        {

        }

        public virtual void DrawWorld(SpriteBatch spritebatch)
        {

        }

        public virtual bool CheckCollisionTop(Hero hero)
        {
            return false;
        }

        public virtual bool CheckCollisionLeft(Hero hero)
        {
            return false;
        }

        public virtual bool CheckCollisionRight(Hero hero)
        {
            return false;
        }

        public virtual bool CheckCollisionBottom(Hero hero)
        {
            return false;
        }
    }
}
