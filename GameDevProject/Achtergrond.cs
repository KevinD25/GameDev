using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    class Achtergrond
    {
        private Texture2D _texture;
        private Vector2 positie;

        public Achtergrond(Texture2D texture)
        {
            _texture = texture;
        }

        public void UpdateAchtergrond(Hero target)
        {
            /*positie.X = target.positie.X + (target.viewRechtangle.Width / 2) - (Game1.screenWidth / 2);
            positie.Y = target.positie.Y + (target.viewRechtangle.Height / 2) - (Game1.screenHeight / 2);*/
        }

        public void drawAchtergrond(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch.Draw(_texture, positie, Color.AliceBlue);
        }
    }
}
