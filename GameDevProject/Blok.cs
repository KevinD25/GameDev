using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    public class Blok
    {
        public Texture2D _texture { get; set; }
        public Vector2 positie { get; set; }
        public bool endPoint = false;
        public Rectangle CollisionRectangle;
        public bool collision = false;

        public Blok(Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            positie = pos;

            CollisionRectangle.X = (int)positie.X;
            CollisionRectangle.Y = (int)positie.Y;
            CollisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, positie, Color.AliceBlue);
        }
    }
}
