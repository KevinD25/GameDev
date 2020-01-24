﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    public class Level1 : Level 
    {


        public Level1(ContentManager content) : base(content)
        {
            //Set hero positie
            beginPositieHero = new Vector2(150, 220);
            //Set ants positie - set aantal ants
            beginPositieAnts.Add(new Vector2(530, 232));
            beginPositieAnts.Add(new Vector2(310, 232));



            //Set acorns positie - set aantal acorns
            beginPositieAcorns.Add(new Vector2(200, 230));
            beginPositieAcorns.Add(new Vector2(200, 160));
            beginPositieAcorns.Add(new Vector2(300, 200));
            beginPositieAcorns.Add(new Vector2(110, 250));

            tileArray = new byte[,]
        {
            {11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,10,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,10,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,10,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,24,25,26,27,28,10,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,29,30,31,32,33,10,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,34,35,36,37,38,10,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,39,40,41,42,43,10,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,44,45,46,47,48,10,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,49,50,51,52,53,10,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,0,1,99,99,99,99,99,99,99,16,99,99,99,99,99,99,99,99,99,99,99,99,99,55,56,57,58,10,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,8,9,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,17,99,99,99,99,99,61,62,63,10,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,16,99,99,99,2,3,3,3,3,3,4,99,99,17,99,99,99,99,99,99,99,99,99,99,99,99,2,3,3,3,3,3,3,23,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,17,99,10,11,11,11,11,11,11,4,99,99,99,99,99,16,99,99,99,99,17,99,99,99,15,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,2,3,4,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,17,99,99,99,99,99,99,10,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,15,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,0,1,99,99,99,10,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,2,23,11,11,11,11,11,11,21,4,99,99,99,99,99,99,17,99,99,99,16,99,99,15,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,8,9,99,99,99,18,19,20,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,2,3,3,23,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,99,15,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,2,3,3,3,3,4,99,99,99,99,99,99,99,99,0,1,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,2,23,11,11,11,11,11,11,11,11,11,11,11,21,4,99,99,99,99,99,99,99,17,99,99,99,99,15,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,10,11,11,11,11,12,99,99,99,99,99,99,99,99,8,9,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,2,3,23,11,11,11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,99,15,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,21,3,3,3,3,3,3,23,11,11,11,11,21,3,3,3,3,3,3,3,3,3,3,3,3,4,99,99,99,99,99,99,99,99,99,99,99,99,2,3,3,3,23,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,21,4,99,99,99,99,99,99,99,99,99,99,99,15,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,17,99,99,99,99,99,2,23,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,12,99,99,99,99,99,99,99,99,99,99,99,10,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,13,99,99,99,99,99,99,99,99,99,99,2,23,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,21,3,3,3,3,3,3,3,3,3,3,3,23,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,21,4,99,99,99,99,99,99,99,99,2,23,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,21,4,99,99,99,99,99,99,99,15,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,21,3,3,3,3,3,3,3,23,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},
{11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99},

        };
        }

}
}
