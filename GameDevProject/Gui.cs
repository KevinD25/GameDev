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
    class Gui
    {
        private Texture2D levens;
        private Texture2D acorns;

        public Gui(ContentManager cnt)
        {
            levens = cnt.Load<Texture2D>("hero/idle/player-idle-1");
            acorns = cnt.Load<Texture2D>("acorn/acorn-1");
        }

        public void Draw(SpriteBatch spritebatch, Hero hero)
        {
            spritebatch.Begin();

            spritebatch.Draw(levens, new Vector2(500, -15), Color.AliceBlue);

            if (hero.levens > 0) { spritebatch.Draw(levens, new Vector2(-15, -15), Color.AliceBlue); }
            if (hero.levens > 1) { spritebatch.Draw(levens, new Vector2(20, -15), Color.AliceBlue); }
            if (hero.levens > 2) {
                spritebatch.Draw(levens, new Vector2(55, -15), Color.AliceBlue);
                spritebatch.Draw(levens, new Vector2(-90, -15), Color.AliceBlue);
            }

            
            spritebatch.End();
            spritebatch.Begin();
            

            spritebatch.End();
        }

    }
}
