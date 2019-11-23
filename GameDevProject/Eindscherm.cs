using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace GameDevProject
{
    class Eindscherm : LevelBase
    {
        private ContentManager content;

        public Eindscherm(ContentManager content)
        {
            this.content = content;
        }
    }
}
