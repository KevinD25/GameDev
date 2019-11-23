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
        public Achtergrond achtergrond;
        public Vector2 beginPositie = new Vector2(0, 0);

        public int maxTijd = 100;

        public virtual void CreateWorld()
        {

        }

        public virtual void DrawWorld(SpriteBatch spritebatch)
        {

        }
    }
}
