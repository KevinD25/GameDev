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
    class Level1 : Level 
    {


        public Level1(ContentManager content) : base(content)
        {
            beginPositieHero = new Vector2(110, 220);
            beginPositieAnts.Add(new Vector2(530, 232));
            beginPositieAnts.Add(new Vector2(310, 232));

            tileArray = new Byte[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,1,0,0,0,0,1 },
            {1,1,1,1,1,1,1,1,1,1,1 },
        };
        }

}
}
