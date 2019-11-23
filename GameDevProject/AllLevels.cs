using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    class AllLevels
    {
        private Level1 level1;
       
        private Startscherm startScherm;
        public LevelBase huidigLevel;
        private Eindscherm eindScherm;
        public int round;
 


        public AllLevels(ContentManager content)
        {
            startScherm = new Startscherm(content);
            eindScherm = new Eindscherm(content);
            level1 = new Level1(content);
            huidigLevel = level1;  //dient aangepast te worden naar startscherm
        }

        public void CreateWorld()
        {
            huidigLevel.CreateWorld();
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            huidigLevel.DrawWorld(spriteBatch);
        }
    }
}
