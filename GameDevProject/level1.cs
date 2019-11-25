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
            //Set hero positie
            beginPositieHero = new Vector2(110, 220);
            //Set ants positie - set aantal ants
            beginPositieAnts.Add(new Vector2(530, 232));
            beginPositieAnts.Add(new Vector2(310, 232));



            //Set acorns positie - set aantal acorns
            beginPositieAcorns.Add(new Vector2(200, 230));
            beginPositieAcorns.Add(new Vector2(200, 160));
            beginPositieAcorns.Add(new Vector2(300, 200));
            beginPositieAcorns.Add(new Vector2(110, 250));

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
