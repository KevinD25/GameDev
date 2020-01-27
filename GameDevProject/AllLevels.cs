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
        private Level2 level2;
        private Startscherm startScherm;
        public LevelBase huidigLevel;
        private Eindscherm eindScherm;


        public AllLevels(ContentManager content)
        {
            startScherm = new Startscherm(content);
            eindScherm = new Eindscherm(content);
            level1 = new Level1(content);
            level2 = new Level2(content);
            huidigLevel = startScherm;  //dient aangepast te worden naar startscherm
        }

        public void CreateWorld()
        {
            huidigLevel.CreateWorld();
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            huidigLevel.DrawWorld(spriteBatch);
        }

        public void startGame()
        {
            huidigLevel = level1;
        }

        public void StopGame()
        {
            huidigLevel = eindScherm;
        }

        public void restartGame()
        {
            huidigLevel = startScherm;
        }

        public void nextLevel()
        {
            if(huidigLevel == level1)
            {
                huidigLevel = level2;
            }else if(huidigLevel == level2)
            {
                huidigLevel = eindScherm;
            }
        }
    }
}
