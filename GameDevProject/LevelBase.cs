using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    public class LevelBase
    {

        public Vector2 beginPositieHero = new Vector2(0, 0);
        public List<Vector2> beginPositieAnts = new List<Vector2>();
        public List<Vector2> beginPositieAcorns = new List<Vector2>();
        public int heroLives = 3;
        public Hero Hero { get; set; }
        public Enemy Enemy { get; set; }

        // collision detection variable
        public int collisionMargin = 0;

        public virtual void CreateWorld()
        {

        }

        public virtual void DrawWorld(SpriteBatch spritebatch)
        {

        }

        public virtual bool CheckCollisionTop(Sprite sprite)
        {
            return false;
        }

        public virtual bool CheckCollisionLeft(Sprite sprite)
        {
            return false;
        }

        public virtual bool CheckCollisionRight(Sprite sprite)
        {
            return false;
        }

        public virtual bool CheckCollisionBottom(Sprite sprite)
        {
            return false;
        }

        public virtual bool CheckEndpoint(Hero hero)
        {
            return false;
        }

        public virtual bool CheckCollisionTopSprites(Sprite player, List<Sprite> target)
        {
            return false;
        }
        public virtual bool CheckCollisionLeftSprites(Sprite player, List<Sprite> target)
        {
            return false;
        }
        public virtual bool CheckCollisionRightSprites(Sprite player, List<Sprite> target)
        {
            return false;
        }
        public virtual bool CheckCollisionBottomSprites(Sprite player, List<Sprite> target)
        {
            return false;
        }
    }
}
