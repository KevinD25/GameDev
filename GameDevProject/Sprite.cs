using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    class Sprite
    {
        public Rectangle collisionRectangle;
        public Rectangle collisionRectangleBottom;
        public Rectangle collisionRectangleTop;
        public Rectangle collisionRectangleLeft;
        public Rectangle collisionRectangleRight;

        public virtual void LoadTextures(ContentManager cnt)
        {

        }

        public virtual void Update(float elapsedTime, GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
