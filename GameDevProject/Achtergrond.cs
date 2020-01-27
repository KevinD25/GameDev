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
    class Achtergrond
    {
        private Texture2D texture1;
        private Texture2D texture2;
        private Texture2D texture3;
        public Camera2d camera;
        private float cameraX, cameraY;
        private ContentManager cnt;
        private Vector2 positie;

        public Achtergrond(ContentManager content, Camera2d cam)
        {  
            cnt = content;
            LoadAchtergrond();
            camera = cam;
            positie.X = camera.Transform.Translation.X;
            positie.Y = camera.Transform.Translation.Y;
            cameraX = positie.X;
            cameraY = positie.Y;
        }

        public void LoadAchtergrond()
        {
            texture1 = cnt.Load<Texture2D>("achtergrond/bg-clouds");
            texture2 = cnt.Load<Texture2D>("achtergrond/bg-mountains");
            texture3 = cnt.Load<Texture2D>("achtergrond/bg-trees");
        }

        public void drawBackground(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            spriteBatch.Draw(texture1, positie, new Rectangle(Convert.ToInt32(cameraX * 0.5f), Convert.ToInt32(cameraY * 0.5f), texture1.Width, texture1.Height), Color.White);
            spriteBatch.Draw(texture2, positie, new Rectangle(Convert.ToInt32(cameraX * 0.8f), Convert.ToInt32(cameraY * 0.8f), texture2.Width, texture2.Height), Color.White);
            spriteBatch.Draw(texture3, positie, new Rectangle(Convert.ToInt32(cameraX * 1.0f), Convert.ToInt32(cameraY * 1.0f), texture3.Width, texture3.Height), Color.White);
            spriteBatch.End();
        }
    }
}
