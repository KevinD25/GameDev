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

        public Level1(ContentManager content) : base (content)
        {
            tileArray = new Byte[,]
        {
            {1,0,0,0,0,1 },
            {1,0,0,0,0,1 },
            {1,0,0,0,0,1 },
            {1,0,0,0,0,1 },
            {1,1,1,1,1,1 },
        };
        }
    
    }
}
