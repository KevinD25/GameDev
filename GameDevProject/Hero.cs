using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject
{
    class Hero 
    {

        static Texture2D[] heroIdle = new Texture2D[8];
        static Texture2D[] heroWalkRight = new Texture2D[6];
        static Texture2D[] heroJumpRight = new Texture2D[4];
        static Texture2D[] heroHurt = new Texture2D[2];
        static Texture2D[] heroCrouch = new Texture2D[2];

    
        private Boolean right = true;
        private int idling = 0;

        private LevelBase _level;

        public Bediening _bediening { get; set; }

        public Vector2 positie;
        private Vector2 velocity;

        public Hero(ContentManager cnt, LevelBase level)
        {
            LoadTextures(cnt);

            _level = level;

            // hero positie geven op veld
            positie = level.beginPositie;
        }

        private static void LoadTextures(ContentManager cnt)
        {
            for (int i = 0; i < 8; i++)
            {
                heroIdle[i] = cnt.Load<Texture2D>("hero/idle/player-idle-" + (i + 1));
            }

            for (int i = 0; i < 6; i++)
            {
                heroWalkRight[i] = cnt.Load<Texture2D>("hero/run/player-run-" + (i + 1));
            }

            for (int i = 0; i < 4; i++)
            {
                heroJumpRight[i] = cnt.Load<Texture2D>("hero/jump/player-jump-" + (i + 1));
            }

            for (int i = 0; i < 2; i++)
            {
                heroHurt[i] = cnt.Load<Texture2D>("hero/hurt/player-hurt-" + (i + 1));
            }

            for (int i = 0; i < 2; i++)
            {
                heroCrouch[i] = cnt.Load<Texture2D>("hero/crouch/player-crouch-" + (i + 1));
            }
        }

        public void Update(float elapsedTime, GameTime gameTime)
        {
            int timeschanged = 0;

            _bediening.Update();

            positie += velocity;

            //TODO Collision logic in if statements

            if (_bediening.right)
            {

            }
            else if (_bediening.left)
            {

            }
            else if (_bediening.up)
            {

            }
            else if (_bediening.down)
            {

            }
            else
            {if((gameTime.TotalGameTime.Milliseconds % 40) == 0)
                {
                    timeschanged++;
                    if (idling < 7)
                    {
                        idling++;
                    }
                    else
                    {
                        idling = 0;
                    }
                }
            }
        }



        public void Draw(SpriteBatch spritebatch)
        {
            if (_bediening.left)
            {
                //logic for left run
            }
            else if (_bediening.right)
            {
                //logic for left run
            }
            else if (_bediening.up)
            {
                //logic for left and right jump
            }
            else if (_bediening.down)
            {
                //logic for left and right crouch
            }
            else
            {
                if (right)
                {
                    spritebatch.Draw(heroIdle[idling], positie, Color.AliceBlue);
                }else
                {
                    //logic for left idle
                }
            }
        }

        
    }
}
