using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace GameDevProject
{
    class Startscherm : LevelBase
    {
        BedieningPijltjes bediening;
        Texture2D achtergrond;
        public Vector2 positie = new Vector2(0, 0);

        public Startscherm(ContentManager content)
        {
            achtergrond = content.Load<Texture2D>("startscherm");
            bediening = new BedieningPijltjes();
            song = content.Load<SoundEffect>("music/startscherm");
        }

        public void drawScreen(SpriteBatch spritebatch, GraphicsDevice graphicsDevice)
        {
            spritebatch.Begin();
            spritebatch.Draw(achtergrond, positie, Color.AliceBlue);
            spritebatch.End();
        }

        public override bool CheckLevel()
        {
            bediening.Update();
            return bediening.enter;
        }
        
    }
}
