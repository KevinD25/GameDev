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
    class Hero : ICollide
    {

        static Texture2D[] heroIdle = new Texture2D[8];
        static Texture2D[] heroWalkRight = new Texture2D[6];
        static Texture2D[] heroJumpRight = new Texture2D[4];
        static Texture2D[] heroHurt = new Texture2D[2];
        static Texture2D[] heroCrouch = new Texture2D[2];


        private Boolean right = true;
        private int idling = 0;
        private int walking = 0;
        private int jumping = 0;
        private int crouching = 0;
        private int hurt = 0;

        public Rectangle collisionRectangle;
        public Rectangle collisionRectangleBottom;
        public Rectangle collisionRectangleTop;
        public Rectangle collisionRectangleLeft;
        public Rectangle collisionRectangleRight;

        public bool collisionTop = false;
        public bool collisionRight = false;
        public bool collisionLeft = false;
        public bool collisionBottom = false;

        public bool bovencollision = false;

        private LevelBase _level;
        private Delay delay;

        public Bediening _bediening { get; set; }

        public Vector2 positie;
        private bool hasJumped;
        private Vector2 velocity;
        public bool onBlock;

        public Hero(ContentManager cnt, LevelBase level)
        {
            LoadTextures(cnt);

            _level = level;
            delay = new Delay(0.15f);

            //collision detection vierkant aanmaken
            collisionRectangle = new Rectangle((int)positie.X + 60, (int)positie.Y, 73, 224);
            collisionRectangleTop = new Rectangle((int)positie.X + 60, (int)positie.Y, 73, 10);
            collisionRectangleBottom = new Rectangle((int)positie.X + 60, (int)positie.Y + 214, 73, 10);
            collisionRectangleLeft = new Rectangle((int)positie.X, (int)positie.Y + 12, 10, 200);
            collisionRectangleRight = new Rectangle((int)positie.X + 153, (int)positie.Y + 12, 10, 200);


            // hero positie geven op veld
            positie = level.beginPositie;
            hasJumped = true;
        }

        public Rectangle CollisionRectangle { get => collisionRectangle; set => collisionRectangle = value; }

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

            _bediening.Update();

            positie += velocity;

            //TODO Collision logic in if statements

            if (_bediening.right && !collisionRight )
            {
                delay.setDelay(0.07f); //Running speed
                if (delay.timerDone(gameTime))
                {
                    positie.X += 6; //Running distance per tick
                    if (walking < 5 && right)
                    {
                        walking++;
                    }
                    else if (right)
                    {
                        walking = 0;
                    }
                }
            }
            else if (_bediening.left && !collisionLeft)
            {
                delay.setDelay(0.07f);
                if (delay.timerDone(gameTime))
                {
                    positie.X += -6;
                    if (walking < 5 && !right)
                    {
                        walking++;
                    }
                    else if (!right)
                    {
                        walking = 0;
                    }
                }
            }
            if (_bediening.up && hasJumped == false && onBlock)
            {
                // hero laten springen (SOURCE: https://www.youtube.com/watch?v=ZLxIShw-7ac&t=303s)
                
                    positie.Y = positie.Y - 2f; //Drop distance
                    velocity.Y = -1f; //Drop speed
                    hasJumped = true;    
                delay.setDelay(0.2f);
                if (delay.timerDone(gameTime))
                {
                    if(jumping < 3)
                    {
                        jumping++;
                    }
                    else
                    {
                        jumping = 0;
                    }
                }
            }
            else if (_bediening.down)
            {
                delay.setDelay(0.15f);
                if (delay.timerDone(gameTime))
                {
                   
                    if (crouching < 1)
                    {
                        crouching++;
                    }
                    else
                    {
                        crouching = 0;
                    }
                }
            }
            else
            {
                delay.setDelay(0.15f);
                if (delay.timerDone(gameTime))
                {
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
            if (hasJumped || collisionTop == false)
            {
                //Velocity na jump
               /* 
                float i = 1;
                velocity.Y += 0.50f * i;
                onBlock = false;*/
            }
            if (collisionTop)
            {
                velocity.Y = 0;
                positie.Y = _level.collisionMargin - collisionRectangle.Height + 1;
                hasJumped = false;
                onBlock = true;
                bovencollision = false;
            }

            //controleren op collissions
            collisionTop = _level.CheckCollisionTop(this);
            collisionLeft = _level.CheckCollisionLeft(this);
            collisionRight = _level.CheckCollisionRight(this);
            collisionBottom = _level.CheckCollisionBottom(this);

            // controleren op botsing boven
            if (collisionBottom && bovencollision == false)
            {
                velocity.Y = -velocity.Y;
                bovencollision = true;
            }

            collisionRectangle.X = (int)positie.X + 60;
            collisionRectangle.Y = (int)positie.Y;

            collisionRectangleTop.X = (int)positie.X + 60;
            collisionRectangleTop.Y = (int)positie.Y;

            collisionRectangleBottom.X = (int)positie.X + 60;
            collisionRectangleBottom.Y = (int)positie.Y + 214;

            collisionRectangleLeft.X = (int)positie.X;
            collisionRectangleLeft.Y = (int)positie.Y + 12;

            collisionRectangleRight.X = (int)positie.X + 153;
            collisionRectangleRight.Y = (int)positie.Y + 12;
        }




        public void Draw(SpriteBatch spritebatch)
        {
            if (_bediening.left)
            {
                //logic for left run
                    spritebatch.Draw(heroWalkRight[walking], positie, Color.AliceBlue);
                right = false;
            }
            else if (_bediening.right)
            {
                //logic for right run  
                    spritebatch.Draw(heroWalkRight[walking], positie, Color.AliceBlue);
                right = true;
            }
            else if (_bediening.up)
            {
                //logic for left and right jump
                if (right)
                {
                    spritebatch.Draw(heroJumpRight[jumping], positie, Color.AliceBlue);
                }
                else
                {
                    //TODO Mirror sprite
                    spritebatch.Draw(heroJumpRight[jumping], positie, Color.AliceBlue);
                }
            }
            else if (_bediening.down)
            {
                //logic for left and right crouch
                if (right)
                {
                    spritebatch.Draw(heroCrouch[crouching], positie, Color.AliceBlue);
                }
                else
                {
                    spritebatch.Draw(heroCrouch[crouching], positie, Color.AliceBlue);// TODO Mirror sprite
                }
                
            }
            else
            {
                if (right)
                {
                    spritebatch.Draw(heroIdle[idling], positie, Color.AliceBlue);
                }
                else
                {
                    //logic for left idle
                    //TODO Mirror sprites
                    spritebatch.Draw(heroIdle[idling], positie, Color.AliceBlue);
                }
            }
        }
    }
}
