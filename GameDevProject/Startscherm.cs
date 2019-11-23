using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace GameDevProject
{
    class Startscherm : LevelBase
    {
        private ContentManager content;

        public Startscherm(ContentManager content)
        {
            this.content = content;
        }
    }
}
