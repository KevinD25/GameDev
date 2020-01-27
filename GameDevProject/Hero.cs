using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GameDevProject
{
    public class Hero : Sprite
    {

        static Texture2D[] heroIdleRight = new Texture2D[8];
        static Texture2D[] heroWalkRight = new Texture2D[6];
        static Texture2D[] heroJumpRight = new Texture2D[4];
        static Texture2D[] heroHurt = new Texture2D[2];
        static Texture2D[] heroCrouchRight = new Texture2D[2];
        static Texture2D[] heroIdleLeft = new Texture2D[8];
        static Texture2D[] heroWalkLeft = new Texture2D[6];
        static Texture2D[] heroJumpLeft = new Texture2D[4];
        static Texture2D[] heroCrouchLeft = new Texture2D[2];

        /*public Rectangle collisionRectangle;
        public Rectangle collisionRectangleBottom;
        public Rectangle collisionRectangleTop;
        public Rectangle collisionRectangleLeft;
        public Rectangle collisionRectangleRight;*/
      

        private bool right = true;
        public bool moving = false;
        private int idling = 0;
        private int walking = 0;
        private int jumping = 0;
        private int crouching = 0;     
        private int currentSeconds;

        private LevelBase _level;
        private Delay delay;

        public Enemy enemy;

        protected bool spriteHit = false;

        public bool bovenCollision = false;

        public bool collisionTop = false;
        public bool collisionRight = false;
        public bool collisionLeft = false;
        public bool collisionBottom = false;

        public bool collisionEndpoint = false;

        public bool collisionSpriteTop = false;
        public bool collisionSpriteRight = false;
        public bool collisionSpriteLeft = false;
        public bool collisionSpriteBottom = false;

        public Bediening _bediening { get; set; }

        public int collectedAcorns;
        public int levens;
        public bool firstHitEnemy = true;

        public Vector2 positie;
        public Vector2 tempPos;
        private bool hasJumped;
        public Vector2 velocity;
        public bool onBlock;
        public bool canJump;
        SoundEffectInstance soundEffectJump;
        SoundEffect seJump;

        static Texture2D custom;

        public Hero(ContentManager cnt, LevelBase level)
        {
            LoadTextures(cnt);

            _level = level;
            delay = new Delay(0.15f);

            // hero positie geven op veld
            positie = _level.beginPositieHero;
            tempPos = _level.beginPositieHero;
            
            //BUG AT RIGHT SIDE BLOK COLLISION
         
            //collision detection vierkant aanmaken
            collisionRectangle = new Rectangle((int)positie.X + 22, (int)positie.Y + 30, 19, 25);
            collisionRectangleTop = new Rectangle((int)positie.X + 22, (int)positie.Y+30, 19, 1);
            collisionRectangleBottom = new Rectangle((int)positie.X + 22, (int)positie.Y + 48, 19, 10);
            collisionRectangleLeft = new Rectangle((int)positie.X + 47, (int)positie.Y + 20, 10, 25);
            collisionRectangleRight = new Rectangle((int)positie.X+12, (int)positie.Y + 20, 10, 25);

            seJump = cnt.Load<SoundEffect>("effects/jump");
            soundEffectJump = seJump.CreateInstance();
            soundEffectJump.Volume = 0.5f;

            hasJumped = true;
        }

        public Rectangle CollisionRectangle { get => collisionRectangle; set => collisionRectangle = value; }

        public override void LoadTextures(ContentManager cnt)
        {
            #region Right
            for (int i = 0; i < 8; i++)
            {
                heroIdleRight[i] = cnt.Load<Texture2D>("hero/idle/player-idle-" + (i + 1));
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
                heroCrouchRight[i] = cnt.Load<Texture2D>("hero/crouch/player-crouch-" + (i + 1));
            }
            #endregion
            #region Left
            for (int i = 0; i < 8; i++)
            {
                heroIdleLeft[i] = cnt.Load<Texture2D>("hero/idleleft/player-idle-" + (i + 1));
            }

            for (int i = 0; i < 6; i++)
            {
                heroWalkLeft[i] = cnt.Load<Texture2D>("hero/runleft/player-run-" + (i + 1));
            }

            for (int i = 0; i < 4; i++)
            {
                heroJumpLeft[i] = cnt.Load<Texture2D>("hero/jumpleft/player-jump-" + (i + 1));
            }

            for (int i = 0; i < 2; i++)
            {
                heroCrouchLeft[i] = cnt.Load<Texture2D>("hero/crouchleft/player-crouch-" + (i + 1));
            }
            #endregion

            custom = cnt.Load<Texture2D>("tijdelijk/custom");
        }

        public override void Update(float elapsedTime, GameTime gameTime)
        {

            _bediening.Update();
            CheckCollisions(gameTime);

            positie += velocity;


            //Collision logic in if statements

            if (collisionSpriteTop || collisionSpriteLeft || collisionSpriteRight) //Hero gets hit by sprite
            {
                spriteHit = true; 
                if(spriteHit && firstHitEnemy && levens > 0)
                {
                    levens--;
                    firstHitEnemy = false;
                    Console.WriteLine(levens);
                    positie = _level.beginPositieHero;
                    positie = tempPos;
                }
                
                //Console.WriteLine(spriteHit);
                
                firstHitEnemy = true;
            }
            else // HURT LOGIC
            {
                currentSeconds = gameTime.ElapsedGameTime.Seconds;
                if (gameTime.ElapsedGameTime.Seconds - currentSeconds == 3)
                {
                    spriteHit = false;
                    Console.WriteLine(spriteHit);
                }
            }


            if (hasJumped || !collisionTop)
            {
                float i = 1;
                velocity.Y += 0.50f * i;
                onBlock = false;
                delay.setDelay(0.1f);
                if (delay.timerDone(gameTime))
                {
                    if (jumping < 3)
                    {
                        jumping++;
                    }
                    else
                    {
                        jumping = 0;
                    }
                }
                if (moving)
                {
                    if (right)
                    {
                        positie.X += 2;
                    }
                    else
                    {
                        positie.X += -2;
                    }
                }

            }

            if (_bediening.right && !collisionLeft)
            {
                moving = true;
                right = true;
                if (!hasJumped) delay.setDelay(0.07f);
                //Running speed
                if (delay.timerDone(gameTime))
                {
                    positie.X += 7; //Running distance per tick
                    if (walking < 5 && right)
                    {
                        walking++;
                    }
                    else if (right)
                    {
                        walking = 0;
                    }
                }
            } //right
            else if (_bediening.left && !collisionRight)
            {
                moving = true;
                right = false;
                if (!hasJumped) delay.setDelay(0.07f);
                if (delay.timerDone(gameTime))
                {
                    positie.X += -7;
                    if (walking < 5 && !right)
                    {
                        walking++;
                    }
                    else if (!right)
                    {
                        walking = 0;
                    }
                }
            } //left
            else if (_bediening.down && !collisionTop)
            {
                moving = false;
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
            } //crouch
            else
            {
                moving = false;
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
            } //idle
            if (_bediening.up && !hasJumped && onBlock && canJump)
            {
                // hero laten springen (SOURCE: https://www.youtube.com/watch?v=ZLxIShw-7ac&t=303s)

                positie.Y = positie.Y - 10f; //jump speed
                velocity.Y = -5.3f; //Jump height
                hasJumped = true;
                canJump = false;
                collisionTop = false;
                soundEffectJump.Play();
             
            }
            if (!_bediening.up)
            {
                canJump = true;
            }

            if (collisionTop)
            {
                velocity.Y = 0;
                if(positie != _level.beginPositieHero)
                {
                    positie.Y = _level.collisionMargin - collisionRectangle.Height - 23f;
                }
                
                //Console.WriteLine(positie.Y + " " + positie.X);
                hasJumped = false;
                onBlock = true;
                bovenCollision = false;
            }

            // controleren op botsing boven
            if (collisionBottom && bovenCollision == false)
            {
                velocity.Y = -velocity.Y;
                bovenCollision = true;
            }


            //controleren op botsingen met sprites


            collisionRectangle.X = (int)positie.X + 33;
            collisionRectangle.Y = (int)positie.Y + 20;

            collisionRectangleTop.X = (int)positie.X + 33;
            collisionRectangleTop.Y = (int)positie.Y + 20;

            collisionRectangleBottom.X = (int)positie.X + 33;
            collisionRectangleBottom.Y = (int)positie.Y + 48;

            collisionRectangleLeft.X = (int)positie.X + 50;
            collisionRectangleLeft.Y = (int)positie.Y + 20;

            collisionRectangleRight.X = (int)positie.X + 25;
            collisionRectangleRight.Y = (int)positie.Y + 20;

            Console.WriteLine("X = " + positie.X + " | Y = " + positie.Y);
            Console.WriteLine(_level.beginPositieHero.X + " | " + _level.beginPositieHero.Y);
            Console.WriteLine(tempPos.X + " | "+ tempPos.Y);
        }

        private void CheckCollisions(GameTime gameTime)
        {
            //controleren op collissions
            
            collisionLeft = _level.CheckCollisionLeft(this);
            collisionRight = _level.CheckCollisionRight(this);
            collisionTop = _level.CheckCollisionTop(this);
            collisionBottom = _level.CheckCollisionBottom(this);
            collisionEndpoint = _level.CheckEndpoint(this);


            //Logica om na te kijken of player geraakt wordt door enemy
            //controleren of sprite geraakt wordt door player
            collisionSpriteTop = _level.CheckCollisionTopSprites(this, _level.Enemy.ants);
            collisionSpriteLeft = _level.CheckCollisionLeftSprites(this, _level.Enemy.ants);
            collisionSpriteRight = _level.CheckCollisionRightSprites(this, _level.Enemy.ants);       

        }

        public override void Draw(SpriteBatch spritebatch)
        {
            Vector2 rectPos = new Vector2(collisionRectangle.X, collisionRectangle.Y);        

             /*spritebatch.Draw(custom, collisionRectangle, Color.Red);
              spritebatch.Draw(custom, collisionRectangleLeft, Color.Red);
              spritebatch.Draw(custom, collisionRectangleRight, Color.Red);
              spritebatch.Draw(custom, collisionRectangleTop, Color.Red);
              spritebatch.Draw(custom, collisionRectangleBottom, Color.Red);*/
            //Drawing hitboxes

            if (_bediening.up &&!onBlock  || hasJumped && !onBlock )
            {
                //logic for left and right jump
                if (right)
                {
                    spritebatch.Draw(heroJumpRight[jumping], positie, Color.AliceBlue);
                }
                else
                {
                    spritebatch.Draw(heroJumpLeft[jumping], positie, Color.AliceBlue);
                }
            }
            else if (_bediening.right && !hasJumped)
            {
                //logic for left run
                spritebatch.Draw(heroWalkRight[walking], positie, Color.AliceBlue);
                right = true;
            }
            else if (_bediening.left && !hasJumped)
            {
                //logic for right run  
                spritebatch.Draw(heroWalkLeft[walking], positie, Color.AliceBlue);
                right = false;
            }

            else if (_bediening.down)
            {
                //logic for left and right crouch
                if (right)
                {
                    spritebatch.Draw(heroCrouchRight[crouching], positie, Color.AliceBlue);
                }
                else
                {
                    spritebatch.Draw(heroCrouchLeft[crouching], positie, Color.AliceBlue);// TODO Mirror sprite
                }

            }
            else
            {
                if (right)
                {
                    spritebatch.Draw(heroIdleRight[idling], positie, Color.AliceBlue);
                }
                else
                {
                    //logic for left idle
                    spritebatch.Draw(heroIdleLeft[idling], positie, Color.AliceBlue);
                }
            }
        }
    }
}
